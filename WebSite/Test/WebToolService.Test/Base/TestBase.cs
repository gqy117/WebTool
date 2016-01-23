namespace WebToolService.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Practices.Unity;
    using NUnit.Framework;
    using WebTool;

    public abstract class TestBase
    {
        protected IUnityContainer Container { get; set; }

        [TestFixtureSetUp]
        public virtual void Init()
        {
            BootStrap bootStrap = new BootStrap();
            bootStrap.Configure();

            this.Container = bootStrap.MyContainer;
        }
    }
}