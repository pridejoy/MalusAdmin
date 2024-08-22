using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MalusAdmin.BackUpServices
{
    public static class SqlsugarHelper
    {
        //创建数据库对象
        public static SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = "",
            DbType = DbType.SqlServer,
            IsAutoCloseConnection = true
        });
    }
}
