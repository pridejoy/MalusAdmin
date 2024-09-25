//using MalusAdmin.Server;
//using MalusAdmin.Servers;

///// <summary>
///// 配置管理
///// </summary>
//[ApiExplorerSettings(GroupName = "后台业务")]
//public class BsWechatConfigController : ApiControllerBase
//{
//    private readonly BsWechatConfigService _server;

//    public BsWechatConfigController(BsWechatConfigService server)
//    {
//        _server = server;
//    }

//    /// <summary>
//    /// 分页查询
//    /// </summary>
//    /// <returns></returns>
//    [HttpGet]
//    [Permission("配置分页查询")]
//    public async Task<JsonR> PageList([FromQuery] PageParamBase input)
//    {
//        return ResultCode.Success.JsonR(await _server.PageList(input));
//    }

//    /// <summary>
//    /// 添加配置
//    /// </summary>
//    /// <returns></returns>
//    [HttpPost]
//    [Permission("配置添加")]
//    public async Task<JsonR> Add(WechatConfigAddandUpIn input)
//    {
//        return ResultCode.Success.JsonR(await _server.Add(input));
//    }

//    /// <summary>
//    /// 删除配置
//    /// </summary>
//    /// <returns></returns>
//    [HttpPost("{id}")]
//    [Permission("配置删除")]
//    public async Task<JsonR> Delete(int id)
//    {
//        return ResultCode.Success.JsonR(await _server.Delete(id));
//    }

//    /// <summary>
//    /// 更新配置
//    /// </summary>
//    /// <returns></returns>
//    [HttpPost]
//    [Permission("配置更新")]
//    public async Task<JsonR> Update(WechatConfigAddandUpIn input)
//    {
//        return ResultCode.Success.JsonR(await _server.Update(input));
//    }
//}