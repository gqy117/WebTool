namespace WebTool.Bundle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public static class MainJs
    {
        public static readonly IEnumerable<string> Files = new List<string>
        {
            "~/Content/assets/js/jquery-1.8.3.min.js",
            "~/Scripts/angular.js",
            "~/Content/assets/uniform/jquery.uniform.min.js",
            "~/Content/assets/breakpoints/breakpoints.js",
            "~/Content/assets/bootstrap/js/bootstrap.min.js",
            "~/Scripts/jquery.cookie.js",
            "~/Content/assets/plugins/bootstrap-modal/js/bootstrap-modal.js",
            "~/Content/assets/plugins/bootstrap-modal/js/bootstrap-modalmanager.js",
            "~/Views/Shared/Library/main.app.js",
            "~/Content/assets/js/app.js",
            "~/Views/Shared/Library/ga.service.js",
            "~/Views/Shared/Library/jQuery.service.js",
            "~/Views/Shared/Init/uiModel.service.js",
            "~/Views/Shared/Init/main.controller.js"
        };
    }
}