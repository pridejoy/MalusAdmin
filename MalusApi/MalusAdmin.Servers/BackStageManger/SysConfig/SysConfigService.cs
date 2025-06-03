using MalusAdmin.Servers;
using Mapster;

namespace MalusAdmin.Server;

/// <summary>
/// 配置服务
/// </summary>
[ApiExplorerSettings(GroupName = nameof(ApiVersionGropInfo.BackStageManger))]
public class SysConfigService : ApiControllerBase, ISysConfigService
{
    private readonly ISqlSugarClient _db;
    private readonly SqlSugarRepository<TBsSysConfig> _rep; // 仓储
    private readonly ITokenService _TokenService;

    public SysConfigService(SqlSugarRepository<TBsSysConfig> rep, ITokenService tokenService)
    {
        _rep = rep;
        _TokenService = tokenService;
    }

    /// <summary>
    /// 通过类型和key来返回配置值
    /// </summary>
    /// <param name="key"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [NonAction]
    public async Task<string> GetTypeKeyConfig(string key, string type)
    {
        var entity = await _rep.Where(x => x.ConfigKey == key && x.ConfigType == type).FirstAsync();
        return entity?.ConfigValue ?? "";
    }

    /// <summary>
    /// 配置分页
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [Permission("配置分页查询")]
    public async Task<PageList<TBsSysConfig>> PageList(PageParamBase input)
    {
        var dictTypes = await _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.KeyWord),
                u => u.ConfigKey.Contains(input.KeyWord.Trim()) || u.ConfigValue.Contains(input.KeyWord.Trim()))
            .Where(u => u.IsDeleted == false)
            .ToPagedListAsync(input.PageNo, input.PageSize);
        return dictTypes.PagedResult();
    }

    /// <summary>
    /// 添加配置
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("配置添加")]
    public async Task<bool> Add(WechatConfigAddandUpIn input)
    {
        var isExist = await _rep.Where(x => x.ConfigKey == input.ConfigKey).AnyAsync();
        if (isExist) throw new Exception("已存在当前配置");
        var entity = input.Adapt<TBsSysConfig>();
        entity.IsDeleted = false;
        return await _rep.InsertReturnIdentityAsync(entity) > 0;
    }

    /// <summary>
    /// 删除配置
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("{id}")]
    [Permission("配置删除")]
    public async Task<bool> Delete(int id)
    {
        var entity = await _rep.FirstOrDefaultAsync(u => u.ConfigID == id);
        if (entity == null) throw new Exception("为找到当前配置");
        return await _rep.DeleteAsync(u => u.ConfigID == id) > 0;
    }

    /// <summary>
    /// 更新配置
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [Permission("配置更新")]
    public async Task<bool> Update(WechatConfigAddandUpIn input)
    {
        var entity = await _rep.FirstOrDefaultAsync(u => u.ConfigID == input.ConfigID);
        if (entity == null) throw new Exception("未找到当前配置");
        var sysRole = input.Adapt<TBsSysConfig>();
        return await _rep.AsUpdateable(sysRole).IgnoreColumns(true).ExecuteCommandAsync() > 0;
    }
}