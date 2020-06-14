using BinaryAssetBuilder.Core;
using Relo;
using SageBinaryData;
using System;
using System.Reflection;
using System.Xml;
using System.Xml.XPath;

namespace BinaryAssetBuilder.XmlCompiler
{
    public class Plugin : IAssetBuilderPlugin
    {
        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(XmlCompiler), "Marshals XML data into binary data structures.");
        private static int Win32 = 0;
        private static int Xbox360 = 2;
        private static int XmlCompilerVersion = 1;

        private TargetPlatform _platform;

        public void Initialize(object configObject, TargetPlatform targetPlatform)
        {
            _platform = targetPlatform;
        }

        public uint GetAllTypesHash()
        {
            return 0x12B3E763u; // KW 1.02
            // return 0xEB19D975u; // TW 1.09
        }

        public ExtendedTypeInformation GetExtendedTypeInformation(uint typeId)
        {
            ExtendedTypeInformation result = new ExtendedTypeInformation
            {
                HasCustomData = false,
                TypeId = typeId
            };
            uint num = (uint)XmlCompilerVersion;
            if (_platform == TargetPlatform.Xbox360)
            {
                num += (uint)Xbox360;
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
            Relo.Tracker tracker = Relo.Tracker.Create(&objT, isBigEndian);
            MethodInfo marshal = typeof(Marshaler).GetMethod("Marshal", new[] { typeof(Node), typeof(LogicCommandSet*), typeof(Tracker) });
            if (marshal is null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Cannot find marshal method for type '{0}'", typeof(T*).Name);
            }
            marshal.Invoke(null, new object[] { node, (IntPtr)objT, tracker });
            Relo.Chunk chunk = new Relo.Chunk();
            tracker.MakeRelocatable(chunk);
            buffer.InstanceData = new byte[chunk.InstanceBufferSize];
            if (chunk.InstanceBufferSize > 0u)
            {
                fixed (byte* pInstanceData = &buffer.InstanceData[0])
                {
                    Native.MsVcRt.MemCpy((IntPtr)pInstanceData, chunk.InstanceBuffer, new Native.SizeT(chunk.InstanceBufferSize));
                }
            }
            buffer.RelocationData = new byte[chunk.RelocationBufferSize];
            if (chunk.RelocationBufferSize > 0u)
            {
                fixed (byte* pRelocationData = &buffer.RelocationData[0])
                {
                    Native.MsVcRt.MemCpy((IntPtr)pRelocationData, chunk.RelocationBuffer, new Native.SizeT(chunk.RelocationBufferSize));
                }
            }
            buffer.ImportsData = new byte[chunk.ImportsBufferSize];
            if (chunk.ImportsBufferSize > 0u)
            {
                fixed (byte* pImportsData = &buffer.ImportsData[0])
                {
                    Native.MsVcRt.MemCpy((IntPtr)pImportsData, chunk.ImportsBuffer, new Native.SizeT(chunk.ImportsBufferSize));
                }
            }
        }
    }
}
