namespace WebTool
{
    using System.Web.Mvc;

    [LogOnCheck]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return this.View("~/Views/Home/Home.cshtml");
        }
    }
}