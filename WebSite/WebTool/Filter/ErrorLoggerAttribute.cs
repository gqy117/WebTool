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
        private static NLog.Logger _LogHelper = NLog.LogManager.GetCurrentClassLogger();

        public static NLog.Logger LogHelper
        {
            get
            {
                return _LogHelper;
            }
        }
        #endregion
        public override void OnException(ExceptionContext filterContext)
        {
            LogError(filterContext.Exception);
            base.OnException(filterContext);
        }

        public void LogError(Exception ex)
        {
            LogHelper.ErrorException(String.Empty, ex);
        }
    }
}