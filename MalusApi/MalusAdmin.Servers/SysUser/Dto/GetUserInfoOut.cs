using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Servers
{
    public class GetUserInfoOut
    {

        public List<string> buttons { get; set; }

        public List<string> roles { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }

    }
}
