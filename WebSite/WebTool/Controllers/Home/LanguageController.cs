namespace WebTool
{
    using System.Web.Mvc;
    using WebToolCulture;

    public class LanguageController : BaseController
    {
        public ActionResult Index()
        {
           string language = this.Request?.Cookies?[ConstParameter.WebToolLanguage]?.Value;

           return this.PartialView("~/Views/Head/Language/LanguageBar.cshtml", this.LanguageService.GetLanguageModel(language));
        }
    }
}
