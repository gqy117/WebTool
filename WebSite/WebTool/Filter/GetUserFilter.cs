namespace WebTool
{
    using System;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
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
