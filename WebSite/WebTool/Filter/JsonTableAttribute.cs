namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
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

            tableBaseController.ReBindJQueryTable(model);

            base.OnActionExecuting(filterContext);

            this.SetJsonTableResult(filterContext, tableBaseController, model);
        }

        private void SetJsonTableResult(ActionExecutingContext filterContext, TableBaseController tableBaseController, JQueryTable model)
        {
            filterContext.Result = tableBaseController.JsonTable(model);
        }
    }
}