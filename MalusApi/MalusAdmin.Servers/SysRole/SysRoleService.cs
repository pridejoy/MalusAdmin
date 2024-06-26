using MalusAdmin.Servers.SysRole;
using MalusAdmin.Servers.SysUser.Dto;
using Mapster;

namespace MalusAdmin.Servers;

/// <summary>
/// 角色服务
/// </summary>
public class SysRoleService
{
    private readonly ISqlSugarClient _db;
    private readonly SqlSugarRepository<TSysRole> _sysRoleRep; // 仓储
    private readonly ITokenService _TokenService;

    public SysRoleService(SqlSugarRepository<TSysRole> sysUserRep, ITokenService tokenService)
    {
        _sysRoleRep = sysUserRep;
        _TokenService = tokenService;
    }


    /// <summary>
    /// 角色列表分页
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PageList<TSysRole>> PageList(UserPageIn input)
    {
        var dictTypes = await _sysRoleRep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.KeyWord),
                u => u.Name.Contains(input.KeyWord.Trim()) || u.Desc.Contains(input.KeyWord.Trim()))
            .WhereIF(input.Status != null, u => u.Status == input.Status)
            //.Select<UserPageOut>()
            .ToPagedListAsync(input.PageNo, input.PageSize);
        return dictTypes.PagedResult();
    }

    /// <summary>
    /// 添加角色
    /// </summary>
    /// <returns></returns>
    public async Task<bool> Add(RoleAddandUpIn input)
    {
        var isExist = await _sysRoleRep.Where(x => x.Name == input.Name).AnyAsync();
        if (isExist) throw new Exception("已存在当前角色");
        var entity = input.Adapt<TSysRole>();
        return await _sysRoleRep.InsertReturnIdentityAsync(entity) > 0;
    }


    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(int id)
    {
        var entity = await _sysRoleRep.FirstOrDefaultAsync(u => u.Id == id);
        if (entity == null) throw new Exception("未找到当前角色");
        entity.SysIsDelete = true;
        return await _sysRoleRep.UpdateAsync(entity) > 0;
    }

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(RoleAddandUpIn input)
    {
        var entity = await _sysRoleRep.FirstOrDefaultAsync(u => u.Id == input.Id);
        if (entity == null) throw new Exception("未找到当前账号");

        var sysRole = input.Adapt<TSysRole>();
        return await _sysRoleRep.AsUpdateable(sysRole).IgnoreColumns(true).ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 用户列表
    /// </summary>
    /// <returns></returns>
    public async Task<List<RoleListOut>> List()
    {
        var list = await _sysRoleRep.Context.Queryable<TSysRole>()
            .Select<RoleListOut>().ToListAsync();
        return list;
    }
}