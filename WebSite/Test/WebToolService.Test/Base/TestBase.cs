﻿namespace WebToolService.Test
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Practices.Unity;
    using NUnit.Framework;
    using Telerik.JustMock;
    using Telerik.JustMock.EntityFramework;
    using WebTool;
    using WebToolRepository;

    public abstract class TestBase
    {
        private WebToolEntities Context { get; set; }

        protected IUnityContainer Container { get; set; }

        [TestFixtureSetUp]
        public virtual void Init()
        {
            SetupDependency();
            SetupDatabase();
        }

        #region SetupDatabase

        private void SetupDatabase()
        {
            CreateDatabase();

            SetupUsersTable();
            SetupWOLTable();
        }

        private void CreateDatabase()
        {
            var dbContext = Mock.Create<WebToolEntities>().PrepareMock();
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

        #endregion

        private void SetupDependency()
        {
            BootStrap bootStrap = new BootStrap();
            bootStrap.Configure();

            this.Container = bootStrap.MyContainer;
        }
    }
}