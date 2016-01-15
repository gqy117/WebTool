﻿namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Autofac;
    using StackExchange.Redis.Extensions.Core;
    using StackExchange.Redis.Extensions.Jil;

    public static class Bootstrap
    {
        public static ContainerBuilder Builder { get; set; }

        public static Autofac.IContainer Container { get; private set; }

        public static void Startup()
        {
            Builder = new ContainerBuilder();
            OnConfigure();
            BuildContainer();
        }

        private static void OnConfigure()
        {
            ////Builder.RegisterType<MemcachedHelper>().As<ICacheHelper>();
            ////Builder.RegisterType<SessionHelper>().As<ICacheHelper>();

            ICacheHelper cacheHelper = null;
            try
            {
                cacheHelper = new RedisHelper();
            }
            catch (TypeInitializationException)
            {
                cacheHelper = new SessionHelper();
            }
            finally
            {
                Builder.RegisterInstance(cacheHelper).As<ICacheHelper>();
            }
        }

        private static void BuildContainer()
        {
            if (Container == null)
            {
                Container = Builder.Build();
            }
            else
            {
                Builder.Update(Container);
            }
        }
    }
}
