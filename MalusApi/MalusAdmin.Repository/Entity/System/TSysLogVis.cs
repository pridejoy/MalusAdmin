using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace Models;

/// <summary>
///操作日志表
/// </summary>
[SplitTable(SplitType.Month)]
[SugarTable("sys_log_op_{year}{month}{day}")]
[Description("操作日志表")]
public class TSysLogVis
{
    /// <summary>
    ///主键Id
    /// </summary>
    [SugarColumn(ColumnDescription = "Id主键", IsPrimaryKey = true)]
    public virtual long Id { get; set; }

    /// <summary>
    ///名称
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(100)", IsNullable = true)]
    public string Name { get; set; }

    /// <summary>
    ///是否执行成功（Y-是，N-否）
    /// </summary>
    [SugarColumn(IsNullable = true)]
    public bool Success { get; set; }

    /// <summary>
    ///具体消息
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(5000)", IsNullable = true)]
    public string Message { get; set; }

    /// <summary>
    /// IP
    /// </summary>
    [MaxLength(20)]
    [SugarColumn(IsNullable = true)]
    public string Ip { get; set; }

    /// <summary>
    ///地址
    /// </summary>
    //[MaxLength(500)]
    [SugarColumn(IsNullable = true)]
    public string Location { get; set; }

    /// <summary>
    ///浏览器
    /// </summary>
    [MaxLength(100)]
    [SugarColumn(IsNullable = true)]
    public string Browser { get; set; }

    /// <summary>
    ///操作系统
    /// </summary>
    [MaxLength(500)]
    [SugarColumn(IsNullable = true)]
    public string Os { get; set; }

    /// <summary>
    ///请求地址
    /// </summary>
    //[MaxLength(100)]
    [SugarColumn(IsNullable = true)]
    public string Url { get; set; }

    /// <summary>
    ///类名称
    /// </summary>
    [MaxLength(100)]
    [SugarColumn(IsNullable = true)]
    public string ClassName { get; set; }

    /// <summary>
    ///方法名称
    /// </summary>
    [MaxLength(100)]
    [SugarColumn(IsNullable = true)]
    public string MethodName { get; set; }

    /// <summary>
    ///请求方式（GET POST PUT DELETE)
    /// </summary>
    [MaxLength(10)]
    [SugarColumn(IsNullable = true)]
    public string ReqMethod { get; set; }

    /// <summary>
    ///请求参数
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(5000)", IsNullable = true)]
    public string Param { get; set; }

    /// <summary>
    ///返回结果
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(5000)", IsNullable = true)]
    public string Result { get; set; }

    /// <summary>
    ///耗时（毫秒）
    /// </summary>
    public long ElapsedTime { get; set; }

    /// <summary>
    ///操作时间
    /// </summary>
    [SplitField] //分表字段 在插入的时候会根据这个字段插入哪个表，在更新删除的时候用这个字段找出相关表
    [SugarColumn(IsNullable = true)]
    public DateTime OpTime { get; set; }

    /// <summary>
    ///操作人
    /// </summary>
    [MaxLength(20)]
    [SugarColumn(IsNullable = true)]
    public string Account { get; set; }
} 