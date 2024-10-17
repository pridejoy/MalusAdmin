namespace MalusAdmin.Servers.SysUser.Dto;

public class UserMenu
{
    /// <summary>
    /// 名字
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 路由路径
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// 组件
    /// </summary>
    public string Component { get; set; }

    /// <summary>
    /// </summary>
    public Meta Meta { get; set; }

    public List<UserMenu> Children { get; set; }
}

/// <summary>
/// </summary>
public class Meta
{
    public string Title { get; set; }

    /// <summary>
    /// 图标
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// 路由排序顺序
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// 是否在菜单中隐藏该路由
    /// </summary>
    public bool HideInMenu { get; set; }

    /// <summary>
    /// 路由的外部链接
    /// </summary>
    public string Href { get; set; }
}

public class UserMenuOut
{
    public string Home { get; set; }

    public List<UserMenu> Routes { get; set; }
}