using System;
using System.Web;
using System.Web.Caching;
using Shakir.Utilities.Helpers.Interfaces;

namespace Shakir.Utilities.Helpers
{
    public class AspNetCacheHelper : IAspNetCacheHelper
    {
        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="item">Item to be cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="expirationInMinutes"></param>
        public void Add<T>(T item, string key, int expirationInMinutes)
        {
            if (item == null) return;
            HttpContext.Current.Cache.Insert(key, item, null,DateTime.Now.AddMinutes(expirationInMinutes), Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public void Clear(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns></returns>
        public bool Exists(string key) => HttpContext.Current.Cache[key] != null;

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <param name="value">Cached value. Default(T) if 
        /// item doesn't exist.</param>
        /// <returns>Cached item as type</returns>
        public bool Get<T>(string key, out T value)
        {
            try
            {
                if (!Exists(key))
                {
                    value = default(T);
                    return false;
                }

                value = (T)HttpContext.Current.Cache[key];
            }
            catch
            {
                value = default(T);
                return false;
            }

            return true;
        }
    }
}
