namespace WebTool
{
    using System.Web.Mvc;
    using WebToolService;

    public class AccountController : AccountBaseController
    {
        public override string MainCshtmlName => "~/Views/Account/LogOn/LogOn.cshtml";

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
    }
}