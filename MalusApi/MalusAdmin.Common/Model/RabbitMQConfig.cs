using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Common
{
    public class RabbitMQConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }

        public string Password { get; set; } 

        public string Virtualhost { get; set; } 


    }
}
