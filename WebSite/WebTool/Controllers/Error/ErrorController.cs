namespace WebTool
{
    using System.Web.Mvc;

    public class ErrorController : BaseController
    {
        public ViewResult Error()
        {
            this.Response.StatusCode = 500;

            return this.View("Error");
        }

        public ViewResult NotFound()
        {
            this.Response.StatusCode = 404;

            return this.View("NotFound");
        }
    }
}
