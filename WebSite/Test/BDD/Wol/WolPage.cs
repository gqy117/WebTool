namespace BDD.Wol
{
    using System;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class WolPage
    {
        private readonly CommonSteps commonSteps;

        public WolPage(CommonSteps commonSteps)
        {
            this.commonSteps = commonSteps;
        }

        [When(@"I open WOL page")]
        public void WhenIOpenWOLPage()
        {
            this.commonSteps.OpenPage("~/Tool/WOL");
        }
        
        [Then(@"the wol table result should be the same as WolTable\.html")]
        public void ThenTheWolTableResultShouldBeTheSameAsWolTable_Html()
        {
            this.commonSteps.ThenTheResultShouldBeTheSameAsTheHtmlFile("#WOLTable tbody tr:nth-child(1)", "Wol\\WolTable.html");
        }
    }
}