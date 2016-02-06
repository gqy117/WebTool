namespace WebTool
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Resources;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using Devshorts.MonadicNull;
    using Microsoft.Practices.Unity;
    using Newtonsoft.Json;
    using Utilities;
    using WebToolCulture;
    using WebToolCulture.Resource;
    using WebToolService;

    public abstract class BaseController : Controller
    {
        #region Properties
        public string ResourceJson { get; set; }

        public virtual string MainCshtmlName
        {
            get { return string.Empty; }
        }

        public UserModel CurrentUserModel { get; set; }

        protected UserService UserService { get; set; }

        protected LanguageService LanguageService { get; set; }

        protected AESHelper AESHelper { get; set; }

        #endregion
        #region Constructors

        [InjectionMethod]
        public void Init(UserService userService, LanguageService languageService, AESHelper aesHelper)
        {
            this.UserService = userService;
            this.LanguageService = languageService;
            this.AESHelper = aesHelper;
        }
        #endregion
        #region Methods
        public virtual void GetCurrentUser()
        {
            string userName = Option.Safe(() => Request.Cookies[ConstParameter.WebToolUserName].Value).GetValueOrDefault();
            this.CurrentUserModel = this.UserService.GetUserModelByName(userName);
        }

        public bool IsLogOn()
        {
            this.SetMasterCookie();
            bool res = (Request.Cookies[ConstParameter.WebToolUserName] == null) ? false : true;

            return res;
        }

        public ActionResult RedirectToLogOnPage()
        {
            return this.RedirectToAction("Login", "Account");
        }

        public ActionResult JSON(object data)
        {
            return this.Json(data, JsonRequestBehavior.AllowGet);
        }

        #region Resource

        [NonAction]
        protected virtual void SetResourceJson()
        {
            ResourceSet resourceSet = UIResource.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            var result = resourceSet.Cast<DictionaryEntry>().ToDictionary(x => x.Key.ToString(), x => x.Value.ToString());

            this.ResourceJson = JsonConvert.SerializeObject(result);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.SetResourceJson();
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