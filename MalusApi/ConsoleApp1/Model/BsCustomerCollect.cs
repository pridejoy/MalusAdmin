using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MalusAdmin.Models;


///<summary>
///用户喜欢表
///</summary>
[SugarTable("bs_customer_collect")]
public partial class BsCustomerCollect
{
    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:False
    /// </summary>
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int CollectID { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>
    public int UserID { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int ImagesID { get; set; }

    public bool IsLike { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>
    public DateTime? CreatedTime { get; set; }


}