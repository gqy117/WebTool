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
            get { return "~/Views/Account/Register.cshtml"; }
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
            bool res = false;
            if (ModelState.IsValid)
            {
                res = UserService.Insert(registerModel);
                AddModelError(registerModel);
            }
            if (res)
            {
                base.DoLogin(registerModel);
                return RedirectToHomePage();
            }
            else
            {
                return View(this.MainCshtmlName, registerModel);
            }
        }
        #endregion

    }
}
