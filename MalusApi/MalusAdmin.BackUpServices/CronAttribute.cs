using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.BackUpServices
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class CronAttribute: Attribute
    {
        public CronAttribute(string cron)
        {
            Cron = cron;
        }

        public string Cron { get;   }
    }
}
