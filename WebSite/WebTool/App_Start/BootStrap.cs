﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using CaptchaMvc.Infrastructure;
using Enyim.Caching;
using Microsoft.SqlServer.Server;
using WebToolService;
using System.Web.Compilation;

namespace WebTool
{
    public class BootStrap
    {
        #region Properties
        public Autofac.IContainer MyContainer { get; private set; }
        private ContainerBuilder Builder;
        public string AssembleStartWith = "WebTool";
        public string AssembleEndWith = "Service";
        #endregion

        #region Methods
        public void Configure()
        {
            this.Builder = new ContainerBuilder();
            OnConfigure();
            if (this.MyContainer == null)
            {
                this.MyContainer = Builder.Build();
            }
            else
            {
                Builder.Update(this.MyContainer);
            }
            //This tells the MVC application to use myContainer as its dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(this.MyContainer));
        }
        protected virtual void OnConfigure()
        {
            //This is where you register all dependencies
            //The line below tells autofac, when a controller is initialized, pass into its constructor, the implementations of the required interfaces
            Builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            RegisterWebToolRepositoryService();
            //RegisterAOP();
            RegisterLogger();
            RegisterCaptcha();
        }
        #region Service
        private void RegisterWebToolRepositoryService()
        {
            RegisterAssemblyName();
        }
        private void RegisterAssemblyName()
        {
            AssemblyName[] assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            foreach (var item in assemblyNames)
            {
                if (IsServiceDll(item))
                {
                    var loadedAssembly = Assembly.Load(item.FullName);
                    Builder.RegisterAssemblyTypes(loadedAssembly).Where(t => t.IsSubclassOf(typeof(ServiceBase)))
                        .InstancePerLifetimeScope()
                        .EnableClassInterceptors();
                }
            }
        }
        private bool IsServiceDll(AssemblyName assemblyName)
        {
            return (assemblyName.Name.StartsWith(this.AssembleStartWith) &&
                    assemblyName.Name.EndsWith(this.AssembleEndWith));
        } 
        #endregion
        #region AOP
        private void RegisterAOP()
        {
            Builder.Register(c => new Validation());
        } 
        #endregion
        #region Logger
        private void RegisterLogger()
        {
            Builder.Register(c => new ErrorLoggerAttribute());
        }
        #endregion
        private void RegisterCaptcha()
        {
            CaptchaUtils.CaptchaManager.StorageProvider = new CookieStorageProvider();
        }
        #endregion
    }
}