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
    public class ToolController : TableBaseController
    {
        private CmdHelper cmdHelper = new CmdHelper();

        private string fileName = string.Empty;

        public CmdHelper CMDHelper
        {
            get
            {
                return this.cmdHelper;
            }
        }

        public string FileName
        {
            get
            {
                this.fileName = this.fileName.Length == 0 ? Server.MapPath("~/bin/Service/WOL/WolCmd.exe") : this.fileName;
                return this.fileName;
            }

            set
            {
                this.fileName = value;
            }
        }

        public override IList<string> PropertyList
        {
            get
            {
                return new List<string>()
                {
                    Nameof<WolModel>.Property(x => x.WOLID), 
                    Nameof<WolModel>.Property(x => x.WolName), 
                    Nameof<WolModel>.Property(x => x.HostName), 
                    Nameof<WolModel>.Property(x => x.MacAddress), 
                    Nameof<WolModel>.Property(x => x.SubnetMask), 
                    Nameof<WolModel>.Property(x => x.Port), 
                    Nameof<WolModel>.Property(x => x.Protocol)
                };
            }
        }

        public WolModel WOLModel { get; set; }

        public IWolService WOLService { get; set; }

        [InjectionMethod]
        public void Init(IWolService wolService)
        {
            this.WOLService = wolService;
        }

        ////[HttpPost, ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult WakeUp()
        {
            this.WOLModel = this.WOLService.GetWolById(this.CurrentUserModel.UserId).List.FirstOrDefault();

            if (this.WOLModel != null)
            {
                this.WOLModel.FileName = this.FileName;
                this.WOLModel.Wake();
            }

            return this.Json(UIResource.Done);
        }

        [HttpGet]
        public ActionResult WOL()
        {
            return this.View("~/Views/WOL/WOL.cshtml");
        }

        [JsonTable]
        public ActionResult WOLTable(JQueryTable model)
        {
            var listWrapper = this.WOLService.GetWolById(this.CurrentUserModel.UserId, model);

            return this.JsonTable(model, listWrapper);
        }
    }
}