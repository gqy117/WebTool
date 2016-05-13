namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web.Mvc;
    using Devshorts.MonadicNull;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1018:MarkAttributesWithAttributeUsage", Justification = "Justification ")]
    public class AntiForgeryAttribute : ActionFilterAttribute
    {
        public ActionExecutingContext CurrentContext { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.CurrentContext = filterContext;

            if (!this.IsUrlReferrerNull() &&
                this.IsUrlReferrerSameDomain() &&
                this.IsPost())
            {
                filterContext.Result = new EmptyResult();
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }

        private bool IsPost()
        {
            return this.CurrentContext.HttpContext.Request.HttpMethod.ToUpper() == "POST";
        }

        private bool IsUrlReferrerNull()
        {
            string host = Option.Safe(() => this.CurrentContext.HttpContext.Request.UrlReferrer.Host).GetValueOrDefault();

            return string.IsNullOrEmpty(host);
        }

        private bool IsUrlReferrerSameDomain()
        {
            return Option.Safe(() => this.CurrentContext.HttpContext.Request.UrlReferrer.Host).GetValueOrDefault() !=
                   Option.Safe(() => this.CurrentContext.HttpContext.Request.Url.Host).GetValueOrDefault();
        }
    }
}
