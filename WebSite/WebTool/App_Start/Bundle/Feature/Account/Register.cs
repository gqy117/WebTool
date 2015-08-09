namespace WebTool.Bundle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Register
    {
        public static readonly IEnumerable<string> Files = new List<string>
        {
            "~/Views/Account/Register/register.service.js",
            "~/Views/Account/Register/register.controller.js"
        };
    }
}