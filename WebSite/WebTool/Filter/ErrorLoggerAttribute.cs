namespace WebTool
{
    using System;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ErrorLoggerAttribute : HandleErrorAttribute
    {
        private static NLog.Logger logHelper = NLog.LogManager.GetCurrentClassLogger();

        public static NLog.Logger LogHelper => logHelper;

        public void LogError(Exception ex)
        {
            LogHelper.ErrorException(string.Empty, ex);
        }

        public override void OnException(ExceptionContext filterContext)
        {
            this.LogError(filterContext.Exception);
            base.OnException(filterContext);
        }
    }
}