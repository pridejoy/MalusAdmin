using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Common
{
    /// <summary>
    /// 缓存服务接口
    /// </summary>
    public interface ICacheService
    {
        #region 添加缓存
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <returns></returns>
        bool Add(string key, object value);

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <param name="expiresTime">过期时间</param>
        /// <returns></returns>
        bool Add(string key, object value, TimeSpan expiresTime);

        /// <summary>
        /// 添加缓存(滑动过期，访问后会自动延长)
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <param name="expiresTime">过期时间</param>
        /// <returns></returns>
        bool AddSlide(string key, object value, TimeSpan expiresTime);
        #endregion

        #region 删除缓存
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        bool Remove(string key);

        /// <summary>
        /// 批量删除缓存
        /// </summary>
        /// <param name="keys">keys</param>
        bool RemoveList(List<string> keys);
        #endregion

        #region 获取缓存
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="key">key</param>
        /// <returns></returns>
        T Get<T>(string key) where T : class;

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        object Get(string key);

        /// <summary>
        /// 获取缓存集合
        /// </summary>
        /// <param name="keys">keys</param>
        /// <returns></returns>
        IDictionary<string, object> GetList(List<string> keys);
        #endregion

        #region 判断缓存是否存在
        /// <summary>
        /// 判断缓存是否存在
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        bool Exists(string key);
        #endregion


    }
}
