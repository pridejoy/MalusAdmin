using MalusAdmin.Servers;

namespace MalusAdmin.Servers;

/// <summary>
/// 日志服务接口
/// </summary>
public interface ISysLogService
{
    /// <summary>
    /// 添加系统操作日志
    /// </summary>
    /// <param name="type">日志类型</param>
    /// <param name="Message">日志消息</param>
    /// <returns></returns>
    Task AddLog(string type, string Message);

    /// <summary>
    /// 获取访问日志分页列表
    /// </summary>
    /// <param name="input">分页输入参数</param>
    /// <returns></returns>
    Task<PageList<TSysLogVis>> VisPageList(SysLogPageIn input);

    /// <summary>
    /// 获取异常日志分页列表
    /// </summary>
    /// <param name="input">分页输入参数</param>
    /// <returns></returns>
    Task<PageList<TSysLogErr>> ErrPageList(SysLogPageIn input);

    /// <summary>
    /// 获取操作日志分页列表
    /// </summary>
    /// <param name="input">分页输入参数</param>
    /// <returns></returns>
    Task<PageList<TSysLogOp>> OpPageList(SysLogPageIn input);
}
