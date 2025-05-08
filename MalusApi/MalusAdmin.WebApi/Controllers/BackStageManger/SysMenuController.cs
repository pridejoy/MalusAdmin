using MalusAdmin.Servers;
using MalusAdmin.Servers.SysMenu;

namespace MalusAdmin.WebApi.Controllers.BackStageManger;

/// <summary>
/// 菜单服务
/// </summary>
[ApiExplorerSettings(GroupName = "后台管理")]
public class SysMenuController : ApiControllerBase
{
    private readonly ISysMenuService _service;

    public SysMenuController(ISysMenuService service)
    {
        _service = service;
    }


    /// <summary>
    /// 分页查询
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("菜单树状列表")]
    public async Task<dynamic> MenuTreeList()
    {
        return await _service.MenuTreeList();
    }


    [ReadOnly]
    [HttpPost]
    [Permission("菜单新增")]
    public async Task<bool> Add(MenuAddandUpIn input)
    {
        return await _service.Add(input);
    }


    [HttpPost]
    [Permission("菜单更新")]
    [ReadOnly]
    public async Task<bool> Update(MenuAddandUpIn input)
    {
        return await _service.Update(input);
    }

    [ReadOnly]
    [HttpGet]
    [Permission("菜单删除")]
    public async Task<bool> Delete(int id)
    {
        return await _service.Delete(id);
    }
}