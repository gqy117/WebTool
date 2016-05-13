namespace WebTool
{
    using System;
    using System.Web.Mvc;

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