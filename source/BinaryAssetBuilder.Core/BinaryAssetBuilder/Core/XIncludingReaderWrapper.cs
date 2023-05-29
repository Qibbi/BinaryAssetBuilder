using System;
using System.Globalization;
using System.Reflection;
using System.Xml;
using BinaryAssetBuilder.Core.Diagnostics;
using BinaryAssetBuilder.Core.IO;

namespace BinaryAssetBuilder.Core
{
    public class XIncludingReaderWrapper
    {
        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(XIncludingReaderWrapper), "Provides xi:include reading functionality");
        private static Assembly _library;

        public static void LoadAssembly()
        {
            try
            {
                _library = Assembly.Load("Mvp.Xml");
                _library.GetType("Mvp.Xml.XInclude.XIncludingReader");
            }
            catch
            {
                _library = null;
                _tracer.TraceError("Could not load XIncludingReader from Mvp.Xml.dll. xi:include is disabled.");
            }
        }

        public static XmlReader GetReader(XmlReader reader, FileNameXmlResolver resolver)
        {
            try
            {
                if (_library is not null)
                {
                    Type type = _library.GetType("Mvp.Xml.XInclude.XIncludingReader");
                    object instance = _library.CreateInstance("Mvp.Xml.XInclude.XIncludingReader", false, BindingFlags.CreateInstance, null, new object[] { reader }, null, null);
                    type.InvokeMember("XmlResolver", BindingFlags.SetProperty, null, instance, new object[] { resolver }, CultureInfo.InvariantCulture);
                    return (XmlReader)instance;
                }
            }
            catch
            {
                _tracer.TraceError("Could not load XIncludingReader from Mvp.Xml.dll. xi:include is disabled.");
            }
            return null;
        }
    }
}
