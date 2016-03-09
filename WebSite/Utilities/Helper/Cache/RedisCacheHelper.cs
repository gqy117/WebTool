﻿namespace Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using StackExchange.Redis.Extensions.Core;
    using StackExchange.Redis.Extensions.Jil;

    public class RedisHelper : ICacheHelper
    {
        private static Lazy<ICacheClient> lazyStackExchangeRedisCacheClient;

        private static ICacheClient stackExchangeRedisCacheClient = null;

        private static object thisLock = new object();

        static RedisHelper()
        {
            lazyStackExchangeRedisCacheClient = new Lazy<ICacheClient>(() => new StackExchangeRedisCacheClient(new JilSerializer()));
        }

        public static ICacheClient StackExchangeRedisCacheClient
        {
            get
            {
                stackExchangeRedisCacheClient = stackExchangeRedisCacheClient ?? lazyStackExchangeRedisCacheClient.Value;
                return lazyStackExchangeRedisCacheClient.Value;
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
                lock (thisLock)
                {
                    if (!StackExchangeRedisCacheClient.Exists(key))
                    {
                        obj = func();
                        StackExchangeRedisCacheClient.Add(key, obj);
                    }
                }
            }

            return obj;
        }
    }
}