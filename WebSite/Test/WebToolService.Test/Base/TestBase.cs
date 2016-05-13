namespace WebToolService.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Practices.Unity;
    using NUnit.Framework;
    using Telerik.JustMock;
    using Telerik.JustMock.EntityFramework;
    using WebTool;
    using WebToolRepository;

    public abstract class TestBase
    {
        protected IUnityContainer Container { get; set; }

        private WebToolEntities Context { get; set; }

        [SetUp]
        public virtual void Init()
        {
            SetupDependency();
            SetupDatabase();
        }

        private void CreateDatabase()
        {
            this.Context = Mock.Create<WebToolEntities>().PrepareMock();
            this.Container.RegisterInstance(this.Context);
        }

        private void SetupDatabase()
        {
            CreateDatabase();

            SetupUsersTable();
            SetupWOLTable();
        }

        private void SetupDependency()
        {
            BootStrap bootStrap = new BootStrap();
            bootStrap.Configure();

            this.Container = bootStrap.MyContainer;
        }

        private void SetupUsersTable()
        {
            var users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    UserName = "1",
                    Password = "3gVPVdEt60jny1k3431HB3AZOR/0qOW7L6l5dBNLvgEVPgNfFg==",
                    CreationDate = Convert.ToDateTime("2016-01-11 21:58:33.903")
                }
            };

            this.Context.Users.Bind(users);
        }

        private void SetupWOLTable()
        {
            var wols = new List<WOL>
            {
                new WOL
                {
                    WOLID = 1,
                    UserId = 1,
                    WOLName = "Home",
                    MACAddress = "10bf48766d82",
                    SubnetMask = "255.255.255.255",
                    HostName = "gqy117.no-ip.biz",
                    Port = 22,
                    Protocol = "UDP"
                }
            };

            this.Context.WOLs.Bind(wols);
        }
    }
}