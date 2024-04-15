using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SqlSugar;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MalusAdmin.Common
{
    public static class SqlsugarSetup
    {
        public static void AddSqlsugarSetup(this IServiceCollection services)
        { 
            //注释这行，我是从本地文件读取的，下一行解除注释
            var ConnectionString = File.ReadAllText("D:\\MalusAdmindb.txt");
             
            //数据库链接,修改配置里面的SqlServerConnection的字符串
            //var ConnectionString= AppSettings.GetValue("SqlServerConnection"); 

            var configConnection = new ConnectionConfig
            {
                DbType = SqlSugar.DbType.SqlServer,
                ConnectionString = ConnectionString,
                IsAutoCloseConnection = true,
                ConfigId = 1
            };

            Action<SqlSugarClient> sqlclient = db =>
            {
                // 文档地址：https://www.donet5.com/Home/Doc?typeId=1204
                db.Aop.OnLogExecuting = (sql, parameters) =>
                {
                    var originColor = Console.ForegroundColor;
                    if (sql.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                        Console.ForegroundColor = ConsoleColor.Green;
                    if (sql.StartsWith("UPDATE", StringComparison.OrdinalIgnoreCase) || sql.StartsWith("INSERT", StringComparison.OrdinalIgnoreCase))
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    if (sql.StartsWith("DELETE", StringComparison.OrdinalIgnoreCase))
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("【" + DateTime.Now + "——执行SQL】\r\n" + UtilMethods.GetSqlString(db.CurrentConnectionConfig.DbType, sql, parameters) + "\r\n");
                    Console.ForegroundColor = originColor;
                   
                };
                db.Aop.DataExecuting = (oldValue, entityInfo) =>
                {
                    try
                    {

                        if (entityInfo.OperationType == DataFilterType.InsertByObject)
                        {
                            if (entityInfo.PropertyName == "SysCreateUser")
                            {
                                ITokenService tokenService = App.GetService<ITokenService>();
                                HttpContext httpContext = App.GetService<IHttpContextAccessor>().HttpContext;
                                TokenData token = tokenService.ParseToken(httpContext);
                                if (token != null)
                                {
                                    entityInfo.SetValue(token.UserId);
                                }

                            }
                            else if (entityInfo.PropertyName == "DeptId" && entityInfo.EntityName != "TSysUser")
                            {
                                ITokenService tokenService = App.GetService<ITokenService>();
                                HttpContext httpContext = App.GetService<IHttpContextAccessor>().HttpContext;
                                TokenData token = tokenService.ParseToken(httpContext);
                                if (token != null)
                                {
                                    entityInfo.SetValue(token.UserDept);
                                }
                            }
                        }
                        else if (entityInfo.OperationType == DataFilterType.UpdateByObject)
                        {
                            if (entityInfo.PropertyName == "SysUpdateUser")
                            {
                                ITokenService tokenService = App.GetService<ITokenService>();
                                HttpContext httpContext = App.GetService<HttpContext>();
                                TokenData token = tokenService.ParseToken(httpContext);
                                if (token != null)
                                {
                                    entityInfo.SetValue(token.UserId);
                                }
                            }
                        }
                    }
                    catch
                    {

                    }

                };
                db.Aop.OnError = ex =>
                {
                    if (ex.Parametres == null) return;
                    var originColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    var pars = db.Utilities.SerializeObject(((SugarParameter[])ex.Parametres).ToDictionary(it => it.ParameterName, it => it.Value));
                    Console.ForegroundColor = originColor;
                    Console.WriteLine("【" + DateTime.Now + "——执行SQL异常】\r\n" + pars +" \r\n");
                }; 
            };
              
            //SqlSugarScope线程是安全的
            SqlSugarScope sqlSugar = new SqlSugarScope(configConnection, sqlclient);

            //这边是SqlSugarScope用AddSingleton
            services.AddSingleton<ISqlSugarClient>(sqlSugar);

            // 注册 SqlSugar 仓储
            services.AddScoped(typeof(SqlSugarRepository<>));
        }

    }
}
