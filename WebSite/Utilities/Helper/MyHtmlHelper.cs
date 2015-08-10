namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    public static class MyHtmlHelper
    {
        public static MvcHtmlString MyValidationSummary(this HtmlHelper helper, string validationMessage = "")
        {
            StringBuilder sb = new StringBuilder();

            if (helper.ViewData.ModelState.IsValid)
            {
                return new MvcHtmlString(string.Empty);
            }

            sb.Append("<div class='alert alert-error'><span>");

            if (!string.IsNullOrEmpty(validationMessage))
            {
                sb.Append(helper.Encode(validationMessage));
            }

            sb.Append("</span>");
            sb.Append("<div class='text'>");

            foreach (var key in helper.ViewData.ModelState.Keys)
            {
                foreach (var err in helper.ViewData.ModelState[key].Errors)
                {
                    sb.Append("<p>");
                    sb.Append(helper.Encode(err.ErrorMessage));
                    sb.Append("</p>");
                }
            }

            sb.Append("</div></div>");

            return new MvcHtmlString(sb.ToString());
        }
    }
}