namespace MalusAdmin.Common;



/// <summary>
/// redis 存放的数据
/// </summary>
public class TokenData
{
    public int UserId { get; set; }

    public string UserName { get; set; }

    public string UserAccount { get; set; }

    public bool IsSuperAdmin { get; set; }

    public List<int> UserRolesId { get; set; }

    public List<string> UserPermiss { get; set; }

    public DateTime? LoginTime { get; set; } 
}