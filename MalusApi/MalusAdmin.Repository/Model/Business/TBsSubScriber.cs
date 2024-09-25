using SqlSugar;

namespace MalusAdmin.Repository.Entity
{
    /// <summary>
    /// 订购人表
    /// </summary>
    [SugarTable("bs_subscriber")]
    public class BsSubScriber
    {
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int SubscriberId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public int? OrderId { get; set; }

        /// <summary>
        /// Desc:种类
        /// Default:
        /// Nullable:True
        /// </summary>
        public int? SubscribeType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public int? CustomerID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string? SubscriberName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string? SubscriberMobile { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string? SubscriberIdCard { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public string? SubscriberType { get; set; }

        /// <summary>
        /// Desc:现住地址
        /// Default:
        /// Nullable:True
        /// </summary>
        public string? NowAddress { get; set; }

        /// <summary>
        /// Desc:银行名字
        /// Default:
        /// Nullable:True
        /// </summary>
        public string? BankName { get; set; }

        /// <summary>
        /// Desc:开户银行
        /// Default:
        /// Nullable:True
        /// </summary>
        public string? BankNo { get; set; }

        /// <summary>
        /// Desc:开户银行
        /// Default:
        /// Nullable:True
        /// </summary>
        public string? BankKaihu { get; set; }

        /// <summary>
        /// Desc:居住地址
        /// Default:
        /// Nullable:True
        /// </summary>
        public string? WorkUnit { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public DateTime? CreatedTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>
        public int? Sequence { get; set; }
    }
}