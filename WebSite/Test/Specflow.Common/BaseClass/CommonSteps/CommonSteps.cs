namespace Specflow.Common
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using BoDi;
    using CsQuery;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.PhantomJS;
    using OpenQA.Selenium.Remote;
    using TechTalk.SpecFlow;

    [Binding]
    public partial class CommonSteps : TestBase
    {
        private readonly IObjectContainer _objectContainer;

        private string baseUrl = ConfigurationManager.AppSettings["BaseUrl"];

        public override string BaseUrl
        {
            get { return this.baseUrl; }
            set { this.baseUrl = value; }
        }

        public CommonSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var webDriver = WebDriverFactory.CreateWebDriver();
            _objectContainer.RegisterInstanceAs<RemoteWebDriver>(webDriver);

            this.Browser = webDriver;
        }

        [Given(@"the information")]
        public void GivenInformation(Table table)
        {
            this.UserInfo = table.Rows.First();
        }

        [When(@"I open the page '(.*)'")]
        public void WhenIOpenPage(string url)
        {
            this.OpenPage(url);
        }

        [When(@"I swith to the iframe '(.*)'")]
        public void SwitchToInfoFrame(string iframeName)
        {
            this.Browser.SwitchTo().Frame(iframeName);
        }

        [When(@"I fill all the following elements by name")]
        public void WhenIFillFollowingElementsByName(Table table)
        {
            this.FillTheFormByName(table, this.UserInfo);
        }

        [When(@"I fill all the following elements by id")]
        public void WhenIFillFollowingElementsById(Table table)
        {
            this.FillTheFormById(table, this.UserInfo);
        }

        [When(@"I click the button by name '(.*)'")]
        public void WhenIClickButtonByName(string buttonName)
        {
            this.ClickByName(buttonName);
        }

        [When(@"I click the button by id '(.*)'")]
        public void WhenIClickSubmitById(string buttonId)
        {
            this.ClickById(buttonId);
        }

        [When(@"I wait for '(.*)'")]
        public void WhenIWaitFor(int millionSeconds)
        {
            this.WaitFor(millionSeconds);
        }
    }
}
