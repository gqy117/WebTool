namespace Specflow.Common
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.PageObjects;

    public abstract class StepsBase
    {
        #region Fields
        protected readonly CommonSteps CommonSteps; 
        #endregion

        #region Constructors
        public StepsBase(CommonSteps commonSteps)
        {
            this.CommonSteps = commonSteps;
            this.RefreshElementsValues();
        } 
        #endregion

        #region Properties
        protected abstract string CurrentUrl { get; } 
        #endregion

        #region Methods
        protected void RefreshElementsValues(int timeout = 0)
        {
            PageFactory.InitElements(this, new RetryingElementLocator(this.CommonSteps.Browser, TimeSpan.FromSeconds(timeout)));
        }

        protected virtual void OpenCurrentPage()
        {
            this.CommonSteps.OpenPage(this.CurrentUrl);
        } 
        #endregion
    }
}