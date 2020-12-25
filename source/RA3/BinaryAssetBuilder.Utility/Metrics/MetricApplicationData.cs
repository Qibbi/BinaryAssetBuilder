using System;
using System.Diagnostics;
using System.Security.Principal;

namespace Metrics
{
    public class MetricApplicationData
    {
        public string ApplicationName { get; }
        public string UserName { get; }
        public string MachineName { get; }

        public MetricApplicationData()
        {
            ApplicationName = Process.GetCurrentProcess().MainModule.FileName.ToString();
            UserName = WindowsIdentity.GetCurrent().Name.ToString();
            MachineName = Environment.MachineName.ToString();
        }
    }
}