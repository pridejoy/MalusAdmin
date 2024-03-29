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
        public string UserAccount { get; set; }
        public int UserDept { get; set; }
        public int UserRole { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
