namespace Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ServiceStack.Redis;

    public class RedisHelper : ICacheHelper
    {
        private static Lazy<PooledRedisClientManager> lazyStackExchangeRedisCacheClient;

        private static IRedisClientsManager redisCacheClient = null;

        static RedisHelper()
        {
            lazyStackExchangeRedisCacheClient = new Lazy<PooledRedisClientManager>(() => new PooledRedisClientManager());
        }

        public static IRedisClientsManager RedisCacheClientManager
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
            using (var client = RedisCacheClientManager.GetClient())
            {
                var tableT = client.As<T>();

                T obj = tableT.GetById(id);

                if (obj == null)
                {
                    using (tableT.AcquireLock(TimeSpan.FromMinutes(1)))
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

        public IEnumerable<T> GetCacheTable<T>(string tableName, Func<IEnumerable<T>> func) where T : class
        {
            using (var client = RedisCacheClientManager.GetClient())
            {
                var tableT = client.As<T>();

                IEnumerable<T> obj = tableT.GetAll();

                if (!obj.Any())
                {
                    using (tableT.AcquireLock(TimeSpan.FromMinutes(1)))
                    {
                        obj = tableT.GetAll();
                        if (!obj.Any())
                        {
                            obj = func();
                            tableT.StoreAll(obj);
                        }
                    }
                }

                return obj;
            }
        }
    }
}