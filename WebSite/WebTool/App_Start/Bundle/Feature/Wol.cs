namespace WebTool.Bundle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public static class Wol
    {
        public static readonly IEnumerable<string> Files = new List<string>
        {
            "~/Views/WOL/wolHeaderPanel.service.js",
            "~/Views/Shared/HeaderPanel/headerPanel.controller.js",
            "~/Views/WOL/wol.service.js",
            "~/Views/WOL/wol.controller.js"
        };
    }
}