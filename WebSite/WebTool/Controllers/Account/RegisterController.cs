namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebToolService;

    public class RegisterController : AccountBaseController
    {
        #region Properties

        public override string MainCshtmlName
        {
            get { return "~/Views/Account/Register/Register.cshtml"; }
        }

        #endregion

        #region Methods
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
        #endregion
    }
}