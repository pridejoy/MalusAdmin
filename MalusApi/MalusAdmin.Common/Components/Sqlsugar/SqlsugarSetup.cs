﻿using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using CSToolHub;
using MalusAdmin.Common.Helper;
using MalusAdmin.Repository.Model;
using Microsoft.Extensions.DependencyInjection;

namespace MalusAdmin.Common;

public static class SqlsugarSetup
{
    public static void AddSqlsugarSetup(this IServiceCollection services)
    {
        //数据库链接,修改配置里面的SqlServerConnection的字符串
        var ConnectionString = App.Configuration["SqlServerConnection"]?.ToString();

        //注释这行，我是从本地文件读取的
        //if (!AppSettings.IsDemo)
        //    ConnectionString = File.ReadAllText("D:\\MalusAdmindb.txt");

        var configConnection = new ConnectionConfig
        {
            DbType = DbType.SqlServer,
            ConnectionString = ConnectionString,
            IsAutoCloseConnection = true,
            ConfigId = 1
        };

        // 文档地址：https://www.donet5.com/Home/Doc?typeId=1204
        Action<SqlSugarClient> sqlclient = db =>
        {
            // 打印SQL语句
            db.Aop.OnLogExecuting = (sql, parameters) =>
            {
                var originColor = Console.ForegroundColor;
                if (sql.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                    Console.ForegroundColor = ConsoleColor.Green;
                if (sql.StartsWith("UPDATE", StringComparison.OrdinalIgnoreCase) ||
                    sql.StartsWith("INSERT", StringComparison.OrdinalIgnoreCase))
                    Console.ForegroundColor = ConsoleColor.Yellow;
                if (sql.StartsWith("DELETE", StringComparison.OrdinalIgnoreCase))
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("【" + DateTime.Now + "——执行SQL】\r\n" +
                                  UtilMethods.GetSqlString(db.CurrentConnectionConfig.DbType, sql, parameters) +
                                  "\r\n");
                Console.ForegroundColor = originColor;
            };
            //数据处理：增、删 和 改
            db.Aop.DataExecuting = (oldValue, entityInfo) =>
            {
                try
                { 

                    if (entityInfo.OperationType == DataFilterType.InsertByObject)
                    {
                     
                        if (entityInfo.PropertyName == "SysCreateUser")
                        {
                            entityInfo.SetValue(App.CurrentUser.UserId);
                        }
                        else if (entityInfo.PropertyName == "DeptId" && entityInfo.EntityName != "TSysUser")
                        {
                            
                                //entityInfo.SetValue(token.UserDept);
                            
                        }
                    }
                    else if (entityInfo.OperationType == DataFilterType.UpdateByObject)
                    { 
                        if (entityInfo.PropertyName == "SysUpdateUser") 
                                entityInfo.SetValue(App.CurrentUser.UserId);
                    }
                }
                catch
                {
                }
            };
            //查询事件 
            db.Aop.DataExecuted = (value, entity) => { };

            db.Aop.OnError = async ex =>
            {
                if (ex.Parametres == null) return;
                var originColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                var pars = db.Utilities.SerializeObject(
                    ((SugarParameter[])ex.Parametres).ToDictionary(it => it.ParameterName, it => it.Value));
                Console.ForegroundColor = originColor;
                Console.WriteLine("【" + DateTime.Now + "——执行SQL异常】\r\n" + pars + " \r\n");
                await LogUtils.WriteAsync("sqlerror/", ex.ToJson());
            };

            //监控所有超过1秒的Sql 
            db.Aop.OnLogExecuted = async (sql, p) =>
            {
                if (db.Ado.SqlExecutionTime.TotalSeconds > 1)
                {
                    //代码CS文件名
                    var fileName = db.Ado.SqlStackTrace.FirstFileName;
                    //代码行数
                    var fileLine = db.Ado.SqlStackTrace.FirstLine;
                    //方法名
                    var FirstMethodName = db.Ado.SqlStackTrace.FirstMethodName;
                    //db.Ado.SqlStackTrace.MyStackTraceList[1].xxx 获取上层方法的信息

                    Console.WriteLine("【" + DateTime.Now + "——执行SQL超时】\r\n" + fileName + " \r\n");
                    await LogUtils.WriteAsync("sqlexcution/", fileName + sql + fileLine + FirstMethodName);
                };
            };


            //全局过滤器
            var types = GetSugarTableTypes();
            // 配置加删除全局过滤器
            foreach (var entityType in types)
                if (!entityType.GetProperty("SysIsDelete").IsEmpty())
                {
                    //判断实体类中包含IsDeleted属性
                    //构建动态Lambda
                    var lambda = DynamicExpressionParser.ParseLambda(new[] { Expression.Parameter(entityType, "it") },
                        typeof(bool), $"{nameof(ModelBase.SysIsDelete)} ==  @0", false);
                    db.QueryFilter.Add(new TableFilterItem<object>(entityType, lambda)
                    {
                        IsJoinQuery = true
                    }); //将Lambda传入过滤器
                }
        };

        //SqlSugarScope线程是安全的
        var sqlSugar = new SqlSugarScope(configConnection, sqlclient);

        //这边是SqlSugarScope用AddSingleton
        services.AddSingleton<ISqlSugarClient>(sqlSugar);

        // 注册 SqlSugar 仓储
        services.AddScoped(typeof(SqlSugarRepository<>));
    }

    public static List<Type> GetSugarTableTypes()
    {
        var assemblies = AssemblyHelper.GetAssemblies("MalusAdmin.Repository");

        var types = new List<Type>();

        foreach (var assembly in assemblies)
        {
            // 获取所有类型
            var assemblyTypes = assembly.GetTypes();

            // 筛选出带有SugarTable特性的非抽象类
            types.AddRange(assemblyTypes.Where(type =>
                    !type.IsAbstract &&
                    type.IsDefined(typeof(SugarTable), true) // true 表示从继承层次结构中搜索特性
            ));
        }

        return types;
    }
}