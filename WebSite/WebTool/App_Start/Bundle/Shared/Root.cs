namespace WebTool.Bundle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Root
    {
        public static readonly IEnumerable<string> Files = new List<string>
        {
            "~/Views/Shared/JS/pageStart.js",
            "~/Views/Shared/JS/GoogleAnalytics.js",
            "~/Views/Shared/JS/HeadJS.js"
        };
    }
}