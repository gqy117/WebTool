namespace BDD
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
        public const string AccountLoginUrl = "~/Account/Login";
        public const string LoginBtn = "login-btn";
        public const string RootUrl = "~/";
        private readonly CommonSteps commonSteps;

        public LogOnToTheWebsite(CommonSteps commonSteps)
        {
            this.commonSteps = commonSteps;
        }

        [When("I LogOn to the website")]
        public void WhenILogOnToTheWebsite()
        {
            this.WhenIGotoLogonPage();
            this.WhenIFillTheUsernameAndPassword();
            this.WhenIStartLogon();
        }

        [When(@"I goto logon page")]
        public void WhenIGotoLogonPage()
        {
            this.commonSteps.OpenPage(AccountLoginUrl);
        }

        [When(@"I fill the username and password")]
        public void WhenIFillTheUsernameAndPassword()
        {
            Table tableElementName = new Table(new string[] { "UserName", "Password" });
            tableElementName.AddRow(new string[] { "UserName", "Password" });

            this.InitDefaultUserInfo();

            this.commonSteps.FillTheFormByName(tableElementName, this.commonSteps.UserInfo);
        }

        [When(@"I start logon")]
        public void WhenIStartLogon()
        {
            this.commonSteps.ClickById(LoginBtn);
        }

        [Then(@"I should see the url is base url")]
        public void ThenIShouldSeeTheUrlIsBaseUrl()
        {
            this.commonSteps.ThenTheCurrentUrlShouldBe(RootUrl);
        }

        private void InitDefaultUserInfo()
        {
            Table userInfoTable = new Table(new string[] { "UserName", "Password" });
            userInfoTable.AddRow(new string[] { "1", "1" });

            if (this.commonSteps.UserInfo == null)
            {
                this.commonSteps.GivenInformation(userInfoTable);
            }
        }
    }
}