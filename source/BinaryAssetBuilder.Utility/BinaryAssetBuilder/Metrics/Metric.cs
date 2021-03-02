using System;
using System.Text;

namespace BinaryAssetBuilder.Metrics
{
    public class Metric
    {
        private static readonly string[] _bytePostfix = new[]
        {
            "Bytes",
            "KiB",
            "MiB",
            "GiB",
            "TiB",
            "PiB",
            "EiB",
            "ZiB",
            "YiB"
        };

        private readonly MetricDescriptor _descriptor;
        private readonly object[] _dataList;
        private readonly DateTime _timestamp;

        public string Name => _descriptor.Name;
        public MetricDescriptor Descriptor => _descriptor;
        public DateTime Timestamp => _timestamp;
        public object Data => _dataList[0];
        public object[] DataList => _dataList;

        public Metric(MetricDescriptor descriptor, params object[] dataList)
        {
            _timestamp = DateTime.Now;
            _dataList = dataList;
            _descriptor = descriptor;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[{0:G}] {1}: ", _timestamp, _descriptor.Description);
            object obj = _dataList[0];
            switch (_descriptor.Type)
            {
                case MetricType.Duration:
                    sb.Append(TimeSpan.FromSeconds((double)obj).ToString());
                    break;
                case MetricType.Size:
                    double num = (long)obj;
                    foreach (string str in _bytePostfix)
                    {
                        if (num < 1024.0)
                        {
                            sb.AppendFormat("{0:n} {1}", num, str);
                            break;
                        }
                        num /= 1024.0;
                    }
                    break;
                default:
                    sb.Append(obj);
                    break;
            }
            if (_dataList.Length > 1)
            {
                sb.AppendFormat(" [ {0}", _dataList[1]);
                for (int idx = 2; idx < _dataList.Length; ++idx)
                {
                    sb.AppendFormat(", {0}", _dataList[idx]);
                }
                sb.Append(" ]");
            }
            return sb.ToString();
        }
    }
}
