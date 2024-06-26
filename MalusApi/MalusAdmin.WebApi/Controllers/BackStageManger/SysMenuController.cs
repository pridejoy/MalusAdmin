using MalusAdmin.Servers;
using MalusAdmin.Servers.SysMenu;

namespace MalusAdmin.WebApi.Controllers.BackStageManger;

/// <summary>
/// 菜单服务
/// </summary>
[ApiExplorerSettings(GroupName = "后台管理")]
public class SysMenuController : ApiControllerBase
{
    private readonly SysMenuService _service;

    public SysMenuController(SysMenuService service)
    {
        _service = service;
    }


    /// <summary>
    /// 分页查询
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("菜单树状列表")]
    public async Task<JsonR> MenuTreeList()
    {
        return ResultCode.Success.JsonR(await _service.MenuTreeList());
    }


    [ReadOnly]
    [HttpPost]
    [Permission("菜单新增")]
    public async Task<JsonR> Add(MenuAddandUpIn input)
    {
        return ResultCode.Success.JsonR(await _service.Add(input));
    }


    [HttpPost]
    [Permission("菜单更新")]
    [ReadOnly]
    public async Task<JsonR> Update(MenuAddandUpIn input)
    {
        return ResultCode.Success.JsonR(await _service.Update(input));
    }

    [ReadOnly]
    [HttpGet]
    [Permission("菜单删除")]
    public async Task<JsonR> Delete(int id)
    {
        return ResultCode.Success.JsonR(await _service.Delete(id));
    }
}