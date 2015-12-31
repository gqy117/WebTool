namespace BDD.Dashboard
{
    using System;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class DashboardPage
    {
        private readonly CommonSteps commonSteps;

        public DashboardPage(CommonSteps commonSteps)
        {
            this.commonSteps = commonSteps;
        }

        [When(@"I click home-wake-up button")]
        public void WhenIClickHome_Wake_UpButton()
        {
            this.commonSteps.WhenIClickSubmitById("home-wake-up");
        }
        
        [Then(@"I should see alertWakeUpSuccess")]
        public void ThenIShouldSeeAlertWakeUpSuccess()
        {
            this.commonSteps.ThenIShouldSeeById("alertWakeUpSuccess");
        }
    }
}