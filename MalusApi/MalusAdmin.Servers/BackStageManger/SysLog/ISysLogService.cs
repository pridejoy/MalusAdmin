using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Servers.BackStageManger
{
    public interface ISysLogService
    {
        Task AddLog(string type, string Message);
    }
}
