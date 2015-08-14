namespace WebTool.Bundle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class MainJs
    {
        public static readonly IEnumerable<string> Files = new List<string>
        {
            "~/Content/assets/js/jquery-1.8.3.min.js",
            "~/Scripts/angular.min.js",
            "~/Content/assets/uniform/jquery.uniform.min.js",
            "~/Content/assets/breakpoints/breakpoints.js",
            "~/Content/assets/bootstrap/js/bootstrap.min.js",
            "~/Scripts/jquery.cookie.js",
            "~/Content/assets/plugins/bootstrap-modal/js/bootstrap-modal.js",
            "~/Content/assets/plugins/bootstrap-modal/js/bootstrap-modalmanager.js",
            "~/Content/assets/js/app.js",
            "~/Scripts/ui-modals.js",
            "~/Views/Shared/myDataTable.js",
            "~/Views/Shared/main.app.js"
        };
    }
}