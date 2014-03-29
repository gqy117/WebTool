using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebTool;
using WebToolService;

namespace UnitTestProject
{
    [TestClass]
    public class AccountControllerTest : BaseControllerTest
    {
        #region Properties
        private LoginModel LoginModel = new LoginModel() { UserName = "1", Password = "1" };
        #endregion
        #region Methods
        #region Override
        public override void InitRequest()
        {
            base.InitRequest();
            this.Request.SetupGet(r => r.Cookies).Returns(new HttpCookieCollection() { new HttpCookie(ConstParameter.WebToolUserName,"") });
        }
        public override void InitMainController()
        {
            this.MainController = new AccountController() { UserService = new UserService() };
        }
        #endregion
        [TestMethod]
        public void LoginGet()
        {
            MainController.Login();
        }
        [TestMethod]
        public void LoginPost()
        {
            MainController.Login(this.LoginModel);
        }
        #endregion
    }
}
