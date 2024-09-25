using SqlSugar;

namespace MalusAdmin.Repository.Entity
{
    /// <summary>
    /// 微信配置表
    /// </summary>
    [SugarTable("bs_wechatconfig")]
    public class BsWechatConfig
    { /// <summary>
      /// Desc:
      /// Default:
      /// Nullable:False
      /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ConfigID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string? ConfigKey { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string? ConfigValue { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string? ConfigdDescribe { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:True
        /// </summary>
        public bool? IsDeleted { get; set; }
    }
}