using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebToolService;

namespace WebTool
{
    [LoginCheck]
    public class IndexHeadController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return PartialView("~/Views/Home/IndexHead.cshtml", this.CurrentUserModel);
        }
    }
}
