using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Servers
{
    public class SysCacheService
    {
        private readonly Common.ICacheService _cacheService;
        public SysCacheService(Common.ICacheService cacheService) 
        {
            _cacheService = cacheService;
        }

        /// <summary>
        /// 获取所有缓存的key
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllKeys() 
        {  
           return _cacheService.GetAllKeys();
        }
         
        /// <summary>
        /// 根据key获取缓存的value
        /// </summary>
        /// <returns></returns>
        public dynamic GetKeys(string key)
        {
            return _cacheService.Get<dynamic>(key);
        }


        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <returns></returns>
        public async Task<long> RemoveAsync(string key)
        {
           return await _cacheService.RemoveAsync(key);
        }
    }
}
