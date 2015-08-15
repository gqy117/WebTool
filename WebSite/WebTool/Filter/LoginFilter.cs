namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class LogOnCheckAttribute : BaseAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.CurrentBaseController = filterContext.Controller as BaseController;

            if (this.CurrentBaseController == null)
            {
                return;
            }

            if (!this.CurrentBaseController.IsLogOn())
            {
                filterContext.Result = this.CurrentBaseController.RedirectToLogOnPage();
            }
            else
            {
                this.CurrentBaseController.GetCurrentUser();
                base.OnActionExecuting(filterContext);
            }
        }
    }
}