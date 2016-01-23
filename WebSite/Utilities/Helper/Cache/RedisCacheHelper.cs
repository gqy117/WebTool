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
        private static StackExchangeRedisCacheClient stackExchangeRedisCacheClient = new StackExchangeRedisCacheClient(new JilSerializer());

        public static StackExchangeRedisCacheClient StackExchangeRedisCacheClient
        {
            get { return stackExchangeRedisCacheClient; }

            set { stackExchangeRedisCacheClient = value; }
        }

        public T GetCache<T>(string key, Func<T> func) where T : class
        {
            T obj = StackExchangeRedisCacheClient.Exists(key) as T;

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