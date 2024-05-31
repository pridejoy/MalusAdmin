namespace MalusAdmin.Servers.SysUser.Dto;

public class UserPageOut
{
    public int id { get; set; }

    /// <summary>
    ///     登录账号
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    ///     用户名
    /// </summary>
    public string Name { get; set; }


    /// <summary>
    ///     状态(10正常，00冻结)
    ///     默认值:10
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    ///     头像
    /// </summary>
    public string Avatar { get; set; }

    /// <summary>
    ///     电话
    /// </summary>
    public string Tel { get; set; }

    /// <summary>
    ///     邮箱
    /// </summary>
    public string Email { get; set; }
}