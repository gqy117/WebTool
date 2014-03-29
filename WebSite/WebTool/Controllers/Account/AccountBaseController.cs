using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataHelperLibrary;
using WebToolService;


namespace WebTool
{
    public abstract class AccountBaseController : BaseController
    {
        public virtual void AddModelError(LoginModel userModel)
        {
            if (!String.IsNullOrEmpty(userModel.Get(x => x.ErrorMessage)))
            {
                ModelState.AddModelError("", userModel.ErrorMessage);
            }
        }
        #region Action
        public ActionResult RedirectToHomePage()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DoLogin(LoginModel loginModel)
        {
            bool isAllowed = false;
            if (ModelState.IsValid)
            {
                isAllowed = this.UserService.IsLoginAllowed(loginModel);
                AddModelError(loginModel);
            }
            if (isAllowed)
            {
                SetLoginCookie(loginModel);
                return RedirectToHomePage();
            }
            else
            {
                return View(this.MainCshtmlName, loginModel);
            }
        }
        #endregion

        #region Cookies
        public void SetLoginCookie(LoginModel loginModel)
        {
            string encryptedUsername = Utility.AESHelper.EncryptStringToBytes(loginModel.UserName);
            HttpCookie cookie = new HttpCookie(ConstParameter.WebToolUserName, encryptedUsername);
            SetLoginCookieExpires(cookie, loginModel.RememberMe);
            Response.Cookies.Add(cookie);
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
        public void DoLogout()
        {
            if (Request.Cookies[ConstParameter.WebToolUserName] != null)
            {
                Request.Cookies[ConstParameter.WebToolUserName].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(Request.Cookies[ConstParameter.WebToolUserName]);
            }
        }
        #endregion
    }
}