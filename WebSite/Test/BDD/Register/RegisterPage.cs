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
    public class RegisterPage : StepsBase
    {
        public const string RegisterIndexUrl = "~/Register/Index";
        public const string RegisterBtn = "login-btn";
        public const string AlertError = "alert-error";

        public RegisterPage(CommonSteps commonSteps)
            : base(commonSteps)
        {
        }

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
            this.CommonSteps.ClickById(RegisterBtn);
        }

        [Then("I should see an error")]
        public void IShouldSeeAnError()
        {
            this.CommonSteps.ThenIShouldSee(By.Name(AlertError), 3);
        }
    }
}