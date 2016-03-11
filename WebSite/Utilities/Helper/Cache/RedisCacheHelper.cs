namespace Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ServiceStack.Redis;

    public class RedisHelper : ICacheHelper
    {
        private static Lazy<IRedisClient> lazyStackExchangeRedisCacheClient;

        private static IRedisClient redisCacheClient = null;

        static RedisHelper()
        {
            lazyStackExchangeRedisCacheClient = new Lazy<IRedisClient>(() => new RedisClient());
        }

        public static IRedisClient RedisCacheClient
        {
            get
            {
                redisCacheClient = redisCacheClient ?? lazyStackExchangeRedisCacheClient.Value;

                return redisCacheClient;
            }

            set
            {
                redisCacheClient = value;
            }
        }

        public T GetCacheById<T>(string id, Func<T> func) where T : class
        {
            var tableT = RedisCacheClient.As<T>();

            T obj = tableT.GetById(id);

            if (obj == null)
            {
                using (tableT.AcquireLock(TimeSpan.FromMinutes(5)))
                {
                    obj = tableT.GetById(id);
                    if (obj == null)
                    {
                        obj = func();
                        tableT.Store(obj);
                    }
                }
            }

            return obj;
        }
    }
}