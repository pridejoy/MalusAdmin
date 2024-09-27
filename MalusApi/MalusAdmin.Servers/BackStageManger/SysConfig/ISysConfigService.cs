using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Servers
{
    /// <summary>
    /// 参数配置
    /// </summary>
    public interface  ISysConfigService
    {
        Task<string> GetTypeKeyConfig(string key,string type);
    }
}
