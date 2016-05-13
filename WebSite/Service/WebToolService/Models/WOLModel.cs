namespace WebToolService
{
    using System.Collections.Generic;
    using Utilities;

    public class WolModel : ITotalRecords
    {
        public string Arguments { get; set; }

        public ICmdHelper CmdHelper { get; set; } = new CmdHelper();

        public string FileName { get; set; } = string.Empty;

        public string HostName { get; set; } = string.Empty;

        public string MacAddress { get; set; } = string.Empty;

        public int Port { get; set; } = 9;

        public string Protocol { get; set; }

        public string SubnetMask { get; set; } = "255.255.255.255";

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