using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTaste;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MalusAdmin.Common.Components.Cache
{
    public class RedisCacheService : ICacheService
    {
        readonly IDatabase _database;
        public RedisCacheService()
        {
            ConnectionMultiplexer redisConn = ConnectionMultiplexer.Connect(AppSettings.Redis.ConnectionString);
            _database = redisConn.GetDatabase();
        }
        public bool Add(string key, object value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _database.StringSet(key, value.ToJson());
        }

        public bool Add(string key, object value, TimeSpan expiresTime)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _database.StringSet(key, value.ToJson(), expiresTime);
        }

        public bool AddSlide(string key, object value, TimeSpan expiresTime)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _database.StringSet(key, value.ToJson(), expiresTime);
        }

        public bool Exists(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _database.KeyExists(key);
        }

        public T Get<T>(string key) where T : class
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (Exists(key))
            {
                var value = _database.StringGet(key);
                return JsonConvert.DeserializeObject<T>(value);
            }
            return null;
        }

        public object Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (Exists(key))
            {
                var value = _database.StringGet(key);
                return JsonConvert.DeserializeObject<object>(value);
            }
            return null;
        }

        public IDictionary<string, object> GetList(List<string> keys)
        {
            if (keys == null || keys.Count == 0)
            {
                throw new ArgumentNullException(nameof(keys));
            }
            var dict = new Dictionary<string, object>();

            keys.ToList().ForEach(item => dict.Add(item, Get(item)));

            return dict;
        }

        public bool Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (Exists(key))
            {
                return _database.KeyDelete(key);
            }
            return true;
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
    }
}
