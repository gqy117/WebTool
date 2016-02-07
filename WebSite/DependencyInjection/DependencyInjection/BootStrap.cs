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
    using AutoMapper;
    using Microsoft.Practices.ObjectBuilder2;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Microsoft.Practices.Unity.Mvc;
    using Microsoft.SqlServer.Server;
    using WebToolRepository;
    using WebToolService;

    public class BootStrap
    {
        #region Properties
        public IUnityContainer MyContainer { get; private set; }

        private IList<Assembly> AssembliesToRegister = new[]
        {
            Utilities.AssemblyReference.Assembly,
            WebToolService.AssemblyReference.Assembly,
        };
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

            this.RegisterAutomapper();

            this.RegisterWebToolRepositoryService();
        }

        private void RegisterAutomapper()
        {
            var config = new MapperConfiguration(CreateMapConfigure());
            var mapper = config.CreateMapper();

            this.MyContainer.RegisterInstance(mapper);
        }

        private Action<IMapperConfiguration> CreateMapConfigure()
        {
            return (IMapperConfiguration cfg) =>
            {
                cfg.CreateMap<WOL, WolModel>();
                cfg.CreateMap<WolModel, WOL>();
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<LogOnModel, User>();
            };
        }

        #region Service
        private void RegisterWebToolRepositoryService()
        {
            this.RegisterAssemblyName();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "loadedAssembly", Justification = "Default")]
        private void RegisterAssemblyName()
        {
            var types = this.AssembliesToRegister.SelectMany(x => x.ExportedTypes).ToList();

            this.MyContainer.RegisterTypes(types, WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.Transient);
        }
        #endregion
        #endregion
    }
}