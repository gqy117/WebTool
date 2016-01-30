namespace BDD.Wol
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class WolPage : StepsBase
    {
        #region Fields
        public const string ToolWolUrl = "~/Tool/WOL";
        public const string WolWoltableHtml = "Wol\\WolTable.html"; 
        #endregion

        #region Constructors
        public WolPage(CommonSteps commonSteps)
            : base(commonSteps)
        {
        } 
        #endregion

        #region Properties
        [FindsBy(How = How.CssSelector, Using = "#WOLTable tbody tr:nth-child(1)")]
        public IWebElement WoltableTbodyTrNthChild { get; set; }

        protected override string CurrentUrl
        {
            get { return ToolWolUrl; }
        }
        #endregion

        #region Methods
        [When(@"I open WOL page")]
        public void WhenIOpenWOLPage()
        {
            this.OpenCurrentPage();
        }

        [Then(@"the wol table result should be the same as WolTable\.html")]
        public void ThenTheWolTableResultShouldBeTheSameAsWolTable_Html()
        {
            this.RefreshElementsValues(3);
            this.CommonSteps.ThenTheResultShouldBeTheSameAsTheHtmlFile(this.WoltableTbodyTrNthChild, WolWoltableHtml);
        } 
        #endregion
    }
}