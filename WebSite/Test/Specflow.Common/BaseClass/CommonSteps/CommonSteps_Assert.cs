namespace Specflow.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CsQuery;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    public partial class CommonSteps : TestBase
    {
        [Then(@"the result should be the same as the html '(.*)', and the element '(.*)'")]
        public void ThenTheResultShouldBeTheSameAsTheHtmlFile(string fileName, string selector)
        {
            var expected = this.ReadFileString(fileName);

            var actual = CQ.Create(this.Browser.PageSource).Select(selector).Html();

            actual = this.RemoveWhiteSpace(actual);
            expected = this.RemoveWhiteSpace(expected);

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
        public void WhenIWaitFor(string expectedElementId)
        {
            var expectedElement = this.Browser.FindElementById(expectedElementId);

            Assert.IsTrue(expectedElement.Displayed);
        }

        [Then(@"I should see by name '(.*)'")]
        public void ThenIShouldSeeByName(string expectedElementName)
        {
            var expectedElement = this.Browser.FindElementByName(expectedElementName);

            Assert.IsTrue(expectedElement.Displayed);
        }
    }
}
