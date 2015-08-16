namespace BDD
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Remote;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class LonOnSteps : StepsBase
    {
        public LonOnSteps(RemoteWebDriver browser)
        {
            this.Browser = browser;
        }
    }
}