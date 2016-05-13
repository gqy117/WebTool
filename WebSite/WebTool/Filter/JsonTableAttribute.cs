namespace WebTool
{
    using System;
    using System.Web.Mvc;
    using WebToolService;

    [AttributeUsage(AttributeTargets.Method)]
    public class JsonTableAttribute : BaseAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var tableBaseController = filterContext.Controller as TableBaseController;
            JQueryTable model = filterContext.ActionParameters["model"] as JQueryTable;

            if (tableBaseController == null
                || model == null)
            {
                return;
            }

            tableBaseController.AddOrderBy(model);

            base.OnActionExecuting(filterContext);
        }
    }
}