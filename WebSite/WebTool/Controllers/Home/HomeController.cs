namespace WebTool
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Resources;
    using System.Web;
    using System.Web.Mvc;
    using Newtonsoft.Json;
    using WebTool;
    using WebToolCulture.Resource;
    using WebToolService;

    [LogOnCheck]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return this.View("~/Views/Home/Home.cshtml");
        }
    }
}