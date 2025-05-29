namespace MalusAdmin.Common;
 

public interface ITokenService
{
    /// <summary>
    /// 生成token
    /// </summary>
    /// <param name="tokenData"></param>
    /// <returns></returns>
    Task<string> GenerateTokenAsync(TokenData tokenData); 
}