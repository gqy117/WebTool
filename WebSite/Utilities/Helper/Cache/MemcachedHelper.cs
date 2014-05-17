using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using Enyim.Caching;
using Enyim.Caching.Memcached;

namespace WebToolService
{
    public class MemcachedHelper : ICacheHelper
    {
        public static MemcachedClient Memcached = new MemcachedClient();

        public T GetCache<T>(string key, Func<T> func) where T : class
        {
            T obj = (Memcached.Get(key)) as T;

            if (obj == null)
            {
                obj = func();
                Memcached.Store(StoreMode.Set, key, obj);
            }
            return obj;
        }
    }
}
