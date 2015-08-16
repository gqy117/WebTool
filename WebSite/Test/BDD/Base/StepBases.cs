namespace Specflow.Common
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Chrome;

    public class StepsBase : CommonSteps
    {
        private string baseUrl = ConfigurationManager.AppSettings["BaseUrl"];

        public override string BaseUrl
        {
            get { return this.baseUrl; }
            set { this.baseUrl = value; }
        }
    }
}
