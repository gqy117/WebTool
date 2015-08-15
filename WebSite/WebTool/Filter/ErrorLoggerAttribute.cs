namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using Autofac.Core.Lifetime;
    using WebToolService;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ErrorLoggerAttribute : HandleErrorAttribute
    {
        #region Properties
        private static NLog.Logger logHelper = NLog.LogManager.GetCurrentClassLogger();

        public static NLog.Logger LogHelper
        {
            get
            {
                return logHelper;
            }
        }
        #endregion
        public override void OnException(ExceptionContext filterContext)
        {
            this.LogError(filterContext.Exception);
            base.OnException(filterContext);
        }

        public void LogError(Exception ex)
        {
            LogHelper.ErrorException(string.Empty, ex);
        }
    }
}