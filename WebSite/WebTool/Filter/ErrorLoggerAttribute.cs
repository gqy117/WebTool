using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Autofac.Core.Lifetime;
using LogHelperLibrary;
using WebToolService;

namespace WebTool
{
    public class ErrorLoggerAttribute : HandleErrorAttribute
    {
        #region Properties
        public LogHelper LogHelper = new LogHelper();
        public string LogName { get; set; }
        public string AllErrorName { get; set; }
        public ExceptionContext CurrentExceptionContext { get; set; }
        public static Dictionary<Type, ErrorLogName> DicErrorLogName = new Dictionary<Type, ErrorLogName>()
        {
            {typeof(HttpAntiForgeryException),new ErrorLogName() {MainName = "AntiForgery",SubName = "AntiForgery"}},
        };
        #endregion
        public override void OnException(ExceptionContext filterContext)
        {
            this.CurrentExceptionContext = filterContext;
            LogError(filterContext);
            base.OnException(filterContext);
        }

        public void LogError(ExceptionContext filterContext)
        {
            this.CurrentExceptionContext = filterContext;
            PrepareError();
            PrepareFilePath();
            this.LogHelper.PrepareDirectory();
            this.LogHelper.WriteToFile();
        }

        public void LogError(ControllerContext filterContext)
        {
            PrepareFilePath();
            this.LogHelper.PrepareDirectory();
            this.LogHelper.WriteToFile();
        }
        private void PrepareError()
        {
            this.LogHelper.SbError = new StringBuilder();
            this.LogHelper.SbError
                .AppendLine("----------")
                .AppendLine(DateTime.Now.ToString())
                .AppendLine(String.Format("Controller:{0}", this.CurrentExceptionContext.RouteData.Values["controller"]))
                .AppendLine(String.Format("Action:{0}", this.CurrentExceptionContext.RouteData.Values["action"]))
                .AppendLine(String.Format("Method Name:{0}", ((System.Reflection.MemberInfo)(this.CurrentExceptionContext.Exception.TargetSite)).Name))
                .AppendLine(String.Format("User Agent:{0}", ((((System.Web.Mvc.ControllerContext)(this.CurrentExceptionContext)).HttpContext).Request).UserAgent))
                .AppendFormat("Source:\t{0}", this.CurrentExceptionContext.Exception.Source)
                .AppendLine()
                .AppendFormat("Target:\t{0}", this.CurrentExceptionContext.Exception.TargetSite)
                .AppendLine()
                .AppendFormat("Type:\t{0}", this.CurrentExceptionContext.Exception.GetType().Name)
                .AppendLine()
                .AppendFormat("Message:\t{0}", this.CurrentExceptionContext.Exception.Message)
                .AppendLine()
                .AppendFormat("Stack:\t{0}", this.CurrentExceptionContext.Exception.StackTrace)
                .AppendLine();
        }

        #region Save
        private void PrepareLogName()
        {
            Type exceptionType = this.CurrentExceptionContext.Exception.GetType();
            if (DicErrorLogName.ContainsKey(exceptionType))
            {
                this.LogName = DicErrorLogName[exceptionType].MainName;
                this.AllErrorName = DicErrorLogName[exceptionType].SubName;
            }
            else
            {
                this.LogName = "Error";
                this.AllErrorName = "AllError";
            }
        }
        public void PrepareFilePath()
        {
            PrepareLogName();
            this.LogHelper.FilePath = this.CurrentExceptionContext.HttpContext.Server.MapPath(String.Format("~/Logs/{0}/{1}/{2}/{3}.log", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, this.LogName));
            this.LogHelper.FilePathAllError = this.CurrentExceptionContext.HttpContext.Server.MapPath(String.Format("~/Logs/{0}.log", this.AllErrorName));
        } 
        #endregion
    }

    public class ErrorLogName
    {
        public string MainName { get; set; }
        public string SubName { get; set; }
    }


}