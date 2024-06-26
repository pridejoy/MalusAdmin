namespace MalusAdmin.Servers.SysRole;

public class RoleAddandUpIn
{
    /// <summary>
    /// 主键
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 角色名称
    /// </summary>
    public string Name { get; set; }


    /// <summary>
    /// 描述
    /// </summary>
    public string Desc { get; set; }

    /// <summary>
    /// 是否启用
    /// 默认值:1
    /// </summary>
    public bool Status { get; set; }
}