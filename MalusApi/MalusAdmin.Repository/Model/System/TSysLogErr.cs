using SqlSugar;

namespace MalusAdmin.Repository.Model;

/// <summary>
///     操作日志表
/// </summary>
[SplitTable(SplitType.Month)]
[SugarTable("sys_log_err_{year}{month}{day}")]
public class TSysLogErr
{
    /// <summary>
    ///     主键Id
    /// </summary>
    [SugarColumn(ColumnDescription = "Id主键", IsPrimaryKey = true)]
    public virtual long Id { get; set; }

    /// <summary>
    ///     异常类型
    /// </summary>
    [SugarColumn(Length = 100)]
    public string ExceptionType { get; set; }

    /// <summary>
    ///操作方法名称
    /// </summary>
    [SugarColumn(Length = 100)]
    public string ActionName { get; set; }


    /// <summary>
    ///日志消息
    /// </summary> 
    public string Message { get; set; }


    /// <summary>
    ///日志时间
    /// </summary>
    [SugarColumn(IsNullable = true)]
    public DateTime LogDateTime { get; set; } = DateTime.Now;
}