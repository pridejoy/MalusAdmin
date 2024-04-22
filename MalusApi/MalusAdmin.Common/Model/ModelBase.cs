using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using SqlSugar;

namespace MalusAdmin.Common.Model
{
    /// <summary>
    /// 实体的基类
    /// </summary>
    public class ModelBase
    {

        /// <summary>
        ///系统字段-创建人
        /// </summary>
        [SugarColumn(ColumnName = "SysCreateUser")]
        public Int32 SysCreateUser { get; set; }

        /// <summary>
        ///系统字段-创建时间
        ///默认值:CURRENT_TIMESTAMP
        /// </summary>
        [SugarColumn(ColumnName = "SysCreateTime", IsOnlyIgnoreInsert = true)]
        public DateTime SysCreateTime { get; set; }

        /// <summary>
        ///系统字段-修改人
        /// </summary>
        [SugarColumn(ColumnName = "SysUpdateUser")]
        public Int32 SysUpdateUser { get; set; }

        /// <summary>
        ///系统字段-修改时间
        ///默认值:CURRENT_TIMESTAMP
        /// </summary>
        [SugarColumn(ColumnName = "SysUpdateTime", IsOnlyIgnoreInsert = true)]
        public DateTime SysUpdateTime { get; set; }

        /// <summary>
        ///系统字段-删除人
        /// </summary>
        [SugarColumn(ColumnName = "SysDeleteUser")]
        public Int32 SysDeleteUser { get; set; }

        /// <summary>
        ///系统字段-删除时间
        /// </summary>
        [SugarColumn(ColumnName = "SysDeleteTime", IsOnlyIgnoreInsert = true)]
        public DateTime SysDeleteTime { get; set; }

        /// <summary>
        ///系统字段-删除标记
        ///默认值:0
        /// </summary>
        [SugarColumn(ColumnName = "SysIsDelete", DefaultValue = "0")]
        public Boolean SysIsDelete { get; set; }
    }

}
