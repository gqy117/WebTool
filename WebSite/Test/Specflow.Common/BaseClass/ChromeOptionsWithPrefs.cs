namespace Specflow.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Chrome;

    public class ChromeOptionsWithPrefs : ChromeOptions
    {
        public Dictionary<string, object> Prefs { get; set; }
    }
}
