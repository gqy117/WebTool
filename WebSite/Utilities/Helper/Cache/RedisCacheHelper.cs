namespace Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using StackExchange.Redis.Extensions.Core;
    using StackExchange.Redis.Extensions.Jil;

    public class RedisHelper : ICacheHelper
    {
        private static ICacheClient stackExchangeRedisCacheClient = null;
        private static Lazy<ICacheClient> lazyStackExchangeRedisCacheClient = new Lazy<ICacheClient>(() => new StackExchangeRedisCacheClient(new JilSerializer()));

        public static ICacheClient StackExchangeRedisCacheClient
        {
            get
            {
                stackExchangeRedisCacheClient = stackExchangeRedisCacheClient ?? lazyStackExchangeRedisCacheClient.Value;

                return stackExchangeRedisCacheClient;
            }

            set
            {
                stackExchangeRedisCacheClient = value;
            }
        }

        public T GetCache<T>(string key, Func<T> func) where T : class
        {
            T obj = null;

            if (StackExchangeRedisCacheClient.Exists(key))
            {
                obj = StackExchangeRedisCacheClient.Get<T>(key);
            }
            else
            {
                obj = func();
                StackExchangeRedisCacheClient.Add(key, obj);
            }

            return obj;
        }
    }
}