namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.SessionState;
    using CaptchaMvc.Attributes;
    using WebMatrix.WebData;
    using WebToolCulture.Resource;
    using WebToolService;

    public class AccountController : AccountBaseController
    {
        #region Properties

        public override string MainCshtmlName
        {
            get { return "~/Views/Account/Login/Login.cshtml"; }
        }
        #endregion

        #region Methods
        [HttpGet]
        public ActionResult Login()
        {
            this.DoLogout();
            return this.View(this.MainCshtmlName, new LoginModel());
        }

        ////[CaptchaVerify("Captchaisnotvalid", typeof(UIResource))]
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            return this.DoLogin(loginModel);
        }
        #endregion
    }
}