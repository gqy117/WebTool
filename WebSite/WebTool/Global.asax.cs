namespace WebTool
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using WebToolCulture;
    using WebToolService;

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorLoggerAttribute());
            filters.Add(new AntiForgeryAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }

        public void Application_OnBeginRequest(object sender, EventArgs e)
        {
            this.SetLanguage();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            this.RegisterBinders();
            BootStrap bootstrap = new BootStrap();
            bootstrap.Configure();
        }

        private void RegisterBinders()
        {
            ModelBinders.Binders.DefaultBinder = new DefaultModelBinder();
            ModelBinders.Binders.Add(typeof(JQueryTable), new JQueryDataTablesModelBinder());
        }

        private void SetLanguage()
        {
            if (Request.Cookies[ConstParameter.WebToolLanguage] != null)
            {
                CultureHelper.SetCurrentCulture(Request.Cookies[ConstParameter.WebToolLanguage].Value);
            }
            else
            {
                string lang = CultureHelper.GetLang(Request.UserLanguages);
                CultureHelper.SetCurrentCulture(lang);
                HttpCookie cookie = new HttpCookie(ConstParameter.WebToolLanguage, lang);
                cookie.Expires = DateTime.Now.AddYears(10);
                Response.Cookies.Add(cookie);
            }
        }
    }
}