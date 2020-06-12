using BinaryAssetBuilder.Core;
using System;

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
                default:
                    result.TypeName = "<unknown>";
                    result.ProcessingHash = uint.MaxValue;
                    result.TypeHash = uint.MaxValue;
                    break;
            }
            return result;
        }

        public AssetBuffer ProcessInstance(InstanceDeclaration instance)
        {
            throw new NotImplementedException();
        }
    }
}
