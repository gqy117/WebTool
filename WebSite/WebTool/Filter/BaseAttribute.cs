namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1018:MarkAttributesWithAttributeUsage", Justification = "Justification ")]
    public class BaseAttribute : ActionFilterAttribute
    {
        public virtual BaseController CurrentBaseController { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.CurrentBaseController = filterContext.Controller as BaseController;

            if (this.CurrentBaseController == null)
            {
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}