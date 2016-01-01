namespace BDD.Dashboard
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class DashboardPage : StepsBase
    {
        public const string AlertWakeUpSuccess = "#alertWakeUpSuccess:not(.ng-hide)";

        public DashboardPage(CommonSteps commonSteps)
            : base(commonSteps)
        {
        }

        #region Properties
        [FindsBy(How = How.Id, Using = "home-wake-up")]
        public IWebElement HomeWakeUp { get; set; } 
        #endregion

        [When(@"I click home-wake-up button")]
        public void WhenIClickHome_Wake_UpButton()
        {
            this.HomeWakeUp.Click();
        }
        
        [Then(@"I should see alertWakeUpSuccess")]
        public void ThenIShouldSeeAlertWakeUpSuccess()
        {
            this.CommonSteps.ThenIShouldSee(By.CssSelector(AlertWakeUpSuccess), 3);
        }
    }
}