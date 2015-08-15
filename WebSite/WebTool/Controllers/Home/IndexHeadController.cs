namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebToolService;

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
