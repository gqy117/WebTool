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
        protected readonly CommonSteps CommonSteps;

        public StepsBase(CommonSteps commonSteps)
        {
            this.CommonSteps = commonSteps;
            this.RefreshElementsValues();
        }

        protected abstract string CurrentUrl { get; }

        protected void RefreshElementsValues(int timeout = 0)
        {
            PageFactory.InitElements(this, new RetryingElementLocator(this.CommonSteps.Browser, TimeSpan.FromSeconds(timeout)));
        }
    }
}