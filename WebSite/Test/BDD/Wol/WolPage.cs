namespace BDD.Wol
{
    using System;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class WolPage
    {
        public const string ToolWolUrl = "~/Tool/WOL";
        public const string WolWoltableHtml = "Wol\\WolTable.html";
        public const string WoltableTbodyTrNthChild = "#WOLTable tbody tr:nth-child(1)";
        private readonly CommonSteps commonSteps;

        public WolPage(CommonSteps commonSteps)
        {
            this.commonSteps = commonSteps;
        }

        [When(@"I open WOL page")]
        public void WhenIOpenWOLPage()
        {
            this.commonSteps.OpenPage(ToolWolUrl);
        }
        
        [Then(@"the wol table result should be the same as WolTable\.html")]
        public void ThenTheWolTableResultShouldBeTheSameAsWolTable_Html()
        {
            this.commonSteps.ThenTheResultShouldBeTheSameAsTheHtmlFile(WoltableTbodyTrNthChild, WolWoltableHtml);
        }
    }
}