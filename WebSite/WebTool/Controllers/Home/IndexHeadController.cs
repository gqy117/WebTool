namespace WebTool
{
    using System.Web.Mvc;

    [LogOnCheck]
    public class IndexHeadController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.PartialView("~/Views/Head/Head.cshtml", this.CurrentUserModel);
        }
    }
}
