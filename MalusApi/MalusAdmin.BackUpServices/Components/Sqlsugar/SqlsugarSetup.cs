 
using System.Linq.Expressions; 
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;

namespace MalusAdmin.BackUpServices;

public static class SqlsugarSetup
{
    public static void AddSqlsugarSetup(this IServiceCollection services)
    {
        //数据库链接,修改配置里面的SqlServerConnection的字符串
        var ConnectionString =""; 

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
                        
                    }
                    else if (entityInfo.OperationType == DataFilterType.UpdateByObject)
                    {
                       
                    }
                }
                catch
                {
                }
            };
            //查询事件 
            db.Aop.DataExecuted = (value, entity) => { };

            db.Aop.OnError = ex =>
            {
                if (ex.Parametres == null) return;
                var originColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                var pars = db.Utilities.SerializeObject(
                    ((SugarParameter[])ex.Parametres).ToDictionary(it => it.ParameterName, it => it.Value));
                Console.ForegroundColor = originColor;
                Console.WriteLine("【" + DateTime.Now + "——执行SQL异常】\r\n" + pars + " \r\n");
            };

            //监控所有超过1秒的Sql 
            db.Aop.OnLogExecuted = (sql, p) =>
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
                }

                ;
            };  
           
        };

        //SqlSugarScope线程是安全的
        var sqlSugar = new SqlSugarScope(configConnection, sqlclient);

        //这边是SqlSugarScope用AddSingleton
        services.AddSingleton<ISqlSugarClient>(sqlSugar);

        // 注册 SqlSugar 仓储
        services.AddScoped(typeof(SqlSugarRepository<>));
    } 
    
}