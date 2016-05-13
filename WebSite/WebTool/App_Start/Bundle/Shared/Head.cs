namespace WebTool.Bundle
{
    using System.Collections.Generic;

    public static class Head
    {
        public static readonly IEnumerable<string> Files = new List<string>
        {
            "~/Views/Sidebar/activePanel.module.js",
            "~/Views/Sidebar/sidebar.service.js",
            "~/Views/Sidebar/sidebar.controller.js",
            "~/Views/Head/head.service.js",
            "~/Views/Head/head.controller.js",
            "~/Views/Head/Language/languageBar.service.js",
            "~/Views/Head/Language/languageBar.controller.js"
        };
    }
}