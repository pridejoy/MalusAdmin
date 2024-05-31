namespace MalusAdmin.Common.Components.Token;

/// <summary>
///     当前用户登录的信息
/// </summary>
public static class TokenInfo
{
    /// <summary>
    ///     当前
    /// </summary>
    public static TokenData User { get; set; } = new();
}