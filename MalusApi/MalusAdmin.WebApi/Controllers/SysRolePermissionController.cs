using MalusAdmin.Servers.SysRolePermission.Dto;
using MalusAdmin.Servers.SysUserButtonPermiss;

namespace MalusAdmin.WebApi.Controllers;

/// <summary>
/// 按钮权限服务
/// </summary>
public class SysRolePermissionController : ApiControllerBase
{
    private readonly SysRolePermissionService _service;

    public SysRolePermissionController(SysRolePermissionService service)
    {
        _service = service;
    }


    /// <summary>
    /// 获取所有按钮列表
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<JsonR> GetAllButen()
    {
        return ResultCode.Success.JsonR(await _service.GetAllButen());
    }


    /// <summary>
    /// 获取角色按钮
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("获取角色按钮")]
    public async Task<JsonR> GetRoleButen(int RoleId)
    {
        return ResultCode.Success.JsonR(await _service.GetRoleButtonPermiss(RoleId));
    }

    /// <summary>
    /// 设置角色按钮
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("设置角色按钮")]
    [ReadOnly]
    public async Task<JsonR> AddUserButtonPermiss(UpdateRoleButtonIn Input)
    {
        return ResultCode.Success.JsonR(await _service.AddRoleButtonPermiss(Input));
    }
}