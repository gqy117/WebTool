namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using DataHelperLibrary;
    using WebToolCulture;
    using WebToolService;

    public abstract class AccountBaseController : BaseController
    {
        public virtual void AddModelError(LoginModel userModel)
        {
            if (!string.IsNullOrEmpty(userModel.Get(x => x.ErrorMessage)))
            {
                this.ModelState.AddModelError(string.Empty, userModel.ErrorMessage);
            }
        }
        #region Action
        public ActionResult RedirectToHomePage()
        {
            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult DoLogin(LoginModel loginModel)
        {
            bool isAllowed = false;
            if (ModelState.IsValid)
            {
                isAllowed = this.UserService.IsLoginAllowed(loginModel);
                this.AddModelError(loginModel);
            }

            if (isAllowed)
            {
                this.SetLoginCookie(loginModel);

                return this.RedirectToHomePage();
            }
            else
            {
                return this.View(this.MainCshtmlName, loginModel);
            }
        }
        #endregion

        #region Cookies
        public void SetLoginCookie(LoginModel loginModel)
        {
            string encryptedUsername = Utility.AESHelper.EncryptStringToBytes(loginModel.UserName);
            HttpCookie cookie = new HttpCookie(ConstParameter.WebToolUserName, encryptedUsername);
            this.SetLoginCookieExpires(cookie, loginModel.RememberMe);
            Response.Cookies.Add(cookie);
        }

        public void DoLogout()
        {
            if (Request.Cookies[ConstParameter.WebToolUserName] != null)
            {
                Request.Cookies[ConstParameter.WebToolUserName].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(Request.Cookies[ConstParameter.WebToolUserName]);
            }
        }

        private void SetLoginCookieExpires(HttpCookie cookie, bool isRemeber)
        {
            if (isRemeber)
            {
                cookie.Expires = DateTime.Now.AddMonths(1);
            }
            else
            {
                cookie.Expires = DateTime.Now.AddDays(1);
            }
        }

        #endregion
    }
}