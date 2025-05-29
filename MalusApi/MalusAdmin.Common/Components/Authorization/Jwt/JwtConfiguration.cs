using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace MalusAdmin.Common
{ 

    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public string Audience { get; set; }
        public int ExpireDays { get; set; }
    }
}
