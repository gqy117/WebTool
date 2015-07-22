using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebTool
{
    public class LoginCheckAttribute : BaseAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.CurrentBaseController = filterContext.Controller as BaseController;
            if (this.CurrentBaseController == null)
            {
                return;
            }

            if (!this.CurrentBaseController.IsLogin())
            {
                filterContext.Result = this.CurrentBaseController.RedirectToLoginPage();
            }
            else
            {
                this.CurrentBaseController.GetCurrentUser();
                base.OnActionExecuting(filterContext);
            }
        }
    }
}