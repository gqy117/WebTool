namespace UITest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.IE;

    [TestClass]
    public class AccountController : BaseController
    {
        #region Properties
        private string userName = "1";

        private string password = "1";

        public string LoginUrl { get; set; }

        public string UserName
        {
            get { return this.userName; }

            set { this.userName = value; }
        }

        public string Password
        {
            get { return this.password; }

            set { this.password = value; }
        }

        #endregion
        #region Methods
        #region Init
        public override void Init()
        {
            this.LoginUrl = this.MainSite + "Account/Login";
        }
        #endregion
        #region Test
        #region OpenLoginPage
        [TestMethod]
        public void OpenLoginPage()
        {
            this.Run(() =>
            {
                LoginGet();
                Assert.AreEqual(this.CurrentBroswer.FindElementByName("UserName").Text, string.Empty);
            });
        }

        #endregion
        #region DoLogin
        [TestMethod]
        public void DoLogin()
        {
            this.Run(() =>
            {
                LoginGet();
                PrepareLogin();
                SubmitLogin();
                IsLoginSuccess();
            });
        }

        private void LoginGet()
        {
            this.CurrentBroswer.Navigate().GoToUrl(this.LoginUrl);
        }

        private void IsLoginSuccess()
        {
            bool res = false;

            foreach (var element in this.CurrentBroswer.FindElementsByClassName("username"))
            {
                if (element.Text == "1")
                {
                    res = true;
                }
            }

            Assert.IsTrue(res);
        }

        private void PrepareLogin()
        {
            this.CurrentBroswer.FindElementByName("UserName").SendKeys(this.UserName);
            this.CurrentBroswer.FindElementById("FormLogin_Password").SendKeys(this.Password);
        }

        private void SubmitLogin()
        {
            this.CurrentBroswer.FindElementById("login-btn").Submit();
        }
        #endregion
        #endregion
        #endregion
    }
}
