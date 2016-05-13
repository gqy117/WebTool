namespace WebTool
{
    using System.Linq;
    using System.Web.Optimization;
    using Bundle;

    public static class BundleConfig
    {
        public static void RegisteCSS(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/AllCSS").IncludeWithCssRewriteUrlTransform(
            "~/Content/assets/bootstrap/css/bootstrap.min.css",
            "~/Content/assets/css/metro.min.css",
            "~/Content/assets/font-awesome/css/font-awesome.css",
            "~/Content/assets/css/style.css",
            "~/Content/assets/css/sprite-home.css",
            "~/Content/assets/css/themes/default.css",
                ////"~/Content/assets/css/themes/light.css",
            "~/Content/assets/uniform/css/uniform.default.css",
            "~/Content/assets/bootstrap/css/bootstrap-responsive.min.css",
            "~/Content/Site.css",
            "~/Content/assets/css/style_responsive.css",
            "~/Content/assets/data-tables/DT_bootstrap.css",
            "~/Content/assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.css",
            "~/Content/assets/plugins/bootstrap-modal/css/bootstrap-modal.css"));
        }

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            RegisterJS(bundles);
            RegisteCSS(bundles);
#if !DEBUG
            BundleTable.EnableOptimizations = true;
#endif
        }

        public static void RegisterJS(BundleCollection bundles)
        {
            RegisterJSLogin(bundles);
            RegisterJSHome(bundles);
            RegisterJSWol(bundles);
            RegisterJSRegister(bundles);
        }

        private static void RegisterJSHome(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Home").Include(
                MainJs.Files
                .Concat(Head.Files)
                .Concat(Home.Files)
                .ToArray()));
        }

        private static void RegisterJSLogin(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/LogOn").Include(
                MainJs.Files
                .Concat(LogOn.Files)
                    .ToArray()));
        }

        private static void RegisterJSRegister(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Register").Include(
                MainJs.Files
                .Concat(Register.Files)
                .ToArray()));
        }

        private static void RegisterJSWol(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Wol").Include(
                MainJs.Files
                .Concat(Head.Files)
                .Concat(JqTable.Files)
                .Concat(Wol.Files)
                .ToArray()));
        }
    }
}