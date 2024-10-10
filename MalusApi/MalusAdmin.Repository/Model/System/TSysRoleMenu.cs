using SqlSugar;

namespace MalusAdmin.Repository.Model;

/// <summary>
///     角色菜单表
/// </summary>
[SugarTable("t_sys_role_menu")]
public class TSysRoleMenu : ModelBase
{
    /// <summary>
    ///     角色ID
    /// </summary>
    [SugarColumn(ColumnName = "RoleId", IsPrimaryKey = true, IsIdentity = true)]
    public int RoleId { get; set; }

    /// <summary>
    ///     菜单ID
    /// </summary>
    [SugarColumn(ColumnName = "MenuId")]
    public int MenuId { get; set; }
}