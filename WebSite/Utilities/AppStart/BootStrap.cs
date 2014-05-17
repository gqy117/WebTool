using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace WebToolService
{
    public class BootStrap
    {
        public static ContainerBuilder Builder;
        public static Autofac.IContainer Container { get; private set; }
        public static void StartUp()
        {
            Builder = new ContainerBuilder();
            OnConfigure();
            BuildContainer();
        }

        private static void OnConfigure()
        {
            Builder.RegisterType<MemcachedHelper>().As<ICacheHelper>();
            //Builder.RegisterType<SessionHelper>().As<ICacheHelper>();
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
