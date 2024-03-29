using System.Security.Claims;

public interface IPermissionChecker
{
    /// <summary>
    /// 异步检查指定名称的权限是否已授予给指定用户主体。
    /// </summary>
    /// <param name="claimsPrincipal">用户主体。</param>
    /// <param name="name">权限名称。</param>
    /// <returns>表示异步操作的任务，任务结果为 true 表示权限已授予，否则为 false。</returns>
    Task<bool> IsGrantedAsync(ClaimsPrincipal claimsPrincipal, string name);
}
