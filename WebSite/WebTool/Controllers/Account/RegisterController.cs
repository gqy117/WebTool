using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebToolService;

namespace WebTool
{
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
            return View(this.MainCshtmlName, new RegisterModel());
        }

        [HttpPost]
        public ActionResult Index(RegisterModel registerModel)
        {
            ActionResult result;

            bool success = false;

            if (ModelState.IsValid)
            {
                success = UserService.Insert(registerModel);
                base.AddModelError(registerModel);
            }

            if (success)
            {
                base.DoLogin(registerModel);
                result = base.RedirectToHomePage();
            }
            else
            {
                result = View(this.MainCshtmlName, registerModel);
            }

            return result;
        }
        #endregion
    }
}