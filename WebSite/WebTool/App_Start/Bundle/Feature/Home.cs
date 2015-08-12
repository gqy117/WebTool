﻿namespace WebTool.Bundle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Home
    {
        public static readonly IEnumerable<string> Files = new List<string>
        {
            "~/Views/Home/homeHeaderPanel.service.js",
            "~/Views/Shared/HeaderPanel/headerPanel.controller.js",
            "~/Views/Home/home.service.js",
            "~/Views/Home/home.controller.js",
            "~/Views/Home/Panel/wakeUpPanel.service.js",
            "~/Views/Home/Panel/wakeUpPanel.controller.js"
        };
    }
}