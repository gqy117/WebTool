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

namespace WebTool
{
    [LoginCheck]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}