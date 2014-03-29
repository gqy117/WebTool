using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebToolCulture.Resource;
using WebToolService;

namespace WebTool
{
    [LoginCheck]
    public class ToolController : TableBaseController<WOLModel>
    {
        #region Properties
        public CMDHelper CMDHelper = new CMDHelper();
        public WOLService WOLService { get; set; }
        public WOLModel WOLModel { get; set; }
        private string _FileName = "";
        public string FileName
        {
            get
            {
                _FileName = 0 == _FileName.Length ? Server.MapPath("~/bin/WOL/WolCmd.exe") : _FileName;
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }
        #region MainResultColumn
        public override List<string> PropertyList { get { return new List<string>() { "WOLID", "WOLName", "HostName", "MACAddress", "SubnetMask", "Port", "Protocol" }; } }
        #endregion
        #endregion
        #region Methods
        [HttpGet]
        public ActionResult WOL()
        {
            return View("~/Views/WOL/WOL.cshtml");
        }
        //[HttpPost, ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult WakeUp()
        {
            this.WOLModel = this.WOLService.GetWOLById(this.CurrentUserModel.UserId).FirstOrDefault();
            if (this.WOLModel != null)
            {
                this.WOLModel.FileName = this.FileName;
                this.WOLModel.Wake();
            }
            return Json(UIResource.Done);
        }
        public ActionResult WOLTable(JQueryTable model)
        {
            return base.GetJsonTable(model, () => { this.MainList = this.WOLService.GetWOLById(this.CurrentUserModel.UserId, model); });
        }
        #endregion
    }
}
