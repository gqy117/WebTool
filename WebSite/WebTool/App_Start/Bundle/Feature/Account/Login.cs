namespace WebTool.Bundle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Login
    {
        public static readonly IEnumerable<string> Files = new List<string>
        {
            "~/Views/Account/Login/login.service.js",
            "~/Views/Account/Login/login.controller.js"
        };
    }
}