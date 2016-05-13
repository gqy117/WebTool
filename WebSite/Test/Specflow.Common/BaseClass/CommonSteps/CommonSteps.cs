namespace Specflow.Common
{
    using System.Configuration;
    using System.Linq;
    using BoDi;
    using OpenQA.Selenium.Remote;
    using TechTalk.SpecFlow;

    [Binding]
    public partial class CommonSteps : SeleniumWrapper
    {
        private readonly IObjectContainer _objectContainer;

        private string baseUrl = ConfigurationManager.AppSettings["BaseUrl"];

        public CommonSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        public override string BaseUrl
        {
            get { return this.baseUrl; }
            set { this.baseUrl = value; }
        }

        [Given(@"the information")]
        public void GivenInformation(Table table)
        {
            this.UserInfo = table.Rows.First();
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var webDriver = WebDriverFactory.CreateWebDriver();
            _objectContainer.RegisterInstanceAs<RemoteWebDriver>(webDriver);

            this.Browser = webDriver;
        }

        [When(@"I swith to the iframe '(.*)'")]
        public void SwitchToInfoFrame(string iframeName)
        {
            this.Browser.SwitchTo().Frame(iframeName);
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

        [When(@"I fill all the following elements by id")]
        public void WhenIFillFollowingElementsById(Table table)
        {
            this.FillTheFormById(table, this.UserInfo);
        }

        [When(@"I fill all the following elements by name")]
        public void WhenIFillFollowingElementsByName(Table table)
        {
            this.FillTheFormByName(table, this.UserInfo);
        }

        [When(@"I open the page '(.*)'")]
        public void WhenIOpenPage(string url)
        {
            this.OpenPage(url);
        }
    }
}