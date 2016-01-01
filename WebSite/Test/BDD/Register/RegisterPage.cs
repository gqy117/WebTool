namespace BDD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BoDi;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class RegisterPage : StepsBase
    {
        public const string RegisterIndexUrl = "~/Register/Index";
        public const string AlertError = "alert-error";

        public RegisterPage(CommonSteps commonSteps)
            : base(commonSteps)
        {
        }

        #region Properties
        [FindsBy(How = How.Id, Using = "login-btn")]
        public IWebElement RegisterBtn { get; set; }
        #endregion

        [When("I GotoRegisterPage")]
        public void GotoRegisterPage()
        {
            this.CommonSteps.OpenPage(RegisterIndexUrl);
        }

        [When("I fill the username, passport and confirm password")]
        public void FillTheUsernamePasswordAndConfirmPassword(Table table)
        {
            this.CommonSteps.FillTheFormByName(table, this.CommonSteps.UserInfo);
        }

        [When("I click register button")]
        public void ClickRegisteButton()
        {
            this.RegisterBtn.Click();
        }

        [Then("I should see an error")]
        public void IShouldSeeAnError()
        {
            this.CommonSteps.ThenIShouldSee(By.Name(AlertError), 3);
        }
    }
}