using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebToolService
{
    public class WOLModel : ITotalRecords
    {
        #region Properties

        public int UserId { get; set; }
        private string _HostName = "";
        public string HostName
        {
            get { return _HostName; }
            set { _HostName = value; }
        }

        private string _SubnetMask = "255.255.255.255";
        public string SubnetMask
        {
            get
            {
                return _SubnetMask;
            }
            set { _SubnetMask = value; }
        }

        private string _MACAddress = "";
        public string MACAddress
        {
            get { return _MACAddress; }
            set { _MACAddress = value; }
        }

        public string Protocol { get; set; }

        private int _Port = 9;
        public int Port
        {
            get { return _Port; }
            set
            {
                _Port = value;
            }
        }

        public string WOLName { get; set; }
        public int WOLID { get; set; }
        public string Arguments { get; set; }


        private string _FileName = "";
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }
        public CMDHelper CMDHelper = new CMDHelper();
        public int TotalRecords { get; set; }

        #endregion

        #region Methods
        public void Wake()
        {
            PrepareArgument();
            this.CMDHelper.FileName = FileName;
            this.CMDHelper.Arguments = this.Arguments;
            this.CMDHelper.Run();
        }
        private void PrepareArgument()
        {
            List<string> argumentList = new List<string>();
            argumentList.Add(String.Format("\"{0}\"", this.MACAddress));
            argumentList.Add(String.Format("\"{0}\"", this.HostName));
            argumentList.Add(String.Format("\"{0}\"", this.SubnetMask));
            argumentList.Add(String.Format("\"{0}\"", this.Port));

            this.Arguments = string.Join(" ", argumentList.ToArray());
        }

        #endregion
    }
}