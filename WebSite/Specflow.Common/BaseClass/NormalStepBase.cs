namespace Specflow.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Chrome;

    public class NormalStepBase : TestBase
    {
        public NormalStepBase(CommonSteps commonSteps)
        {
            this.CommonSteps = commonSteps;
            this.Browser = commonSteps.Browser;
        }

        protected CommonSteps CommonSteps { get; set; }
    }
}
