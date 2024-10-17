namespace Wechat.WebApi.Controllers;

public class EveryDayBingOutput
{
    public string CopyRight { get; set; }

    public string GitUrl { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    public DateTime StartDate { get; set; }

    public string Url { get; set; }

    public string MobileUrl { get; set; }
}