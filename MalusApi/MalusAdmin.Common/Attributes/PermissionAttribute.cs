namespace MalusAdmin.Common;

/// <summary>
///接口按钮特性，映射到按钮权限
/// </summary>
public class PermissionAttribute : Attribute
{
    public PermissionAttribute(string permissionName)
    {
        PermissionName = permissionName;
    }

    public string PermissionName { get; private set; }
}