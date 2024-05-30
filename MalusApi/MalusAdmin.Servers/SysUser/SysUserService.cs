using MalusAdmin.Common.Components.Token;
using MalusAdmin.Servers.SysRoleMenu;
using MalusAdmin.Servers.SysUser;
using MalusAdmin.Servers.SysUser.Dto;
using MalusAdmin.Servers.SysUserButtonPermiss;
using Mapster;

namespace MalusAdmin.Servers;

public class SysUserService : ISysUserService
{
    private readonly IHttpContextAccessor _HttpContext;
    private readonly SysMenuService _sysMenuService;
    private readonly SysRoleMenuService _sysRoleMenuService;
    private readonly SysRolePermissionService _sysRolePermissionService;
    private readonly SqlSugarRepository<TSysUser> _sysUserRep; // 仓储
    private readonly ITokenService _TokenService;

    public SysUserService(SqlSugarRepository<TSysUser> sysUserRep,
        ITokenService tokenService, SysRoleMenuService sysRoleMenuService,
        SysMenuService sysMenuService, SysRolePermissionService sysRolePermissionService,
        IHttpContextAccessor httpContext)
    {
        _sysUserRep = sysUserRep;
        _TokenService = tokenService;
        _HttpContext = httpContext;
        _sysRoleMenuService = sysRoleMenuService;
        _sysMenuService = sysMenuService;
        _sysRolePermissionService = sysRolePermissionService;
    }

    /// <summary>
    ///     用户登录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<SysUserLoginOut> Login(SysUserLoginIn input)
    {
        var user = await _sysUserRep
            .Where(t => t.Account.ToLower() == input.Account.ToLower()).FirstAsync();
        if (user == null) throw new Exception("未找到用户");

        if (user.PassWord != Md5Util.Encrypt(input.PassWord).ToUpper()) throw new Exception("密码输入错误");
        if (user.Status != 1) throw new Exception("该账户已被冻结");

        var UserRolePer = new List<TSysRolePermission>();
        user.UserRolesId.ForEach(x =>
        {
            UserRolePer.AddRange(_sysRolePermissionService.GetRoleButtonPermiss(x).Result);
        });
        var button = UserRolePer.DistinctBy(x => x.UserPermiss).Select(x => x.UserPermiss).ToList();

        if (user.IsSuperAdmin)
            button = _sysRolePermissionService.GetAllButen().Result.Select(x => x.PermissionId).ToList();

        var tokenData = new TokenData
        {
            UserId = user.Id,
            UserName = user.Name,
            UserAccount = user.Account,
            UserRolesId = user.UserRolesId,
            IsSuperAdmin = user.IsSuperAdmin,
            UserPermiss = button
        };

        //_TokenService.RemoveCheckToken(tokenData.UserId);
        var UserToken = _TokenService.GenerateToken(tokenData);


        return new SysUserLoginOut { Id = user.Id, Name = user.Name, Token = UserToken };
    }

    /// <summary>
    ///     获取用户的信息
    /// </summary>
    /// <returns></returns>
    public async Task<GetUserInfoOut> GetUserInfo()
    {
        return new GetUserInfoOut
        {
            userId = TokenInfo.User.UserId,
            userName = TokenInfo.User.UserName,
            roles = TokenInfo.User.UserRolesId.Select(x => x.ToString()).ToList(),
            buttons = TokenInfo.User.UserPermiss
        };
    }


    /// <summary>
    ///     用户列表分页
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PageList<TSysUser>> PageList(UserPageIn input)
    {
        var dictTypes = await _sysUserRep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.KeyWord), u => u.Name.Contains(input.KeyWord.Trim()))
            .WhereIF(input.Status != null, u => u.Status == input.Status)
            //.Select<UserPageOut>()
            .ToPagedListAsync(input.PageNo, input.PageSize);
        return dictTypes.PagedResult();
    }

    /// <summary>
    ///     添加用户
    /// </summary>
    /// <returns></returns>
    public async Task<bool> Add(UserAddAndUpIn input)
    {
        var isExist = await _sysUserRep.Where(x => x.Account == input.Account).AnyAsync();
        if (isExist) ResultCode.Fail.JsonR("已存在当前账号");
        var entity = input.Adapt<TSysUser>();
        entity.PassWord = Md5Util.Encrypt(input.PassWord);
        return await _sysUserRep.InsertReturnIdentityAsync(entity) > 0;
    }


    /// <summary>
    ///     删除用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(int userId)
    {
        var entity = await _sysUserRep.FirstOrDefaultAsync(u => u.Id == userId);
        if (entity == null) ResultCode.Fail.JsonR("为找到当前账号");
        entity.SysIsDelete = true;
        return await _sysUserRep.UpdateAsync(entity) > 0;
    }

    /// <summary>
    ///     更新用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(UserAddAndUpIn input)
    {
        var entity = await _sysUserRep.FirstOrDefaultAsync(u => u.Id == input.Id);
        if (entity == null) ResultCode.Fail.JsonR("为找到当前账号");

        var sysUser = input.Adapt<TSysUser>();
        return await _sysUserRep.AsUpdateable(sysUser).IgnoreColumns(true).ExecuteCommandAsync() > 0;
    }


    /// <summary>
    ///     获取登录用户的菜单权限
    /// </summary>
    /// <returns></returns>
    public async Task<UserMenuOut> GetUserMenu()
    {
        var Out = new UserMenuOut();

        ////获取当前用户的菜单权限
        var menuid = await _sysRoleMenuService.RoleUserMenu(TokenInfo.User.UserRolesId);

        //获取所有的菜单权限
        var menutree = _sysUserRep.Context.Queryable<TSysMenu>()
            .ToTree(x => x.Children, x => x.ParentId, 0, menuid.Select(x => (object)x).ToArray());

        //超级管理官
        if (TokenInfo.User.IsSuperAdmin)
            menutree = _sysUserRep.Context.Queryable<TSysMenu>()
                .ToTree(x => x.Children, x => x.ParentId, 0);
        var res = new List<UserMenu>();
        //var usermenus = GetMenusByIds(menutree, menuid);
        foreach (var item in menutree) res.Add(ConvertMenu(item));
        Out.Home = res.FirstOrDefault()?.Name;
        Out.Routes = res;

        return Out;
    }

    /// <summary>
    ///     私有方法，转化前端路由
    /// </summary>
    /// <param name="menu"></param>
    /// <returns></returns>
    private UserMenu ConvertMenu(TSysMenu menu)
    {
        return new UserMenu
        {
            Name = menu.RouteName,
            Path = menu.RoutePath,
            Component = menu.Component,
            Meta = new Meta
            {
                Title = menu.MenuName,
                Icon = menu.Icon,
                Order = menu.Sort
            },
            Children = menu.Children?.Select(ConvertMenu).ToList()
        };
    }

    /// <summary>
    ///     私有方法.获取当前角色的路由
    /// </summary>
    /// <param name="menutree"></param>
    /// <param name="menuid"></param>
    /// <returns></returns>
    private IEnumerable<TSysMenu> GetMenusByIds(List<TSysMenu> menutree, List<int> menuid)
    {
        var userMenus = new List<TSysMenu>(); // 存储用户有权限的菜单

        // 定义递归方法
        void RecurseTree(List<TSysMenu> tree, List<int> ids)
        {
            foreach (var node in tree)
            {
                // 如果当前节点的id在用户权限列表中，则添加到结果
                if (ids.Contains(node.Id)) userMenus.Add(node);

                // 如果有子节点，则递归调用
                if (node.Children != null && node.Children.Any()) RecurseTree(node.Children, ids);
            }
        }

        // 调用递归方法
        RecurseTree(menutree, menuid);

        return userMenus;
    }
}