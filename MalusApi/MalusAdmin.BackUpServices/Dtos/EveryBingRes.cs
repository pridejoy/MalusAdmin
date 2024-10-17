namespace MalusAdmin.BackUpServices;

public class ImagesItem
{
    /// <summary>
    /// </summary>
    public string startdate { get; set; }

    /// <summary>
    /// </summary>
    public string fullstartdate { get; set; }

    /// <summary>
    /// </summary>
    public string enddate { get; set; }

    /// <summary>
    /// </summary>
    public string url { get; set; }

    /// <summary>
    /// </summary>
    public string urlbase { get; set; }

    /// <summary>
    /// 佩格尼茨河上的葡萄酒窖，德国纽伦堡 (© Reinhard Schmid/Huber/eStock Photo)
    /// </summary>
    public string copyright { get; set; }

    /// <summary>
    /// </summary>
    public string copyrightlink { get; set; }

    /// <summary>
    /// 佩格尼茨河上的半木结构建筑
    /// </summary>
    public string title { get; set; }

    /// <summary>
    /// </summary>
    public string quiz { get; set; }

    /// <summary>
    /// </summary>
    public string wp { get; set; }

    /// <summary>
    /// </summary>
    public string hsh { get; set; }

    /// <summary>
    /// </summary>
    public int drk { get; set; }

    /// <summary>
    /// </summary>
    public int top { get; set; }

    /// <summary>
    /// </summary>
    public int bot { get; set; }

    /// <summary>
    /// </summary>
    public List<string> hs { get; set; }
}

public class Tooltips
{
    /// <summary>
    /// 正在加载...
    /// </summary>
    public string loading { get; set; }

    /// <summary>
    /// 上一个图像
    /// </summary>
    public string previous { get; set; }

    /// <summary>
    /// 下一个图像
    /// </summary>
    public string next { get; set; }

    /// <summary>
    /// 此图片不能下载用作壁纸。
    /// </summary>
    public string walle { get; set; }

    /// <summary>
    /// 下载今日美图。仅限用作桌面壁纸。
    /// </summary>
    public string walls { get; set; }
}

public class EveryBingRes
{
    /// <summary>
    /// </summary>
    public List<ImagesItem> images { get; set; }

    /// <summary>
    /// </summary>
    public Tooltips tooltips { get; set; }
}