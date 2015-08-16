namespace Specflow.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using TechTalk.SpecFlow;

    public abstract class TestBase
    {
        #region Properties

        public virtual RemoteWebDriver Browser
        {
            get;
            set;
        }

        public TableRow UserInfo { get; set; }

        protected virtual Encoding DefaultEncoding
        {
            get { return Encoding.UTF8; }
        }

        public virtual string BaseUrl { get; set; }

        #endregion

        protected virtual void FillTheFormByName(Table tableKey, TableRow rowValue)
        {
            var firstRow = tableKey.Rows.First();

            for (int i = 0; i < firstRow.Keys.Count; i++)
            {
                this.Browser.FindElementByName(firstRow.Values.ElementAt(i)).SendKeys(rowValue[i]);
            }
        }

        protected virtual void FillTheFormById(Table tableKey, TableRow rowValue)
        {
            var firstRow = tableKey.Rows.First();

            for (int i = 0; i < firstRow.Keys.Count; i++)
            {
                this.Browser.FindElementById(firstRow.Values.ElementAt(i)).SendKeys(rowValue[i]);
            }
        }

        protected void OpenPage(string url)
        {
            url = this.AddBaseUrl(url);

            this.Browser.Navigate().GoToUrl(url);
        }

        protected void ClickById(string buttonId)
        {
            this.Browser.FindElementById(buttonId).Click();
        }

        protected void ClickByName(string buttonName)
        {
            this.Browser.FindElementByName(buttonName).Click();
        }

        protected virtual string ReadFileString(string filePath)
        {
            string fileString;

            using (StreamReader sr = new StreamReader(filePath, this.DefaultEncoding))
            {
                fileString = sr.ReadToEnd();
            }

            return fileString;
        }

        protected void WaitFor(int millionSeconds)
        {
            Thread.Sleep(millionSeconds);
        }

        protected string RemoveWhiteSpace(string actual)
        {
            return Regex.Replace(actual, @"\s+", string.Empty);
        }

        protected string AddBaseUrl(string url)
        {
            if (url.StartsWith("~"))
            {
                url = url.Replace("~", string.Empty);
                url = this.BaseUrl + url;
            }

            return url;
        }
    }
}