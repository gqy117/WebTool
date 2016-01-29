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
        public void ThenTheResultShouldBeTheSameAsTheHtmlFile(IWebElement element, string fileName)
        {
            var expected = this.ReadFileString(fileName);

            var actual = element.Text;

            Assert.AreEqual(expected, actual);
        }

        [Then(@"the result of the element '(.*)' should be the same as '(.*)'")]
        public void ThenTheResultShouldBeTheSameAs(string name, string expected, int timeoutInMilliseconds = 0)
        {
            var actual = this.Browser.FindElement(By.Name(name), timeoutInMilliseconds).Text;

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
        public void ThenIShouldSee(IWebElement expectedElement)
        {
            Assert.IsTrue(expectedElement.Displayed);
        }
    }
}
