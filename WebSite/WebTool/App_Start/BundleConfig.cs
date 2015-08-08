using System.Web;
using System.Web.Optimization;
using WebGrease.Css.Visitor;

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
            bundles.Add(new ScriptBundle("~/Content/AllJS").Include(
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
            "~/Scripts/WebTool.js"));
        }

        private static void RegisterJSRoot(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Root").Include(
            "~/Views/Shared/JS/pageStart.js",
            "~/Views/Shared/JS/GoogleAnalytics.js",
            "~/Views/Shared/JS/HeadJS.js"));
        }

        private static void RegisterJSBottom(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Bottom").Include(
            "~/Views/Shared/JS/BottomJS.js",
            "~/Views/Shared/JS/PageEnd.js"));
        }

        private static void RegisterJSHead(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Head").Include(
            "~/Views/Shared/main.app.js",
            "~/Views/Sidebar/sidebar.service.js",
            "~/Views/Sidebar/sidebar.controller.js",
            "~/Views/Head/head.service.js",
            "~/Views/Head/head.controller.js",
            "~/Views/Head/Language/languageBar.service.js",
            "~/Views/Head/Language/languageBar.controller.js"));
        }

        private static void RegisterJSRegister(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Register").Include(
            "~/Views/Account/register.js"));
        }

        private static void RegisterJSHome(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Home").Include(
            "~/Views/Home/headerPanel.service.js",
            "~/Views/Shared/HeaderPanel/headerPanel.controller.js",
            "~/Views/Home/home.js"));
        }

        private static void RegisterJSLogin(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Login").Include(
            "~/Views/Account/login.js"));
        }

        private static void RegisterJSWol(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Wol").Include(
            "~/Views/WOL/headerPanel.service.js",
            "~/Views/Shared/HeaderPanel/headerPanel.controller.js",
            "~/Views/WOL/wol.js"));
        }

        private static void RegisterJSTable(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/JSTable").Include(
            "~/Content/assets/data-tables/jquery.dataTables.js",
            "~/Content/assets/data-tables/DT_bootstrap.js"));
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