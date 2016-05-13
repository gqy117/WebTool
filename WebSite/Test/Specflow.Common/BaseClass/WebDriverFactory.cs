namespace Specflow.Common
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.PhantomJS;
    using OpenQA.Selenium.Remote;

    public class WebDriverFactory
    {
        private const string Chrome = "Chrome";

        private const string Firefox = "Firefox";

        private const string PhantomJS = "PhantomJS";

        private static string PhantomJSPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"npm\node_modules\phantomjs\lib\phantom\bin\");

        private static Dictionary<string, Func<RemoteWebDriver>> webDrivers = new Dictionary<string, Func<RemoteWebDriver>>()
        {
            { Chrome, () => new ChromeDriver() },
            { PhantomJS, () => new PhantomJSDriver(PhantomJSPath) },
            { Firefox, () => new FirefoxDriver() },
        };

        public static RemoteWebDriver CreateWebDriver()
        {
            return webDrivers[ConfigurationManager.AppSettings["WebDriver"]]();
        }
    }
}
