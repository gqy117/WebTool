namespace BDD.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Remote;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class LogOnToTheWebsite
    {
        private readonly CommonSteps commonSteps;

        public LogOnToTheWebsite(CommonSteps commonSteps)
        {
            this.commonSteps = commonSteps;
        }

        [When(@"I goto logon page")]
        public void WhenIGotoLogonPage()
        {
            this.commonSteps.OpenPage("~/Account/Login");
        }

        [When(@"I fill the username and password")]
        public void WhenIFillTheUsernameAndPassword()
        {
            Table tableElementName = new Table(new string[] { "UserName", "Password" });
            tableElementName.AddRow(new string[] { "UserName", "Password" });

            this.commonSteps.FillTheFormByName(tableElementName, this.commonSteps.UserInfo);
        }

        [When(@"I start logon")]
        public void WhenIStartLogon()
        {
            this.commonSteps.ClickById("login-btn");
        }

        [Then(@"I should see the url is base url")]
        public void ThenIShouldSeeTheUrlIsBaseUrl()
        {
            this.commonSteps.ThenTheCurrentUrlShouldBe("~/");
        }
    }
}
