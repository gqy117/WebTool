namespace WebTool.Bundle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public static class Head
    {
        public static readonly IEnumerable<string> Files = new List<string>
        {
            "~/Views/Sidebar/sidebar.service.js",
            "~/Views/Sidebar/sidebar.controller.js",
            "~/Views/Head/head.service.js",
            "~/Views/Head/head.controller.js",
            "~/Views/Head/Language/languageBar.service.js",
            "~/Views/Head/Language/languageBar.controller.js"
        };
    }
}