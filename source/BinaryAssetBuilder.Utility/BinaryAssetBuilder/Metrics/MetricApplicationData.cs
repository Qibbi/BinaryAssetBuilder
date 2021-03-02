using System;
using System.Diagnostics;

namespace BinaryAssetBuilder.Metrics
{
    public class MetricApplicationData
    {
        public string ApplicationName { get; }
        public string UserName { get; }
        public string MachineName { get; }

        public MetricApplicationData()
        {
            ApplicationName = Process.GetCurrentProcess().MainModule.FileName;
            UserName = Environment.UserName;
            MachineName = Environment.MachineName;
        }
    }
}
