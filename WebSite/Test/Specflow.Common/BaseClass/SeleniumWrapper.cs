namespace Specflow.Common
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using OpenQA.Selenium.Remote;
    using TechTalk.SpecFlow;

    public abstract class SeleniumWrapper
    {
        public virtual string BaseUrl { get; set; }

        public virtual RemoteWebDriver Browser
        {
            get;
            set;
        }

        public virtual Encoding DefaultEncoding
        {
            get { return Encoding.UTF8; }
        }

        public TableRow UserInfo { get; set; }

        public string AddBaseUrl(string url)
        {
            if (url.StartsWith("~"))
            {
                url = url.Replace("~", string.Empty);
                url = this.BaseUrl + url;
            }

            return url;
        }

        public void ClickById(string buttonId)
        {
            this.Browser.FindElementById(buttonId).Click();
        }

        public void ClickByName(string buttonName)
        {
            this.Browser.FindElementByName(buttonName).Click();
        }

        public virtual void FillTheFormById(Table tableKey, TableRow rowValue)
        {
            var firstRow = tableKey.Rows.First();

            for (int i = 0; i < firstRow.Keys.Count; i++)
            {
                this.Browser.FindElementById(firstRow.Values.ElementAt(i)).SendKeys(rowValue[i]);
            }
        }

        public virtual void FillTheFormByName(Table tableKey, TableRow rowValue)
        {
            var firstRow = tableKey.Rows.First();

            for (int i = 0; i < firstRow.Keys.Count; i++)
            {
                this.Browser.FindElementByName(firstRow.Values.ElementAt(i)).SendKeys(rowValue[i]);
            }
        }

        public void OpenPage(string url)
        {
            url = this.AddBaseUrl(url);

            this.Browser.Navigate().GoToUrl(url);
        }

        public virtual string ReadFileString(string filePath)
        {
            string fileString;

            using (StreamReader sr = new StreamReader(filePath, this.DefaultEncoding))
            {
                fileString = sr.ReadToEnd();
            }

            return fileString;
        }

        public string RemoveWhiteSpace(string actual)
        {
            return Regex.Replace(actual, @"\s+", string.Empty);
        }
    }
}