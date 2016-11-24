using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace procdump_start
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "c:\\Process\\procdump.exe";
            startInfo.Arguments = " -accepteula -e -h -g -ma -w -s 60 devenv.exe c:\\school";
            process.StartInfo = startInfo;
            process.Start();
            while (true)
            {
                var proceses = System.Diagnostics.Process.GetProcesses();
                if (proceses.FirstOrDefault(x => x != null && x.ProcessName == "procdump") == null)
                {
                    process.Start();
                }

                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }
    }
}
