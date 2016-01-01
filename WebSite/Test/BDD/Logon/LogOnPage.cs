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
        #region Fields
        public const string AccountLoginUrl = "~/Account/Login";
        public const string RootUrl = "~/"; 
        #endregion

        #region Constructors
        public LogOnToTheWebsite(CommonSteps commonSteps)
            : base(commonSteps)
        {
        } 
        #endregion

        #region Properties
        [FindsBy(How = How.Id, Using = "login-btn")]
        public IWebElement LoginBtn { get; set; }

        protected override string CurrentUrl
        {
            get { return AccountLoginUrl; }
        }
        #endregion

        #region Methods
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
            this.OpenCurrentPage();
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
        #endregion
    }
}