namespace Specflow.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CsQuery;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.PhantomJS;
    using OpenQA.Selenium.Remote;
    using TechTalk.SpecFlow;

    [Binding]
    public class CommonSteps : TestBase
    {
        public CommonSteps()
        {
            this.Browser = WebDriverFactory.CreateWebDriver();
        }

        public override RemoteWebDriver Browser { get; set; }

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

        [When(@"I click the submit button by name '(.*)'")]
        public void WhenIClickSubmitByName(string buttonName)
        {
            this.ClickByName(buttonName);
        }

        [When(@"I click the submit button by id '(.*)'")]
        public void WhenIClickSubmitById(string buttonId)
        {
            this.ClickById(buttonId);
        }

        [Then(@"the result should be the same as the html '(.*)', and the element '(.*)'")]
        public void ThenTheResultShouldBeTheSameAsTheHtmlFile(string fileName, string selector)
        {
            var expected = CQ.Create(this.ReadFileString(fileName)).Html();

            var actual = CQ.Create(this.Browser.PageSource).Select(selector).Html();

            actual = this.RemoveWhiteSpace(actual);
            expected = this.RemoveWhiteSpace(expected);

            Assert.AreEqual(expected, actual);
        }
    }
}
