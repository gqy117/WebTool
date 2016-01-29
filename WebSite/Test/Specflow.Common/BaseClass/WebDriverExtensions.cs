namespace Specflow.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInMilliseconds)
        {
            if (timeoutInMilliseconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutInMilliseconds));

                return wait.Until(drv => drv.FindElement(by));
            }

            return driver.FindElement(by);
        }
    }
}