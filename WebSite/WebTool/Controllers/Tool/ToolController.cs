namespace WebTool
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity;
    using Utilities;
    using WebToolCulture.Resource;
    using WebToolService;

    [LogOnCheck]
    public class ToolController : TableBaseController
    {
        private string fileName = string.Empty;

        public CmdHelper CMDHelper { get; } = new CmdHelper();

        public string FileName
        {
            get
            {
                this.fileName = this.fileName.Length == 0 ? this.Server.MapPath("~/bin/Service/WOL/WolCmd.exe") : this.fileName;
                return this.fileName;
            }

            set
            {
                this.fileName = value;
            }
        }

        public override IList<string> PropertyList => new List<string>()
        {
            nameof(WolModel.WOLID),
            nameof(WolModel.WolName),
            nameof(WolModel.HostName),
            nameof(WolModel.MacAddress),
            nameof(WolModel.SubnetMask),
            nameof(WolModel.Port),
            nameof(WolModel.Protocol)
        };

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