public class CategorizeOutput
{
    /// <summary>
    ///     博客元素
    /// </summary>
    public string title { get; set; }

    /// <summary>
    /// </summary>
    public string backgroundColor { get; set; }

    /// <summary>
    /// </summary>
    public List<CategorizeOutputItem> list { get; set; }
}

/// <summary>
///     小类
/// </summary>
public class CategorizeOutputItem
{
    /// <summary>
    /// </summary>
    public string icon { get; set; }

    /// <summary>
    ///     内容中心
    /// </summary>
    public string title { get; set; }

    /// <summary>
    /// </summary>
    public string url { get; set; }
}