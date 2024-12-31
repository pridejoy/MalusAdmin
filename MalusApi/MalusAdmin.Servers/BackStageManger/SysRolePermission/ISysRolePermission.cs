namespace MalusAdmin.Servers;

public interface ISysRolePermission
{
    Task<bool> HasPermissionAsync(string RouthPath);
}