using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Common
{
    public class TokenData
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserAccount { get; set; } 

        public List<int> UserRolesId { get; set; }

        public DateTime? DateTime { get; set; }
    }
}
