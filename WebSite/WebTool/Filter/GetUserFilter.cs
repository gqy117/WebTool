namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web.Mvc;

    public class GetUserAttribute : BaseAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.CurrentBaseController = filterContext.Controller as BaseController;

            if (this.CurrentBaseController == null)
            {
                return;
            }

            this.CurrentBaseController.GetCurrentUser();

            base.OnActionExecuting(filterContext);
        }
    }
}
