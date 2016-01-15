namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Utilities;

    public class WolModel : ITotalRecords
    {
        #region Properties

        private int port = 9;

        private string hostName = string.Empty;

        private string fileName = string.Empty;

        private string subnetMask = "255.255.255.255";

        private string macAddress = string.Empty;

        private CmdHelper cmdHelper = new CmdHelper();

        public string Protocol { get; set; }

        public string WolName { get; set; }

        public int WolId { get; set; }

        public string Arguments { get; set; }

        public int UserId { get; set; }

        public string HostName
        {
            get { return this.hostName; }

            set { this.hostName = value; }
        }

        public string SubnetMask
        {
            get
            {
                return this.subnetMask;
            }

            set
            {
                this.subnetMask = value;
            }
        }

        public string MacAddress
        {
            get { return this.macAddress; }

            set { this.macAddress = value; }
        }

        public int Port
        {
            get
            {
                return this.port;
            }

            set
            {
                this.port = value;
            }
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }

            set
            {
                this.fileName = value;
            }
        }

        public CmdHelper CmdHelper
        {
            get { return this.cmdHelper; }

            set { this.cmdHelper = value; }
        }

        public int TotalRecords { get; set; }

        #endregion

        #region Methods
        public void Wake()
        {
            this.PrepareArgument();
            this.CmdHelper.FileName = this.FileName;
            this.CmdHelper.Arguments = this.Arguments;
            this.CmdHelper.Run();
        }

        private void PrepareArgument()
        {
            List<string> argumentList = new List<string>();

            argumentList.Add(string.Format("\"{0}\"", this.MacAddress));
            argumentList.Add(string.Format("\"{0}\"", this.HostName));
            argumentList.Add(string.Format("\"{0}\"", this.SubnetMask));
            argumentList.Add(string.Format("\"{0}\"", this.Port));

            this.Arguments = string.Join(" ", argumentList.ToArray());
        }

        #endregion
    }
}