using SqlSugar;

namespace MalusAdmin.BackUpServices;

public static class SqlsugarHelper
{
    //创建数据库对象
    public static SqlSugarClient db = new(new ConnectionConfig
    {
        ConnectionString = "",
        DbType = DbType.SqlServer,
        IsAutoCloseConnection = true
    });
}