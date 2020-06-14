using BinaryAssetBuilder.Core;
using Relo;
using SageBinaryData;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.XPath;

namespace BinaryAssetBuilder.XmlCompiler
{
    public class Plugin : IAssetBuilderPlugin
    {
        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(XmlCompiler), "Marshals XML data into binary data structures.");
        private static readonly int _win32 = 0;
        private static readonly int _xbox360 = 2;
        private static readonly int _xmlCompilerVersion = 1;
        private static readonly Dictionary<Type, MethodInfo> _marshalMethods = new Dictionary<Type, MethodInfo>();

        private TargetPlatform _platform;

        private unsafe void WriteAssetBuffer(AssetBuffer buffer, Tracker tracker)
        {
            Relo.Chunk chunk = new Relo.Chunk();
            tracker.MakeRelocatable(chunk);
            buffer.InstanceData = chunk.InstanceBuffer;
            if (chunk.RelocationBuffer.Length > 0)
            {
                buffer.RelocationData = chunk.RelocationBuffer;
            }
            if (chunk.ImportsBuffer.Length > 0)
            {
                buffer.ImportsData = chunk.ImportsBuffer;
            }
        }

        public void Initialize(object configObject, TargetPlatform targetPlatform)
        {
            _platform = targetPlatform;
        }

        public uint GetAllTypesHash()
        {
            // return 0x12B3E763u; // KW 1.02
            return 0xEB19D975u; // TW 1.09
        }

        public ExtendedTypeInformation GetExtendedTypeInformation(uint typeId)
        {
            ExtendedTypeInformation result = new ExtendedTypeInformation
            {
                HasCustomData = false,
                TypeId = typeId
            };
            uint num = (uint)_xmlCompilerVersion;
            if (_platform == TargetPlatform.Xbox360)
            {
                num += (uint)_xbox360;
            }
            switch (typeId)
            {
                case 0xEC066D65u:
                    result.TypeName = nameof(LogicCommandSet);
                    result.ProcessingHash = num ^ 0x6D148BD7u;
                    result.TypeHash = 0x6D148BD7u;
                    break;
                default:
                    result.TypeName = "<unknown>";
                    result.ProcessingHash = 0u;
                    result.TypeHash = 0u;
                    break;
            }
            return result;
        }

        public AssetBuffer ProcessInstance(InstanceDeclaration declaration)
        {
            AssetBuffer result = new AssetBuffer();
            switch (declaration.Handle.TypeId)
            {
                case 0xEC066D65u:
                    HandleType<LogicCommandSet>(declaration, result);
                    break;
            }

            return result;
        }

        public unsafe void HandleType<T>(InstanceDeclaration declaration, AssetBuffer buffer) where T : unmanaged
        {
            bool isBigEndian = _platform == TargetPlatform.Xbox360;
            XmlNamespaceManager namespaceManager = declaration.Document.NamespaceManager;
            XPathNavigator navigator = declaration.Node.CreateNavigator();
            Node node = new Node(navigator, namespaceManager);
            T* objT;
            using Tracker tracker = new Tracker((void**)&objT, (uint)sizeof(T), isBigEndian);
            if (!_marshalMethods.TryGetValue(typeof(T), out MethodInfo marshal))
            {
                marshal = typeof(Marshaler).GetMethod("Marshal", new[] { typeof(Node), typeof(T*), typeof(Tracker) });
                if (marshal is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Unable to find marshal method for type '{0}'", typeof(T).Name);
                }
                _marshalMethods.Add(typeof(T), marshal);
            }
            marshal.Invoke(null, new object[] { node, (IntPtr)objT, tracker });
            WriteAssetBuffer(buffer, tracker);
        }
    }
}
