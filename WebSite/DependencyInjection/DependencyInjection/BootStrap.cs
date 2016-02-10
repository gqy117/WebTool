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
    using DependencyInjection;
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

            this.RegisterWebToolRepositoryService();
            this.RegisterAutomapper();
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
                var allProfiles = this.MyContainer.ResolveAll<Profile>().ToList();

                allProfiles.ForEach(profile => cfg.AddProfile(profile));
            };
        }

        #region Service
        private void RegisterWebToolRepositoryService()
        {
            this.RegisterAssemblyName();
            this.RegisterAutoMapperProfiles();
        }

        private void RegisterAutoMapperProfiles()
        {
            var autoMapperProfiles = DependencyInjection.AssemblyReference.Assembly.ExportedTypes
                .Where(x => x.BaseType == typeof(Profile))
                .ToList();

            autoMapperProfiles.ForEach(profile => this.MyContainer.RegisterType(typeof(Profile), profile, profile.Name));
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