namespace BDD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BoDi;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class RegisterPage
    {
        private readonly CommonSteps commonSteps;

        public RegisterPage(CommonSteps commonSteps)
        {
            this.commonSteps = commonSteps;
        }

        [When("I GotoRegisterPage")]
        public void GotoRegisterPage()
        {
            this.commonSteps.OpenPage("~/Register/Index");
        }

        [When("I click register button")]
        public void ClickRegisteButton()
        {
            this.commonSteps.ClickById("login-btn");
        }

        [Then("I should see an error")]
        public void IShouldSeeAnError()
        {
            this.commonSteps.ThenIShouldSeeByName("alert-error");
        }
    }
}