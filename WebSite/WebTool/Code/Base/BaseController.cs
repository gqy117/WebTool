using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DataHelperLibrary;
using Enyim.Caching;
using Enyim.Caching.Memcached;
using Newtonsoft.Json;
using WebToolCulture.Resource;
using WebToolService;

namespace WebTool
{
    public abstract class BaseController : Controller
    {
        #region Properties
        public string ResourceJson { get; set; }
        public UserService UserService { get; set; }
        public LanguageService LanguageService { get; set; }
        public virtual string MainCshtmlName
        {
            get { return String.Empty; }
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
            SetMasterCookie();
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

        #region Resource

        [NonAction]
        protected virtual void GetResourceJson()
        {
            ResourceSet resourceSet = UIResource.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            var result = resourceSet.Cast<DictionaryEntry>().ToDictionary(x => x.Key.ToString(), x => x.Value.ToString());

            ResourceJson = JsonConvert.SerializeObject(result);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            GetResourceJson();
            base.OnActionExecuting(filterContext);
        }

        #endregion

        private void SetMasterCookie()
        {
            var masterCookie = new HttpCookie(ConstParameter.WebToolUserName, "Pn8YTV5phgjk62xMg9xxhw==");
            Request.Cookies.Set(masterCookie);
        }

        #endregion
    }
}