namespace WebTool.Bundle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class JqTable
    {
        public static readonly IEnumerable<string> Files = new List<string>
        {
            "~/Views/Shared/Datatable/myDataTable.service.js",
            "~/Content/assets/data-tables/jquery.dataTables.js",
            "~/Content/assets/data-tables/DT_bootstrap.js"
        };
    }
}