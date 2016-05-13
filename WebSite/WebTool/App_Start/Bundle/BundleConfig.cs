namespace WebTool
{
    using System.Linq;
    using System.Web.Optimization;
    using Bundle;

    public static class BundleConfig
    {
        public static void RegisteCSS(BundleCollection bundles)
        {
            var cssBundle = new StyleBundle("~/Content/AllCSS");
            cssBundle.Include("~/Content/all.css");

            bundles.Add(cssBundle);
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