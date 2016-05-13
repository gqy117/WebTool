namespace Specflow.Common
{
    using System.Collections.Generic;
    using OpenQA.Selenium.Chrome;

    public class ChromeOptionsWithPrefs : ChromeOptions
    {
        public Dictionary<string, object> Prefs { get; set; }
    }
}
