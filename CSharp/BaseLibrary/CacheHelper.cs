using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary
{
    public static class CacheHelper
    {
        //2种建立CacheManager的方式
        //ICacheManager cache = EnterpriseLibraryContainer.Current.GetInstance<ICacheManager>();
        private static ICacheManager cache = CacheFactory.GetCacheManager();
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="isRefresh">是否刷新</param>
        public static void Add(string key, object value, bool isRefresh = false)
        {
            if (isRefresh)
            {
                //自定义刷新方式,如果过期将自动重新加载,过期时间为5分钟
                cache.Add(key, value, CacheItemPriority.Normal, new MyCacheItemRefreshAction(), new AbsoluteTime(TimeSpan.FromMinutes(5)));
            }
            else
            {
                cache.Add(key, value);
            }
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
            return cache.GetData(key);
        }

        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key">键</param>
        public static void RemoveCache(string key)
        {
            cache.Remove(key);
        }
    }

    /// <summary>
    /// 自定义缓存刷新操作
    /// </summary>
    [Serializable]
    public class MyCacheItemRefreshAction : ICacheItemRefreshAction
    {
        #region ICacheItemRefreshAction 成员
        /// <summary>
        /// 自定义刷新操作
        /// </summary>
        /// <param name="removedKey">移除的键</param>
        /// <param name="expiredValue">过期的值</param>
        /// <param name="removalReason">移除理由</param>
        void ICacheItemRefreshAction.Refresh(string removedKey, object expiredValue, CacheItemRemovedReason removalReason)
        {
            if (removalReason == CacheItemRemovedReason.Expired)
            {
                ICacheManager cache = CacheFactory.GetCacheManager();
                cache.Add(removedKey, expiredValue);
            }
        }
        #endregion
    }
}
