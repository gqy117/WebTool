namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ErrorController : BaseController
    {
        public ViewResult Error()
        {
            return this.View("Error");
        }

        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return this.View("NotFound");
        }
    }
}
