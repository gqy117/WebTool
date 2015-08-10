namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.UI;
    using Enyim.Caching;
    using Enyim.Caching.Memcached;

    public class MemcachedHelper : ICacheHelper
    {
        private static MemcachedClient memcached = new MemcachedClient();

        public static MemcachedClient Memcached
        {
            get { return memcached; }

            set { memcached = value; }
        }

        public T GetCache<T>(string key, Func<T> func) where T : class
        {
            T obj = Memcached.Get(key) as T;

            if (obj == null)
            {
                obj = func();
                Memcached.Store(StoreMode.Set, key, obj);
            }

            return obj;
        }
    }
}
