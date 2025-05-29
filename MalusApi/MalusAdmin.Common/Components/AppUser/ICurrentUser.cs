using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;

/// <summary>
/// 当前用户
/// </summary>
public interface ICurrentUser
{
     int UserId { get;  }

     string UserName { get;  }

     string UserAccount { get;  }

     bool IsSuperAdmin { get;  }

     List<int> UserRolesId { get;  }

     //List<string> UserPermiss { get;  }

     //DateTime? LoginTime { get;  } 

}
