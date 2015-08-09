namespace WebTool.Bundle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Wol
    {
        public static readonly IEnumerable<string> Files = new List<string>
        {
            "~/Views/WOL/headerPanel.service.js",
            "~/Views/Shared/HeaderPanel/headerPanel.controller.js",
            "~/Views/WOL/wol.js"
        };
    }
}