using MalusAdmin.Servers.SysUserButtonPermiss.Dto;

namespace MalusAdmin.Servers;

public interface ISysRolePermission
{
    Task<bool> HasPermissionAsync(string RouthPath);

    Task<List<string>> GetUserPermiss(int userid);

    Task<List<AllButtonPermissOut>> GetAllButen();
}