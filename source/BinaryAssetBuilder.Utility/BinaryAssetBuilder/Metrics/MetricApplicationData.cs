using System;
using System.IO;

namespace BinaryAssetBuilder.Metrics
{
    public class MetricApplicationData
    {
        public string ApplicationName { get; }
        public string UserName { get; }
        public string MachineName { get; }

        public MetricApplicationData()
        {
            ApplicationName = Path.GetFileName(Environment.ProcessPath);
            UserName = Environment.UserName;
            MachineName = Environment.MachineName;
        }
    }
}
