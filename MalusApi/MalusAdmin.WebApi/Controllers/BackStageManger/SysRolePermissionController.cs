using MalusAdmin.Servers;
using MalusAdmin.Servers.SysRolePermission.Dto;

namespace MalusAdmin.WebApi.Controllers.BackStageManger;

/// <summary>
///     按钮权限服务
/// </summary>
[ApiExplorerSettings(GroupName = "后台管理")]
public class SysRolePermissionController : ApiControllerBase
{
    private readonly SysRolePermissionService _service;

    public SysRolePermissionController(SysRolePermissionService service)
    {
        _service = service;
    }


    /// <summary>
    ///     获取所有按钮列表
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<dynamic> GetAllButen()
    {
        return await _service.GetAllButen();
    }


    /// <summary>
    ///     获取角色按钮
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("获取角色按钮")]
    public async Task<dynamic> GetRoleButen(int RoleId)
    {
        return await _service.GetRoleButtonPermiss(RoleId);
    }

    /// <summary>
    ///     设置角色按钮
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("设置角色按钮")]
    [ReadOnly]
    public async Task<bool> AddUserButtonPermiss(UpdateRoleButtonIn Input)
    {
        return await _service.AddRoleButtonPermiss(Input);
    }
}