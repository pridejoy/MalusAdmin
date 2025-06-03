using MalusAdmin.Servers.SysMenu;
using MalusAdmin.Servers.SysRole;
using Mapster;

namespace MalusAdmin.Servers;

/// <summary>
/// 菜单服务
/// </summary>
[ApiExplorerSettings(GroupName = nameof(ApiVersionGropInfo.BackStageManger))]

public class SysMenuService : ApiControllerBase, ISysMenuService
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
    [HttpGet]
    [Permission("菜单树状列表")]
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
    [ReadOnly]
    [HttpPost]
    [Permission("菜单新增")]
    public async Task<bool> Add(MenuAddandUpIn input)
    {
        var isExist = await _sysMenuRep.Where(x => x.RoutePath == input.RoutePath ||
                                                   x.RouteName == input.RouteName || x.MenuName == input.RouteName)
            .AnyAsync();
        if (isExist) throw ApiException.Exception207Bad("当前菜单已存在");
        var entity = input.Adapt<TSysMenu>();
        return await _sysMenuRep.InsertReturnIdentityAsync(entity) > 0;
    }


    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [ReadOnly]
    [HttpGet]
    [Permission("菜单删除")]
    public async Task<bool> Delete(int id)
    {
        var entity = await _sysMenuRep.FirstOrDefaultAsync(u => u.Id == id);
        if (entity == null) throw ApiException.Exception207Bad("未找到当前菜单");
        entity.SysIsDelete = true;
        return await _sysMenuRep.UpdateAsync(entity) > 0;
    }

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [Permission("菜单更新")]
    [ReadOnly]
    public async Task<bool> Update(MenuAddandUpIn input)
    {
        var entity = await _sysMenuRep.FirstOrDefaultAsync(u => u.Id == input.Id);
        if (entity == null) throw ApiException.Exception207Bad("未找到当前账号");

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