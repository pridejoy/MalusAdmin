namespace MalusAdmin.Servers;

 

/// <summary>
/// 参数配置服务接口
/// </summary>
public interface ISysConfigService
{
    /// <summary>
    /// 通过类型和key来返回配置值
    /// </summary>
    /// <param name="key">配置Key</param>
    /// <param name="type">配置类型</param>
    /// <returns></returns>
    Task<string> GetTypeKeyConfig(string key, string type);

    /// <summary>
    /// 配置分页
    /// </summary>
    /// <param name="input">分页参数</param>
    /// <returns></returns>
    Task<PageList<TBsSysConfig>> PageList(PageParamBase input);

    /// <summary>
    /// 添加配置
    /// </summary>
    /// <param name="input">配置输入参数</param>
    /// <returns></returns>
    Task<bool> Add(WechatConfigAddandUpIn input);

    /// <summary>
    /// 删除配置
    /// </summary>
    /// <param name="id">配置ID</param>
    /// <returns></returns>
    Task<bool> Delete(int id);

    /// <summary>
    /// 更新配置
    /// </summary>
    /// <param name="input">配置输入参数</param>
    /// <returns></returns>
    Task<bool> Update(WechatConfigAddandUpIn input);
}
