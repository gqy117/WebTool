namespace WebTool
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using WebToolCulture;
    using WebToolService;

    public abstract class AccountBaseController : BaseController
    {
        public virtual void AddModelError(LogOnModel userModel)
        {
            if (!string.IsNullOrEmpty(userModel?.ErrorMessage))
            {
                this.ModelState.AddModelError(string.Empty, userModel.ErrorMessage);
            }
        }

        public void DoLogOff()
        {
            if (Request.Cookies[ConstParameter.WebToolUserName] != null)
            {
                Request.Cookies[ConstParameter.WebToolUserName].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(Request.Cookies[ConstParameter.WebToolUserName]);
            }
        }

        public ActionResult DoLogOn(LogOnModel logOnModel)
        {
            bool isAllowed = false;
            if (ModelState.IsValid)
            {
                isAllowed = this.UserService.IsLogOnAllowed(logOnModel);
                this.AddModelError(logOnModel);
            }

            if (isAllowed)
            {
                this.SetLogOnCookie(logOnModel);

                return this.RedirectToHomePage();
            }
            else
            {
                return this.View(this.MainCshtmlName, logOnModel);
            }
        }

        public ActionResult RedirectToHomePage()
        {
            return this.RedirectToAction("Index", "Home");
        }

        public void SetLogOnCookie(LogOnModel logOnModel)
        {
            string encryptedUsername = this.AESHelper.EncryptStringToBytes(logOnModel.UserName);
            HttpCookie cookie = new HttpCookie(ConstParameter.WebToolUserName, encryptedUsername);
            this.SetLoginCookieExpires(cookie, logOnModel.RememberMe);
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
    }
}