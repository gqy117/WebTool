namespace Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Mime;
    using System.Security.Policy;
    using System.Text;

    public interface ICmdHelper
    {
        void Run(string fileName, string arguments);
    }

    public class CmdHelper : ICmdHelper
    {
        public void Run(string fileName, string arguments)
        {
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = fileName;
            startInfo.Arguments = arguments;

            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo = startInfo;
                process.Start();
            }
        }
    }
}