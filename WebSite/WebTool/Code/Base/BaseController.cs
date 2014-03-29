using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DataHelperLibrary;
using Enyim.Caching;
using Enyim.Caching.Memcached;
using WebToolService;

namespace WebTool
{
    public abstract class BaseController : Controller
    {
        #region Properties
        public UserService UserService { get; set; }
        public LanguageService LanguageService { get; set; }

        public ErrorLoggerAttribute ErrorLogger { get; set; }

        public virtual string MainCshtmlName
        {
            get { return ""; }
        }

        public UserModel CurrentUserModel { get; set; }
        #endregion
        #region Constructors
        #endregion
        #region Methods
        public virtual void GetCurrentUser()
        {
            string userName = Request.Cookies[ConstParameter.WebToolUserName].Get(x => x.Value).ToStringN();
            this.CurrentUserModel = this.UserService.GetUserModelByName(userName);
        }
        public bool IsLogin()
        {
            bool res = (Request.Cookies[ConstParameter.WebToolUserName] == null) ? false : true;

            return res;
        }
        public ActionResult RedirectToLoginPage()
        {
            return RedirectToAction("Login", "Account");
        }

        public ActionResult JSON(object data)
        {
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}