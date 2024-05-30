using ICacheService = MalusAdmin.Common.ICacheService;

namespace MalusAdmin.Servers.SysOnlineUser;

/// <summary>
/// </summary>
public class SysOnlineUserService
{
    private readonly ICacheService _cacheService;

    public SysOnlineUserService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    // public async Task<PageList<dynamic>> OnlineUserPage()
    // {
    //    var userkey= await _cacheService.GetKeysByPatternAsync(Constant.Cache.OnlineUser);
    //    var list = _cacheService.get<OnlineUser>();
    //
    //     return "";
    // }
}