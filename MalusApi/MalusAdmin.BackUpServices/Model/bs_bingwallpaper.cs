using SqlSugar;

namespace MalusAdmin.BackUpServices.Model;

public class bs_bingwallpaper
{
    [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
    public int Id { get; set; }

    public string CopyRight { get; set; }
    public string GitUrl { get; set; }
    public string Url { get; set; }
    public string MobileUrl { get; set; }
    public DateTime StartDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}