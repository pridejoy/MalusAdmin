using MalusAdmin.Server;
using MalusAdmin.Servers;

/// <summary>
///     参数配置管理
/// </summary>
[ApiExplorerSettings(GroupName = "后台管理")]
public class SysConfigController : ApiControllerBase
{
    private readonly SysConfigService _server;

    public SysConfigController(SysConfigService server)
    {
        _server = server;
    }

    /// <summary>
    ///     分页查询
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("配置分页查询")]
    public async Task<dynamic> PageList([FromQuery] PageParamBase input)
    {
        return await _server.PageList(input);
    }

    /// <summary>
    ///     添加配置
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("配置添加")]
    public async Task<bool> Add(WechatConfigAddandUpIn input)
    {
        return await _server.Add(input);
    }

    /// <summary>
    ///     删除配置
    /// </summary>
    /// <returns></returns>
    [HttpPost("{id}")]
    [Permission("配置删除")]
    public async Task<bool> Delete(int id)
    {
        return await _server.Delete(id);
    }

    /// <summary>
    ///     更新配置
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("配置更新")]
    public async Task<bool> Update(WechatConfigAddandUpIn input)
    {
        return await _server.Update(input);
    }
}