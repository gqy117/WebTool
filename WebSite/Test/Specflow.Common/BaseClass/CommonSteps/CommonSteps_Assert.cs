namespace Specflow.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;

    public partial class CommonSteps : SeleniumWrapper
    {
        [Then(@"the result of the element '(.*)' should be the same as the html '(.*)'")]
        public void ThenTheResultShouldBeTheSameAsTheHtmlFile(string selector, string fileName)
        {
            var expected = this.ReadFileString(fileName);

            var actual = this.Browser.FindElement(By.CssSelector(selector)).Text;

            Assert.AreEqual(expected, actual);
        }

        [Then(@"the result of the element '(.*)' should be the same as '(.*)'")]
        public void ThenTheResultShouldBeTheSameAs(string name, string expected, int timeoutInSeconds = 0)
        {
            var actual = this.Browser.FindElement(By.Name(name), timeoutInSeconds).Text;

            Assert.AreEqual(expected, actual);
        }

        [Then(@"the current url should be '(.*)'")]
        public void ThenTheCurrentUrlShouldBe(string expectedUrl)
        {
            expectedUrl = this.AddBaseUrl(expectedUrl);
            var actualUrl = this.Browser.Url;

            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [Then(@"I should see by id '(.*)'")]
        public void ThenIShouldSee(By by, int timeoutInSeconds = 0)
        {
            var expectedElement = this.Browser.FindElement(by, timeoutInSeconds);

            Assert.IsTrue(expectedElement.Displayed);
        }
    }
}
