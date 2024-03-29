using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace MalusAdmin.Common
{
    /// <summary>
    /// MemoryCache缓存操作
    /// </summary>
    public class MemoryCacheService : ICacheService
    {
        readonly IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        public bool Add(string key, object value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            _cache.Set(key, value);
            return Exists(key);
        }

        public bool Add(string key, object value, TimeSpan expiresTime)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            _cache.Set(key, value, expiresTime);
            return Exists(key);
        }
        public bool AddSlide(string key, object value, TimeSpan expiresTime)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            _cache.Set(key, value, new MemoryCacheEntryOptions { SlidingExpiration = expiresTime });
            return Exists(key);
        }

        public bool Exists(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.TryGetValue(key, out _);
        }

        public T Get<T>(string key) where T : class
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.Get<T>(key);
        }

        public object Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.Get(key);
        }

        public IDictionary<string, object> GetList(List<string> keys)
        {
            if (keys == null || keys.Count == 0)
            {
                throw new ArgumentNullException(nameof(keys));
            }
            var dict = new Dictionary<string, object>();

            keys.ForEach(item => dict.Add(item, _cache.Get(item)));

            return dict;
        }

        public bool Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            _cache.Remove(key);
            return !Exists(key);
        }

        public bool RemoveList(List<string> keys)
        {
            if (keys == null || keys.Count == 0)
            {
                throw new ArgumentNullException(nameof(keys));
            }
            keys.ForEach(item => Remove(item));
            return keys.FindAll(item => !Exists(item)).Count == 0;
        }
        public void Dispose()
        {
            _cache?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
