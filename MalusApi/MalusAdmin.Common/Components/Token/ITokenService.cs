namespace MalusAdmin.Common;

public interface ITokenService
{

    /// <summary>
    /// 生成token
    /// </summary>
    /// <param name="tokenData"></param>
    /// <returns></returns>
    Task<string> GenerateTokenAsync(TokenData tokenData);


    /// <summary>
    /// 校验token
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    Task<bool> ValidateToken(string token);

     
    /// <summary>
    /// 刷新token
    /// </summary>
    /// <param name="httpContext"></param>
    /// <param name="tokenData"></param>
    /// <returns></returns>
    Task RefreshTokenAsync(string token);

    /// <summary>
    /// 解析token
    /// </summary>
    /// <param name="httpContext"></param>
    /// <param name="tokenData"></param>
    /// <returns></returns>
    Task<TokenData> ParseTokenAsync(string token);
}