﻿namespace BDD.Wol
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class WolPage : StepsBase
    {
        public const string ToolWolUrl = "~/Tool/WOL";
        public const string WolWoltableHtml = "Wol\\WolTable.html";

        public WolPage(CommonSteps commonSteps)
            : base(commonSteps)
        {
        }

        #region Properties
        [FindsBy(How = How.CssSelector, Using = "#WOLTable tbody tr:nth-child(1)")]
        public IWebElement WoltableTbodyTrNthChild { get; set; }
        #endregion

        [When(@"I open WOL page")]
        public void WhenIOpenWOLPage()
        {
            this.CommonSteps.OpenPage(ToolWolUrl);
        }

        [Then(@"the wol table result should be the same as WolTable\.html")]
        public void ThenTheWolTableResultShouldBeTheSameAsWolTable_Html()
        {
            this.CommonSteps.ThenTheResultShouldBeTheSameAsTheHtmlFile(this.WoltableTbodyTrNthChild, WolWoltableHtml);
        }
    }
}