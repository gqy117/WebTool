using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebToolService;
using DataHelperLibrary;

namespace WebTool
{
    public class LanguageController : BaseController
    {
        public ActionResult Index()
        {
           return PartialView("~/Views/Head/LanguageBar.cshtml", this.LanguageService.GetLanguageModel(Request.Cookies[ConstParameter.WebToolLanguage].Get(x => x.Value).ToStringN()));
        }
    }
}
