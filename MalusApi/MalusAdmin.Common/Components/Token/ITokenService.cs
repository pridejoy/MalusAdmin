namespace MalusAdmin.Common;

public interface ITokenService
{
    /// <summary>
    /// 校验token
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    bool CheckToken(HttpContext httpContext);

    /// <summary>
    /// 移除当前登录用户的Token缓存
    /// </summary>
    /// <param name="httpContext"></param>
    void RemoveToken(HttpContext httpContext);

    /// <summary>
    /// 解析token
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    TokenData ParseToken(HttpContext httpContext);

    /// <summary>
    /// 刷新token
    /// </summary>
    /// <param name="httpContext"></param>
    /// <param name="tokenData"></param>
    /// <returns></returns>
    string RefreshToken(HttpContext httpContext);


    /// <summary>
    /// 生成并保存token
    /// </summary>
    /// <param name="tokenData"></param>
    /// <returns></returns>
    string GenerateToken(TokenData tokenData);


    /// <summary>
    /// 添加缓存
    /// </summary>
    /// <param name="token"></param>
    /// <param name="tokeninfo"></param>
    void AddCheckToken(string token, TokenData tokeninfo);

    /// <summary>
    /// 删除需要验证的Token
    /// </summary>
    /// <param name="userId"></param>
    void RemoveCheckToken(string token);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>

    TokenData ParseTokenByCaChe(string token);
}