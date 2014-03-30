using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;


namespace UITest
{
    [TestClass]
    public class AccountController : BaseController
    {
        #region Properties
        public string LoginUrl { get; set; }
        public string UserName = "1";
        public string Password = "1";
        #endregion
        #region Methods
        #region Init
        public override void Init()
        {
            this.LoginUrl = MainSite + "Account/Login";
        }
        #endregion
        #region Test
        #region OpenLoginPage
        [TestMethod]
        public void OpenLoginPage()
        {
            base.Run(() =>
            {
                LoginGet();
                Assert.AreEqual(this.CurrentBroswer.FindElementByName("UserName").Text, "");
            });
        }
        private void LoginGet()
        {
            this.CurrentBroswer.Navigate().GoToUrl(this.LoginUrl);
        }
        #endregion
        #region DoLogin
        [TestMethod]
        public void DoLogin()
        {
            base.Run(() =>
            {
                LoginGet();
                PrepareLogin();
                SubmitLogin();
                IsLoginSuccess();
            });
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
            this.CurrentBroswer.FindElementByName("UserName").SendKeys(UserName);
            this.CurrentBroswer.FindElementById("FormLogin_Password").SendKeys(Password);
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
