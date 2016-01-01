namespace BDD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BoDi;
    using OpenQA.Selenium;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class RegisterPage
    {
        public const string RegisterIndexUrl = "~/Register/Index";
        public const string RegisterBtn = "login-btn";
        public const string AlertError = "alert-error";
        private readonly CommonSteps commonSteps;

        public RegisterPage(CommonSteps commonSteps)
        {
            this.commonSteps = commonSteps;
        }

        [When("I GotoRegisterPage")]
        public void GotoRegisterPage()
        {
            this.commonSteps.OpenPage(RegisterIndexUrl);
        }

        [When("I fill the username, passport and confirm password")]
        public void FillTheUsernamePasswordAndConfirmPassword(Table table)
        {
            this.commonSteps.FillTheFormByName(table, this.commonSteps.UserInfo);
        }

        [When("I click register button")]
        public void ClickRegisteButton()
        {
            this.commonSteps.ClickById(RegisterBtn);
        }

        [Then("I should see an error")]
        public void IShouldSeeAnError()
        {
            this.commonSteps.ThenIShouldSee(By.Name(AlertError), 3);
        }
    }
}