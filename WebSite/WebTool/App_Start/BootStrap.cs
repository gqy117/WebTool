[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(WebTool.BootStrap), "PostStart")]
////[assembly: PreApplicationStartMethod(typeof(WebTool.Bootstrap), "PostStart")]
namespace WebTool
{
    using System;
    using System;
    using System.Collections.Generic;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web;
    using System.Web.Compilation;
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Extras.DynamicProxy2;
    using Autofac.Integration.Mvc;
    using CaptchaMvc.Infrastructure;
    using Enyim.Caching;
    using Microsoft.SqlServer.Server;
    using WebToolService;

    public class BootStrap
    {
        #region Properties
        private ContainerBuilder builder;

        public Autofac.IContainer MyContainer { get; private set; }

        public string AssembleStartWith
        {
            get
            {
                return "WebTool";
            }
        }

        public string AssembleEndWith
        {
            get
            {
                return "Service";
            }
        }
        #endregion

        public static void PostStart()
        {
            ////Console.Clear();
        }
        #region Methods
        public void Configure()
        {
            this.builder = new ContainerBuilder();
            this.OnConfigure();
            if (this.MyContainer == null)
            {
                this.MyContainer = this.builder.Build();
            }
            else
            {
                this.builder.Update(this.MyContainer);
            }
            ////This tells the MVC application to use myContainer as its dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(this.MyContainer));
        }

        protected virtual void OnConfigure()
        {
            ////This is where you register all dependencies
            ////The line below tells autofac, when a controller is initialized, pass into its constructor, the implementations of the required interfaces
            this.builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            this.RegisterWebToolRepositoryService();
            ////RegisterAOP();
            ////RegisterLogger();
            this.RegisterCaptcha();
        }
        #region Service
        private void RegisterWebToolRepositoryService()
        {
            this.RegisterAssemblyName();
        }

        private void RegisterAssemblyName()
        {
            AssemblyName[] assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            foreach (var item in assemblyNames)
            {
                if (this.IsServiceDll(item))
                {
                    var loadedAssembly = Assembly.Load(item.FullName);
                    this.builder.RegisterAssemblyTypes(loadedAssembly).Where(t => t.IsSubclassOf(typeof(ServiceBase)))
                        .InstancePerLifetimeScope()
                        .EnableClassInterceptors();
                }
            }
        }

        private bool IsServiceDll(AssemblyName assemblyName)
        {
            return assemblyName.Name.StartsWith(this.AssembleStartWith) &&
                    assemblyName.Name.EndsWith(this.AssembleEndWith);
        }
        #endregion
        #region AOP
        private void RegisterAOP()
        {
            this.builder.Register(c => new Validation());
        }
        #endregion
        #region Logger
        private void RegisterLogger()
        {
            this.builder.Register(c => new ErrorLoggerAttribute());
        }
        #endregion
        private void RegisterCaptcha()
        {
            CaptchaUtils.CaptchaManager.StorageProvider = new CookieStorageProvider();
        }
        #endregion
    }
}