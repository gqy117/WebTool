namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web.Mvc;
    using DataHelperLibrary;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1018:MarkAttributesWithAttributeUsage", Justification = "Justification ")]
    public class AntiForgeryAttribute : ActionFilterAttribute
    {
        #region Properties
        public ActionExecutingContext CurrentContext { get; set; }

        #endregion
        #region Methods
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

        private bool IsUrlReferrerNull()
        {
            return string.IsNullOrEmpty(this.CurrentContext.Get(x => x.HttpContext.Request.UrlReferrer.Host));
        }

        private bool IsUrlReferrerSameDomain()
        {
            return this.CurrentContext.Get(x => x.HttpContext.Request.UrlReferrer.Host) !=
                   this.CurrentContext.Get(x => x.HttpContext.Request.Url.Host);
        }

        private bool IsPost()
        {
            return "POST" == this.CurrentContext.HttpContext.Request.HttpMethod.ToUpper();
        }

        #endregion
    }
}
