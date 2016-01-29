namespace BDD
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class LanguageBarPage : StepsBase
    {
        public const string NameCurrentLanguageText = "current-language-text";

        #region Constructors
        public LanguageBarPage(CommonSteps commonSteps)
            : base(commonSteps)
        {
        } 
        #endregion

        #region Properties
        [FindsBy(How = How.Id, Using = "change-language-dropdown")]
        public IWebElement ChangeLanguageDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "language-icon")]
        public IWebElement LanguageIcon { get; set; }

        protected override string CurrentUrl
        {
            get { return "/"; }
        }
        #endregion

        #region Methods
        [When(@"I click the change-language-dropdown button")]
        public void WhenIClickTheChange_Language_DropdownButton()
        {
            this.ChangeLanguageDropdown.Click();
        }

        [When(@"I click the language-icon button")]
        public void WhenIClickTheLanguage_IconButton()
        {
            this.LanguageIcon.Click();
        }

        [Then(@"the current language text should be cn\.")]
        public void ThenTheCurrentLanguageTextShouldBeCn_()
        {
            this.CommonSteps.ThenTheResultShouldBeTheSameAs(NameCurrentLanguageText, "中文", 100);
        } 
        #endregion
    }
}