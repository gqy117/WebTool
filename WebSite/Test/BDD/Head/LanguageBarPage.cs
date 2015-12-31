namespace BDD
{
    using System;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class LanguageBarPage
    {
        public const string ChangeLanguageDropdown = "change-language-dropdown";
        public const string LanguageIcon = "language-icon";
        public const string NameCurrentLanguageText = "[name=\"current-language-text\"]";
        private readonly CommonSteps commonSteps;

        public LanguageBarPage(CommonSteps commonSteps)
        {
            this.commonSteps = commonSteps;
        }
        
        [When(@"I click the change-language-dropdown button")]
        public void WhenIClickTheChange_Language_DropdownButton()
        {
            this.commonSteps.ClickById(ChangeLanguageDropdown);
        }
        
        [When(@"I click the language-icon button")]
        public void WhenIClickTheLanguage_IconButton()
        {
            this.commonSteps.ClickById(LanguageIcon);
        }
        
        [Then(@"the current language text should be cn\.")]
        public void ThenTheCurrentLanguageTextShouldBeCn_()
        {
            this.commonSteps.ThenTheResultShouldBeTheSameAs(NameCurrentLanguageText, "&#20013;&#25991;");
        }
    }
}