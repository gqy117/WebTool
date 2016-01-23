namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.SessionState;
    using WebMatrix.WebData;
    using WebToolCulture.Resource;
    using WebToolService;

    public class AccountController : AccountBaseController
    {
        #region Properties

        public override string MainCshtmlName
        {
            get { return "~/Views/Account/LogOn/LogOn.cshtml"; }
        }
        #endregion

        #region Methods
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Justification ")]
        [HttpGet]
        public ActionResult Login()
        {
            this.DoLogOff();
            return this.View(this.MainCshtmlName, new LogOnModel());
        }

        ////[CaptchaVerify("Captchaisnotvalid", typeof(UIResource))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Justification ")]
        [HttpPost]
        public ActionResult Login(LogOnModel logOnModel)
        {
            return this.DoLogOn(logOnModel);
        }
        #endregion
    }
}