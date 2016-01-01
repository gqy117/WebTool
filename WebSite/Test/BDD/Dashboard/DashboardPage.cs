namespace BDD.Dashboard
{
    using System;
    using OpenQA.Selenium;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class DashboardPage : StepsBase
    {
        public const string AlertWakeUpSuccess = "#alertWakeUpSuccess:not(.ng-hide)";
        public const string HomeWakeUp = "home-wake-up";

        public DashboardPage(CommonSteps commonSteps)
            : base(commonSteps)
        {
        }

        [When(@"I click home-wake-up button")]
        public void WhenIClickHome_Wake_UpButton()
        {
            this.CommonSteps.WhenIClickSubmitById(HomeWakeUp);
        }
        
        [Then(@"I should see alertWakeUpSuccess")]
        public void ThenIShouldSeeAlertWakeUpSuccess()
        {
            this.CommonSteps.ThenIShouldSee(By.CssSelector(AlertWakeUpSuccess), 3);
        }
    }
}