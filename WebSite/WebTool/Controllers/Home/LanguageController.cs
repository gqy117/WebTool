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

    public class LanguageController : BaseController
    {
        public ActionResult Index()
        {
           return this.PartialView("~/Views/Head/Language/LanguageBar.cshtml", this.LanguageService.GetLanguageModel(Request.Cookies[ConstParameter.WebToolLanguage].Get(x => x.Value).ToStringN()));
        }
    }
}
