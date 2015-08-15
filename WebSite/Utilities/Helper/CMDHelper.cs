namespace WebToolService
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Mime;
    using System.Security.Policy;
    using System.Text;

    public class CmdHelper
    {
        #region Properties
        public string FileName { get; set; }

        public string Arguments { get; set; }

        #endregion

        public void Run()
        {
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = this.FileName;
            startInfo.Arguments = this.Arguments;

            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo = startInfo;
                process.Start();
            }
        }
    }
}