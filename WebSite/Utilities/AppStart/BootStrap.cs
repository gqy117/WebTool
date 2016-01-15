namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Practices.Unity;
    using StackExchange.Redis.Extensions.Core;
    using StackExchange.Redis.Extensions.Jil;

    public static class Bootstrap
    {
        public static IUnityContainer Container { get; private set; }

        public static void Startup()
        {
            Bootstrap.Container = new UnityContainer();
            OnConfigure();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "That's default usage of Unity")]
        private static void OnConfigure()
        {
            ////Builder.RegisterType<MemcachedHelper>().As<ICacheHelper>();
            Container.RegisterInstance<ICacheHelper>(new SessionHelper());

            ////ICacheHelper cacheHelper = null;
            ////try
            ////{s
            ////    StackExchangeRedisCacheClient stackExchangeRedisCacheClient = new StackExchangeRedisCacheClient(new JilSerializer());
            ////    stackExchangeRedisCacheClient.Dispose();
            ////    cacheHelper = new RedisHelper();
            ////}
            ////catch (TypeInitializationException)
            ////{
            ////    cacheHelper = new SessionHelper();
            ////}
            ////finally
            ////{
            ////    Builder.RegisterInstance(cacheHelper).As<ICacheHelper>();
            ////}
        }
    }
}
