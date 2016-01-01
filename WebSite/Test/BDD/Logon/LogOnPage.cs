namespace BDD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.PageObjects;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class LogOnToTheWebsite : StepsBase
    {
        public const string AccountLoginUrl = "~/Account/Login";
        public const string RootUrl = "~/";

        public LogOnToTheWebsite(CommonSteps commonSteps)
            : base(commonSteps)
        {
        }

        #region Properties
        [FindsBy(How = How.Id, Using = "login-btn")]
        public IWebElement LoginBtn { get; set; }
        #endregion

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
            this.CommonSteps.OpenPage(AccountLoginUrl);
        }

        [When(@"I fill the username and password")]
        public void WhenIFillTheUsernameAndPassword()
        {
            Table tableElementName = new Table(new string[] { "UserName", "Password" });
            tableElementName.AddRow(new string[] { "UserName", "Password" });

            this.InitDefaultUserInfo();

            this.CommonSteps.FillTheFormByName(tableElementName, this.CommonSteps.UserInfo);
        }

        [When(@"I start logon")]
        public void WhenIStartLogon()
        {
            this.LoginBtn.Click();
        }

        [Then(@"I should see the url is base url")]
        public void ThenIShouldSeeTheUrlIsBaseUrl()
        {
            this.CommonSteps.ThenTheCurrentUrlShouldBe(RootUrl);
        }

        private void InitDefaultUserInfo()
        {
            Table userInfoTable = new Table(new string[] { "UserName", "Password" });
            userInfoTable.AddRow(new string[] { "1", "1" });

            if (this.CommonSteps.UserInfo == null)
            {
                this.CommonSteps.GivenInformation(userInfoTable);
            }
        }
    }
}