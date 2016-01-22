namespace WebTool
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity;
    using Utilities;
    using WebToolCulture.Resource;
    using WebToolService;

    [LogOnCheck]
    public class ToolController : TableBaseController<WolModel>
    {
        #region Properties
        private CmdHelper cmdHelper = new CmdHelper();

        private string fileName = string.Empty;

        public CmdHelper CMDHelper
        {
            get
            {
                return this.cmdHelper;
            }
        }

        public WolService WOLService { get; set; }

        public WolModel WOLModel { get; set; }

        public string FileName
        {
            get
            {
                this.fileName = 0 == this.fileName.Length ? Server.MapPath("~/bin/Service/WOL/WolCmd.exe") : this.fileName;
                return this.fileName;
            }

            set
            {
                this.fileName = value;
            }
        }
        #region MainResultColumn

        public override IList<string> PropertyList
        {
            get
            {
                return new List<string>() { "WolId", "WolName", "HostName", "MacAddress", "SubnetMask", "Port", "Protocol" };
            }
        }
        #endregion
        #endregion

        #region Constructors

        [InjectionMethod]
        public void Init(WolService wolService)
        {
            this.WOLService = wolService;
        }
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
            this.WOLModel = this.WOLService.GetWolById(this.CurrentUserModel.UserId).FirstOrDefault();

            if (this.WOLModel != null)
            {
                this.WOLModel.FileName = this.FileName;
                this.WOLModel.Wake();
            }

            return this.Json(UIResource.Done);
        }

        public ActionResult WOLTable(JQueryTable model)
        {
            return this.GetJsonTable(
                model,
                () =>
                {
                    this.MainList = this.WOLService.GetWolById(this.CurrentUserModel.UserId, model);
                });
        }

        #endregion
    }
}
