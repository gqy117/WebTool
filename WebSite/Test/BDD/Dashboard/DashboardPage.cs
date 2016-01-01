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
        public DashboardPage(CommonSteps commonSteps)
            : base(commonSteps)
        {
        }

        #region Properties
        [FindsBy(How = How.Id, Using = "home-wake-up")]
        public IWebElement HomeWakeUp { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#alertWakeUpSuccess:not(.ng-hide)")]
        public IWebElement AlertWakeUpSuccess { get; set; }

        #endregion

        [When(@"I click home-wake-up button")]
        public void WhenIClickHome_Wake_UpButton()
        {
            this.HomeWakeUp.Click();
        }

        [Then(@"I should see alertWakeUpSuccess")]
        public void ThenIShouldSeeAlertWakeUpSuccess()
        {
            this.RefreshElementsValues(3);
            this.CommonSteps.ThenIShouldSee(this.AlertWakeUpSuccess);
        }
    }
}