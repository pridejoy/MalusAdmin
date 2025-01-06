using MalusAdmin.Common;
using SqlSugar;

namespace MalusAdmin.BackUpServices;

public  class SqlsugarHelper
{
    //创建数据库对象
    public SqlSugarClient db
    {
        get {
            return new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = AppSettings.SqlServerConnection,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            });
        }
    }
}