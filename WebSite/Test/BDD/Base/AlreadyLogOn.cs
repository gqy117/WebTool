namespace BDD.Base
{
    /*using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Specflow.Common;
    using TechTalk.SpecFlow;

    [Binding]
    [Scope(Tag = "AlreadyLogOn")]
    public class AlreadyLogOn : StepsBase
    {
        [When(@"I already LogOn")]
        public void WhenIAlreadyLogOn()
        {
            this.GivenUserNameAndPassword();

            this.GotoLogOnPage();

            this.FillUserNameAndPassword();

            this.StartLogOn();
        }

        private void StartLogOn()
        {
            this.WhenIClickSubmitById("login-btn");
        }

        private void FillUserNameAndPassword()
        {
            Table tableElementName = new Table(new string[] { "UserName", "Password" });
            tableElementName.AddRow(new string[] { "UserName", "Password" });

            this.WhenIFillFollowingElementsByName(tableElementName);
        }

        private void GotoLogOnPage()
        {
            this.WhenIOpenPage("~/Account/Login");
        }

        private void GivenUserNameAndPassword()
        {
            Table tableElementValue = new Table(new string[] { "UserName", "Password" });
            tableElementValue.AddRow(new string[] { "1", "1" });

            this.GivenInformation(tableElementValue);
        }
    }*/
}
