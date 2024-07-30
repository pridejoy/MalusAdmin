using MalusAdmin.Servers.SysMenu;
using MalusAdmin.Servers.SysRole;
using Mapster;

namespace MalusAdmin.Servers;

/// <summary>
/// 菜单服务
/// </summary>
public class SysMenuService
{
    private readonly ISqlSugarClient _db;
    private readonly SqlSugarRepository<TSysMenu> _sysMenuRep; // 仓储
    private readonly ITokenService _TokenService;

    public SysMenuService(SqlSugarRepository<TSysMenu> sysUserRep, ITokenService tokenService)
    {
        _sysMenuRep = sysUserRep;
        _TokenService = tokenService;
    }


    /// <summary>
    /// 菜单树状查询
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PageList<TSysMenu>> MenuTreeList()
    {
        var sysmenulist = await _sysMenuRep.Context.Queryable<TSysMenu>()
            .ToTreeAsync(x => x.Children, x => x.ParentId, 0);
        return new PageList<TSysMenu>
        {
            PageNo = 1,
            PageSize = 999,
            TotalPage = 1,
            TotalRows = sysmenulist.Count,
            Records = sysmenulist.OrderBy(x => x.Sort)
        };
    }


    /// <summary>
    /// 添加
    /// </summary>
    /// <returns></returns>
    public async Task<bool> Add(MenuAddandUpIn input)
    {
        var isExist = await _sysMenuRep.Where(x => x.MenuType == input.MenuType).AnyAsync();
        if (isExist) throw ResultHelper.Exception207Bad("已存在当前角色");
        var entity = input.Adapt<TSysMenu>();
        return await _sysMenuRep.InsertReturnIdentityAsync(entity) > 0;
    }


    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(int id)
    {
        var entity = await _sysMenuRep.FirstOrDefaultAsync(u => u.Id == id);
        if (entity == null) throw ResultHelper.Exception200OK("未找到当前菜单");
        entity.SysIsDelete = true;
        return await _sysMenuRep.UpdateAsync(entity) > 0;
    }

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(MenuAddandUpIn input)
    {
        var entity = await _sysMenuRep.FirstOrDefaultAsync(u => u.Id == input.Id);
        if (entity == null) throw ResultHelper.Exception200OK("未找到当前账号");

        var sysRole = input.Adapt<TSysMenu>();
        return await _sysMenuRep.AsUpdateable(sysRole).IgnoreColumns(true).ExecuteCommandAsync() > 0;
    }

    /// <summary>
    /// 用户菜单
    /// </summary>
    /// <returns></returns>
    public async Task<List<RoleListOut>> GetUserMenu()
    {
        var list = await _sysMenuRep.Context.Queryable<TSysRole>()
            .Select<RoleListOut>().ToListAsync();
        return list;
    }


    /// <summary>
    /// 全部菜单
    /// </summary>
    /// <returns></returns>
    public async Task<List<RoleListOut>> GetAllMenu()
    {
        var list = await _sysMenuRep.Context.Queryable<TSysRole>()
            .Select<RoleListOut>().ToListAsync();
        return list;
    }
}