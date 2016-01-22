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
    using CaptchaMvc.Infrastructure;
    using Enyim.Caching;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Microsoft.Practices.Unity.Mvc;
    using Microsoft.SqlServer.Server;
    using WebToolService;

    public class BootStrap
    {
        #region Properties
        public IUnityContainer MyContainer { get; private set; }

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

        #region Methods
        public void Configure()
        {
            this.MyContainer = new UnityContainer();
            this.MyContainer.LoadConfiguration();
            this.OnConfigure();

            ////This tells the MVC application to use myContainer as its dependency resolver
            DependencyResolver.SetResolver(new UnityDependencyResolver(this.MyContainer));
        }

        protected virtual void OnConfigure()
        {
            ////This is where you register all dependencies
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(this.MyContainer));

            this.RegisterWebToolRepositoryService();
            this.RegisterCaptcha();
        }
        #region Service
        private void RegisterWebToolRepositoryService()
        {
            this.RegisterAssemblyName();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "loadedAssembly", Justification = "Default")]
        private void RegisterAssemblyName()
        {
            AssemblyName[] assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            foreach (var item in assemblyNames)
            {
                if (this.IsServiceDll(item))
                {
                    var loadedAssembly = Assembly.Load(item.FullName);
                    var serviceTypes = loadedAssembly.ExportedTypes.Where(t => t.IsSubclassOf(typeof(ServiceBase)));

                    this.MyContainer.RegisterTypes(serviceTypes);
                }
            }
        }

        private bool IsServiceDll(AssemblyName assemblyName)
        {
            return assemblyName.Name.StartsWith(this.AssembleStartWith) &&
                    assemblyName.Name.EndsWith(this.AssembleEndWith);
        }
        #endregion

        private void RegisterCaptcha()
        {
            CaptchaUtils.CaptchaManager.StorageProvider = new CookieStorageProvider();
        }
        #endregion
    }
}