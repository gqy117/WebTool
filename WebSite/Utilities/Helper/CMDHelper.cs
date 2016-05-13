namespace Utilities
{
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