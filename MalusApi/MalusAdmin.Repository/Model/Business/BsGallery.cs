using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MalusAdmin.Models;


/// <summary>
/// 壁纸库
///</summary>
[SugarTable("bs_gallery", TableDescription = "")]
public class BsGallery
{
    /// <summary>
    /// 父id
    ///</summary>
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int ImagesID { get; set; }

    public string ImagesURL { get; set; }
    public decimal ImagesWide { get; set; }
    public decimal ImagesHeiget { get; set; }
    public decimal ImagesSize { get; set; }
    public string Type { get; set; }
    public bool VerticalScreen { get; set; }
    public bool IsDelete { get; set; }
    public int Praise { get; set; }
    public int DisLike { get; set; }
}