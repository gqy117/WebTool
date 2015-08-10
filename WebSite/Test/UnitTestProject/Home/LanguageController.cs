namespace UnitTestProject.Home
{
    using System;
    using System.Web;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WebTool;
    using WebToolCulture;
    using WebToolService;

    [TestClass]
    public class LanguageControllerTest : BaseControllerTest
    {
        #region Override
        public override void InitRequest()
        {
            base.InitRequest();
            this.Request.SetupGet(r => r.Cookies).Returns(new HttpCookieCollection() { new HttpCookie(ConstParameter.WebToolLanguage, "en") });
        }

        public override void InitMainController()
        {
            this.MainController = new LanguageController() { LanguageService = new LanguageService() };
        }

        #endregion

        [TestMethod]
        public void Index()
        {
            MainController.Index();
        }
    }
}