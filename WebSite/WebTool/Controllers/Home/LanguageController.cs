namespace WebTool
{
    using System.Web.Mvc;
    using WebToolCulture;

    public class LanguageController : BaseController
    {
        public ActionResult Index()
        {
           string language = Option.Safe(() => Request.Cookies[ConstParameter.WebToolLanguage].Value).GetValueOrDefault();

           return this.PartialView("~/Views/Head/Language/LanguageBar.cshtml", this.LanguageService.GetLanguageModel(language));
        }
    }
}
