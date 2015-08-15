namespace WebTool.Bundle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public static class LogOn
    {
        public static readonly IEnumerable<string> Files = new List<string>
        {
            "~/Views/Account/LogOn/login.service.js",
            "~/Views/Account/LogOn/login.controller.js"
        };
    }
}