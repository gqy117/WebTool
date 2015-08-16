namespace BDD.Dashboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Account;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    [Scope(Feature = "DashboardWakeUp", Tag = "AlreadyLogOn")]
    public class DashboardWakeUp : StepsBase
    {
        private LonOnFeature lonOnFeature;

        public DashboardWakeUp(LonOnFeature lonOnFeature)
        {
            this.lonOnFeature = lonOnFeature;
        }

        [When(@"I logOn to the website")]
        public void WhenIlogOnToTheWebsite()
        {
            this.lonOnFeature.LogOnToTheWebsite();
        }
    }
}
