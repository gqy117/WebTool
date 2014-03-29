using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebTool
{
    public class BaseAttribute : ActionFilterAttribute
    {
        #region Properties
        public virtual BaseController CurrentBaseController { get; set; }
        #endregion
        #region Methods
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.CurrentBaseController = filterContext.Controller as BaseController;
            if (this.CurrentBaseController == null) return;
            base.OnActionExecuting(filterContext);
        } 
        #endregion
    }
}