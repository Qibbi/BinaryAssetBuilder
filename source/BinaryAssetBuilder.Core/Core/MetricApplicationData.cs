using System;
using System.Diagnostics;
using System.Security.Principal;

namespace BinaryAssetBuilder.Core
{
    public class MetricApplicationData
    {
        public string ApplicationName { get; }
        public string Username { get; }
        public string MachineName { get; }

        public MetricApplicationData()
        {
            ApplicationName = Process.GetCurrentProcess().MainModule.FileName.ToString();
            Username = WindowsIdentity.GetCurrent().Name.ToString();
            MachineName = Environment.MachineName.ToString();
        }
    }
}