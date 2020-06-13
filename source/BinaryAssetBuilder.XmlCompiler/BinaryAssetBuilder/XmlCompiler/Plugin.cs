using BinaryAssetBuilder.Core;
using SageBinaryData;

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
                    HandleLogicCommandSet(declaration, result);
                    break;
            }

            return result;
        }

        public void HandleLogicCommandSet(InstanceDeclaration declaration, AssetBuffer buffer)
        {
            // TODO:
            buffer.InstanceData = new byte[4];
            buffer.RelocationData = new byte[0];
            buffer.ImportsData = new byte[0];
        }
    }
}
