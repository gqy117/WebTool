namespace WebTool
{
    using System.Web.Mvc;
    using WebToolService;

    public class RegisterController : AccountBaseController
    {
        public override string MainCshtmlName => "~/Views/Account/Register/Register.cshtml";

        public ActionResult Index()
        {
            return this.View(this.MainCshtmlName, new RegisterModel());
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Justification ")]
        [HttpPost]
        public ActionResult Index(RegisterModel registerModel)
        {
            ActionResult result;

            bool success = false;

            if (ModelState.IsValid)
            {
                success = UserService.Insert(registerModel);
                this.AddModelError(registerModel);
            }

            if (success)
            {
                this.DoLogOn(registerModel);
                result = this.RedirectToHomePage();
            }
            else
            {
                result = this.View(this.MainCshtmlName, registerModel);
            }

            return result;
        }
    }
}