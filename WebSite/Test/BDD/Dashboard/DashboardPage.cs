namespace BDD.Dashboard
{
    using System;
    using OpenQA.Selenium;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class DashboardPage
    {
        public const string AlertWakeUpSuccess = "#alertWakeUpSuccess:not(.ng-hide)";
        public const string HomeWakeUp = "home-wake-up";
        private readonly CommonSteps commonSteps;

        public DashboardPage(CommonSteps commonSteps)
        {
            this.commonSteps = commonSteps;
        }

        [When(@"I click home-wake-up button")]
        public void WhenIClickHome_Wake_UpButton()
        {
            this.commonSteps.WhenIClickSubmitById(HomeWakeUp);
        }
        
        [Then(@"I should see alertWakeUpSuccess")]
        public void ThenIShouldSeeAlertWakeUpSuccess()
        {
            this.commonSteps.ThenIShouldSee(By.CssSelector(AlertWakeUpSuccess), 3);
        }
    }
}