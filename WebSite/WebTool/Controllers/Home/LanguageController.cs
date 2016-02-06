namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Devshorts.MonadicNull;
    using WebToolCulture;
    using WebToolService;

    public class LanguageController : BaseController
    {
        public ActionResult Index()
        {
           string language = Option.Safe(() => Request.Cookies[ConstParameter.WebToolLanguage].Value).GetValueOrDefault();

           return this.PartialView("~/Views/Head/Language/LanguageBar.cshtml", this.LanguageService.GetLanguageModel(language));
        }
    }
}
