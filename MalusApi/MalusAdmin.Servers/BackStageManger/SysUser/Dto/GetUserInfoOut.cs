namespace MalusAdmin.Servers;

public class GetUserInfoOut
{
    public List<string> buttons { get; set; }

    public List<string> roles { get; set; }

    public int userId { get; set; }

    public string userName { get; set; } 

    public SysUserInfo userInfo { get; set; }
}

public class SysUserInfo
{
    public string Name { get; set; }

    /// <summary>
    /// 电话
    /// </summary>
    [SugarColumn(ColumnName = "Tel")]
    public string Tel { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [SugarColumn(ColumnName = "Email")]
    public string Email { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnName = "Remark")]
    public string Remark { get; set; }
}