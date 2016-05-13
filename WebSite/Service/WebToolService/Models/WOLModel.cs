namespace WebToolService
{
    using System.Collections.Generic;
    using Utilities;

    public class WolModel : ITotalRecords
    {
        public WolModel()
        {
            this.CmdHelper = new CmdHelper();
            this.FileName = string.Empty;
            this.Port = 9;
            this.HostName = string.Empty;
            this.SubnetMask = "255.255.255.255";
            this.MacAddress = string.Empty;
        }

        public string Arguments { get; set; }

        public ICmdHelper CmdHelper { get; set; }

        public string FileName { get; set; }

        public string HostName { get; set; }

        public string MacAddress { get; set; }

        public int Port { get; set; }

        public string Protocol { get; set; }

        public string SubnetMask { get; set; }

        public int TotalRecords { get; set; }

        public int UserId { get; set; }

        public int WOLID { get; set; }

        public string WolName { get; set; }

        public void PrepareArgument()
        {
            List<string> argumentList = new List<string>();

            argumentList.Add($"\"{MacAddress}\"");
            argumentList.Add($"\"{HostName}\"");
            argumentList.Add($"\"{SubnetMask}\"");
            argumentList.Add($"\"{Port}\"");

            this.Arguments = string.Join(" ", argumentList.ToArray());
        }

        public void Wake()
        {
            this.PrepareArgument();

            this.CmdHelper.Run(this.FileName, this.Arguments);
        }
    }
}