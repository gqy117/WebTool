namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Autofac;

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
            Builder.RegisterType<MemcachedHelper>().As<ICacheHelper>();
            ////Builder.RegisterType<SessionHelper>().As<ICacheHelper>();
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
