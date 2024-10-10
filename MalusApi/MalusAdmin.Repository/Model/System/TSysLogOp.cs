using System.ComponentModel;
using SqlSugar;

namespace MalusAdmin.Repository.Model;
/// <summary>
///     操作日志表
/// </summary>
[SplitTable(SplitType.Month)]
[SugarTable("sys_log_op_{year}{month}{day}")]
[Description("操作日志表")]
public class TSysLogOp
{
    /// <summary>
    ///     主键Id
    /// </summary>
    [SugarColumn(ColumnDescription = "Id主键", IsPrimaryKey = true)]
    public long Id { get; set; }

    /// <summary>
    ///     日志类型
    /// </summary>
    [SugarColumn(Length = 100)]
    public string LogType { get; set; }


    /// <summary>
    ///     日志详情
    /// </summary>
    [SugarColumn(Length = int.MaxValue)]
    public string Message { get; set; }


    /// <summary>
    ///     日志时间
    /// </summary>
    [SugarColumn(IsNullable = true)]
    public DateTime LogDateTime { get; set; } = DateTime.Now;
}