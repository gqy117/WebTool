using System.Web;
using System.Web.Optimization;
using WebGrease.Css.Visitor;
using WebTool.Bundle;

namespace WebTool
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            RegisterJS(bundles);
            RegisteCSS(bundles);
            BundleTable.EnableOptimizations = true;
        }
        #region JS
        public static void RegisterJS(BundleCollection bundles)
        {
            RegisterJSMain(bundles);
            RegisterJSHead(bundles);
            RegisterJSRoot(bundles);
            RegisterJSLogin(bundles);
            RegisterJSHome(bundles);
            RegisterJSWol(bundles);
            RegisterJSTable(bundles);
            RegisterJSRegister(bundles);
            RegisterJSBottom(bundles);
        }

        private static void RegisterJSMain(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/MainJS").Include(BundleMainJs.Files));
        }

        private static void RegisterJSRoot(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Root").Include(Root.Files));
        }

        private static void RegisterJSBottom(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Bottom").Include(Bottom.Files));
        }

        private static void RegisterJSHead(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Head").Include(Head.Files));
        }

        private static void RegisterJSRegister(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Register").Include(Register.Files));
        }

        private static void RegisterJSHome(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Home").Include(Home.Files));
        }

        private static void RegisterJSLogin(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Login").Include(Login.Files));
        }

        private static void RegisterJSWol(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Wol").Include(Wol.Files));
        }

        private static void RegisterJSTable(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/JSTable").Include(JqTable.Files));
        }
        #endregion

        public static void RegisteCSS(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/AllCSS").Include(
            "~/Content/assets/bootstrap/css/bootstrap.min.css",
            "~/Content/assets/css/metro.css",
            "~/Content/assets/font-awesome/css/font-awesome.min.css",
            "~/Content/assets/css/style.css",
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
    }
}