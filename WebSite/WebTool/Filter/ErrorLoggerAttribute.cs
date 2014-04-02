using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Autofac.Core.Lifetime;
using WebToolService;

namespace WebTool
{
    public class ErrorLoggerAttribute : HandleErrorAttribute
    {
        #region Properties
        public static NLog.Logger LogHelper = NLog.LogManager.GetCurrentClassLogger();
        #endregion
        public override void OnException(ExceptionContext filterContext)
        {
            LogError(filterContext.Exception);
            base.OnException(filterContext);
        }

        public void LogError(Exception ex)
        {
            LogHelper.ErrorException("", ex);
        }
    }
}