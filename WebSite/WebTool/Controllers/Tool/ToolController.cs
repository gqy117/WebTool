namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using WebToolCulture.Resource;
    using WebToolService;

    [LoginCheck]
    public class ToolController : TableBaseController<WOLModel>
    {
        #region Properties
        private CMDHelper cmdHelper = new CMDHelper();

        private string fileName = string.Empty;

        public CMDHelper CMDHelper
        {
            get
            {
                return this.cmdHelper;
            }
        }

        public WOLService WOLService { get; set; }

        public WOLModel WOLModel { get; set; }

        public string FileName
        {
            get
            {
                this.fileName = 0 == this.fileName.Length ? Server.MapPath("~/bin/WOL/WolCmd.exe") : this.fileName;
                return this.fileName;
            }

            set
            {
                this.fileName = value;
            }
        }
        #region MainResultColumn

        public override List<string> PropertyList
        {
            get
            {
                return new List<string>() { "WOLID", "WOLName", "HostName", "MACAddress", "SubnetMask", "Port", "Protocol" };
            }
        }
        #endregion
        #endregion

        #region Methods

        [HttpGet]
        public ActionResult WOL()
        {
            return this.View("~/Views/WOL/WOL.cshtml");
        }

        ////[HttpPost, ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult WakeUp()
        {
            this.WOLModel = this.WOLService.GetWOLById(this.CurrentUserModel.UserId).FirstOrDefault();
            
            if (this.WOLModel != null)
            {
                this.WOLModel.FileName = this.FileName;
                this.WOLModel.Wake();
            }

            return this.Json(UIResource.Done);
        }

        public ActionResult WOLTable(JQueryTable model)
        {
            return this.GetJsonTable(model, () => { this.MainList = this.WOLService.GetWOLById(this.CurrentUserModel.UserId, model); });
        }

        #endregion
    }
}
