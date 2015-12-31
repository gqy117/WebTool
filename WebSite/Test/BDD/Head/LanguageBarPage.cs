namespace BDD
{
    using System;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class LanguageBarPage
    {
        private readonly CommonSteps commonSteps;

        public LanguageBarPage(CommonSteps commonSteps)
        {
            this.commonSteps = commonSteps;
        }
        
        [When(@"I click the change-language-dropdown button")]
        public void WhenIClickTheChange_Language_DropdownButton()
        {
            this.commonSteps.ClickById("change-language-dropdown");
        }
        
        [When(@"I click the language-icon button")]
        public void WhenIClickTheLanguage_IconButton()
        {
            this.commonSteps.ClickById("language-icon");
        }
        
        [Then(@"the current language text should be cn\.")]
        public void ThenTheCurrentLanguageTextShouldBeCn_()
        {
            this.commonSteps.ThenTheResultShouldBeTheSameAs("[name=\"current-language-text\"]", "&#20013;&#25991;");
        }
    }
}