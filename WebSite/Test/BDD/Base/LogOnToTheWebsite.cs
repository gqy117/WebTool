namespace BDD.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Remote;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public class LogOnToTheWebsite : StepsBase
    {
        public LogOnToTheWebsite(RemoteWebDriver browser)
        {
            this.Browser = browser;
        }

        [When(@"LogOn to the website")]
        public void WhenIAlreadyLogOn()
        {
            this.GivenUserNameAndPassword();

            this.GotoLogOnPage();

            this.FillUserNameAndPassword();

            this.StartLogOn();

            this.WaitFor(1000);
        }

        private void StartLogOn()
        {
            this.ClickById("login-btn");
        }

        private void FillUserNameAndPassword()
        {
            Table tableElementName = new Table(new string[] { "UserName", "Password" });
            tableElementName.AddRow(new string[] { "UserName", "Password" });

            this.FillTheFormByName(tableElementName, this.UserInfo);
        }

        private void GotoLogOnPage()
        {
            this.OpenPage("~/Account/Login");
        }

        private void GivenUserNameAndPassword()
        {
            Table tableElementValue = new Table(new string[] { "UserName", "Password" });
            tableElementValue.AddRow(new string[] { "1", "1" });

            this.UserInfo = tableElementValue.Rows.First();
        }
    }
}
