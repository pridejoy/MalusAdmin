namespace MalusAdmin.Servers.SysRoleMenu.Dto;

/// <summary>
///     用户菜单更新
/// </summary>
public class UpdateRoleUserMenuIn
{
    public int RoleId { get; set; }


    public List<int> MenuId { get; set; }
}