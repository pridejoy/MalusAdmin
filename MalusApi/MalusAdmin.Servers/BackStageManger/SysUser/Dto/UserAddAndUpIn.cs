namespace MalusAdmin.Servers.SysUser.Dto;

public class UserAddAndUpIn
{
    /// <summary>
    ///     用户主键
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    ///     登录账号
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    ///     用户名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     密码
    /// </summary>
    public string PassWord { get; set; }


    /// <summary>
    ///     角色ID
    /// </summary>
    public List<int> UserRolesId { get; set; }

    /// <summary>
    ///     状态(10正常，00冻结)
    ///     默认值:10
    /// </summary>
    public int Status { get; set; }

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

    /// <summary>
    ///     备注
    /// </summary>
    public string Remark { get; set; }
}