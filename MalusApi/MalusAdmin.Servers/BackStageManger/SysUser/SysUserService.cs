using System.Collections.Generic;
using System.Linq.Expressions;
using MalusAdmin.Common;
using MalusAdmin.Common.Constant; 
using MalusAdmin.Servers.SysRoleMenu;
using MalusAdmin.Servers.SysUser;
using MalusAdmin.Servers.SysUser.Dto; 
using Mapster;

namespace MalusAdmin.Servers;

/// <summary>
/// 用户服务
/// </summary>
[ApiExplorerSettings(GroupName = nameof(ApiVersionGropInfo.BackStageManger))]
public class SysUserService : ApiControllerBase, ISysUserService
{
    private readonly IHttpContextAccessor _HttpContext;
    private readonly ISysLogService _sysLogService;
    private readonly ISysMenuService _sysMenuService;
    private readonly ISysRoleMenuService _sysRoleMenuService;
    private readonly ISysRolePermissionService _sysRolePermissionService;
    private readonly SqlSugarRepository<TSysUser> _sysUserRep; // 仓储
    private readonly ITokenService _TokenService;
    private readonly Common.ICacheService _cacheService;

    public SysUserService(SqlSugarRepository<TSysUser> sysUserRep,
        ITokenService tokenService, ISysRoleMenuService sysRoleMenuService,
        ISysMenuService sysMenuService, ISysRolePermissionService sysRolePermissionService,
        ISysLogService sysLogService, Common.ICacheService cacheService,
        IHttpContextAccessor httpContext)
    {
        _sysUserRep = sysUserRep;
        _sysLogService = sysLogService;
        _TokenService = tokenService;
        _HttpContext = httpContext;
        _sysRoleMenuService = sysRoleMenuService;
        _sysMenuService = sysMenuService;
        _sysRolePermissionService = sysRolePermissionService;
        _cacheService = cacheService;
    }

    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<SysUserLoginOut> Login(SysUserLoginIn input)
    { 
        var user = await _sysUserRep
            .Where(t => t.Account.ToLower() == input.Account.ToLower()).FirstAsync();
        if (user == null) throw ApiException.Exception207Bad("未找到用户");

        if (user.PassWord != Md5Util.Encrypt(input.PassWord).ToUpper()) throw ApiException.Exception207Bad("密码输入错误");
        if (user.Status != 1) throw ApiException.Exception207Bad("该账户已被冻结");

        var UserRolePer = new List<TSysRolePermission>();
        user.UserRolesId.ForEach(x =>
        {
            UserRolePer.AddRange(_sysRolePermissionService.GetRoleButtonPermiss(x).Result);
        });

        var button = UserRolePer.DistinctBy(x => x.UserPermiss).Select(x => x.UserPermiss).ToList();

        if (user.IsSuperAdmin)
            button = _sysRolePermissionService.GetAllButen().Result.Select(x => x.PermissionId).ToList();

        //缓存当前用户的菜单
        App.Cache.Set(CacheConstant.UserButton+ user.Id, button); 
         
        var token = await _TokenService.GenerateTokenAsync(new TokenData { 
            UserAccount = user.Account,
            UserId= user.Id, 
            UserRolesId = user.UserRolesId,
            UserName = user.Name,
            UserPermiss = button ,
            IsSuperAdmin=user.IsSuperAdmin
        }); 

        //await _sysLogService.AddLog("后台日志", $"用户{user.Name}登录了系统");

        return new SysUserLoginOut { Id = user.Id, Name = user.Name, Token = token };
    }

    /// <summary>
    /// 获取用户的信息
    /// </summary>
    /// <returns></returns>
    public async Task<GetUserInfoOut> GetUserInfo()
    { 
        var userinfo= await _sysUserRep
            .Where(t => t.Id== App.CurrentUser.UserId).FirstAsync();
        if (userinfo is null)
        {
            throw ApiException.Exception401("请重新登录");
        }

        var otherButton = new List<string>() 
        {
            //"api:Syslogin:ResetPassword",//修改密码的权限
        };
        var userButton = await _sysRolePermissionService.GetUserPermiss(userinfo.Id);
        return new GetUserInfoOut
        {
            userId = userinfo.Id,
            userName = userinfo.Name,
            roles = userinfo.UserRolesId.Select(x => x.ToString()).ToList(),
            buttons = otherButton.Concat(userButton).ToList(),
            userInfo= userinfo.Adapt<SysUserInfo>()
        };
    }



    /// <summary>
    /// 更改用户信息
    /// </summary>
    /// <returns></returns>
    public async Task<bool> UpdateUserInfo(SysUserInfo input)
    { 
        var entity = input.Adapt<TSysUser>(); 
        return await  _sysUserRep.Context.Updateable<TSysUser>(entity)
            .UpdateColumns(x=> new { x.Name,x.Remark,x.Tel,x.Email} )
            .Where(x => x.Id == App.CurrentUser.UserId).ExecuteCommandAsync()>0;
        //return await _sysUserRep.UpdateAsync(content).where >0; 
    }

    /// <summary>
    /// 更改密码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> ResetPassWord(ResetPassWord input)
    { 
        var user = await _sysUserRep.Where(x => x.Id == App.CurrentUser.UserId).FirstAsync();
        if (user == null) throw ApiException.Exception207Bad("未找到用户");

        if (user.PassWord != Md5Util.Encrypt(input.OldPassWord).ToUpper()) throw ApiException.Exception207Bad("旧密码不正确");
        if (user.PassWord == Md5Util.Encrypt(input.NewPassWord).ToUpper()) throw ApiException.Exception207Bad("旧密码不能与新密码相同");
        user.PassWord = Md5Util.Encrypt(input.NewPassWord);
        return await _sysUserRep.UpdateAsync(user) > 0; 
    }

    /// <summary>
    /// 用户列表分页
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [Permission("用户信息分页查询")]
    public async Task<PageList<TSysUser>> PageList([FromQuery] UserPageIn input)
    {
        var dictTypes = await _sysUserRep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.KeyWord), u => u.Name.Contains(input.KeyWord.Trim()))
            .WhereIF(input.Status != null, u => u.Status == input.Status)
            //.Select<UserPageOut>()
            .ToPagedListAsync(input.PageNo, input.PageSize);
        return dictTypes.PagedResult();
    }

    /// <summary>
    /// 添加用户
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("用户信息添加")]
    public async Task<bool> Add(UserAddAndUpIn input)
    {
        var isExist = await _sysUserRep.Where(x => x.Account == input.Account).AnyAsync();
        if (isExist) throw ApiException.Exception207Bad("已存在当前账号");
        var entity = input.Adapt<TSysUser>();
        entity.PassWord = Md5Util.Encrypt(input.PassWord);
        return await _sysUserRep.InsertReturnIdentityAsync(entity) > 0;
    }


    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [HttpPost("{userId}")]
    [Permission("用户信息删除")]
    [ReadOnly]
    public async Task<bool> Delete(int userId)
    {
        var entity = await _sysUserRep.FirstOrDefaultAsync(u => u.Id == userId);
        if (entity == null) throw ApiException.Exception207Bad("未找到当前账号");
        entity.SysIsDelete = true;
        //Todo 删除用户缓存

        return await _sysUserRep.UpdateAsync(entity) > 0;
    }

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [Permission("用户信息更新")]
    [ReadOnly]
    public async Task<bool> Update(UserAddAndUpIn input)
    {
        var entity = await _sysUserRep.FirstOrDefaultAsync(u => u.Id == input.Id);
        if (entity == null) throw ApiException.Exception207Bad("未找到当前账号");
        //Todo 更新用户缓存
        //优化  更新的字段

        var sysUser = input.Adapt<TSysUser>();
        return await _sysUserRep.AsUpdateable(sysUser).IgnoreColumns(true).ExecuteCommandAsync() > 0;
    }


    /// <summary>
    /// 获取登录用户的菜单权限
    /// </summary>
    /// <returns></returns>
    public async Task<UserMenuOut> GetUserMenu()
    {
 
        //缓存
        var cache_user_menus = _cacheService.Get<UserMenuOut>(CacheConstant.UserMenus+ App.CurrentUser.UserId);
        if (cache_user_menus == null)
        {
            var userMenuOut = new UserMenuOut();
        
            ////获取当前用户的菜单权限
            var menuid = await _sysRoleMenuService.RoleUserMenu(App.CurrentUser.UserRolesId);

            //获取所有的菜单权限
            var menutree = _sysUserRep.Context.Queryable<TSysMenu>()
                .ToTree(x => x.Children, x => x.ParentId, 0, menuid.Select(x => (object)x).ToArray());

            //超级管理官
            if (App.CurrentUser.IsSuperAdmin)
                menutree = _sysUserRep.Context.Queryable<TSysMenu>()
                    .ToTree(x => x.Children, x => x.ParentId, 0);
            var res = new List<UserMenu>();
            //var usermenus = GetMenusByIds(menutree, menuid);
            foreach (var item in menutree) res.Add(ConvertMenu(item));

            //List直接构造树 要高版本sqlsugar
            //var a = UtilMethods.BuildTree(_sysUserRep.Context, menutree, "Id", "ParentId", "Children", 0);

            userMenuOut.Home = res.FirstOrDefault()?.Name;
            userMenuOut.Routes = res;
            //进行缓存
            _cacheService.Set(CacheConstant.UserMenus + App.CurrentUser.UserId, userMenuOut, 60*60*60);
            return userMenuOut;
        }
        return cache_user_menus;




    }


    /// <summary>
    /// 私有方法，转化前端路由
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
                Order = menu.Sort,
                HideInMenu = menu.HideInMenu,
                Href = menu.Href
            },
            Children = menu.Children?.Select(ConvertMenu).ToList()
        };
    }

    /// <summary>
    /// 私有方法.获取当前角色的路由
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