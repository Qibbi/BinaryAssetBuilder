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
        public unsafe delegate void MarshalDelegate<T>(Node node, T* objT, Tracker state) where T : unmanaged;

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(XmlCompiler), "Marshals XML data into binary data structures.");
        // private static readonly int _win32 = 0;
        private static readonly int _xbox360 = 2;
        private static readonly int _xmlCompilerVersion = 1;
        private static readonly IDictionary<uint, MethodInfo> _handleMethods = new SortedDictionary<uint, MethodInfo>();
        private static readonly IDictionary<uint, Delegate> _marshalMethods = new SortedDictionary<uint, Delegate>();

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
            else
            {
                buffer.RelocationData = new byte[0];
            }
            if (chunk.ImportsBuffer.Length > 0)
            {
                buffer.ImportsData = chunk.ImportsBuffer;
            }
            else
            {
                buffer.ImportsData = new byte[0];
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
                case 0x064B2184u:
                    result.Type = typeof(ConnectionLineManager);
                    result.TypeName = nameof(ConnectionLineManager);
                    result.ProcessingHash = num ^ 0x7AEB73B2u;
                    result.TypeHash = 0x7AEB73B2u;
                    break;
                case 0x0CAD7864u:
                    result.Type = typeof(DLContent);
                    result.TypeName = nameof(DLContent);
                    result.ProcessingHash = num ^ 0x4E1A5713u;
                    result.TypeHash = 0x4E1A5713u;
                    break;
                case 0x1E0FC59Eu:
                    result.Type = typeof(InGameUIPlayerPowerCommandSlots);
                    result.TypeName = nameof(InGameUIPlayerPowerCommandSlots);
                    result.ProcessingHash = num ^ 0x4AB425C6u;
                    result.TypeHash = 0x4AB425C6u;
                    break;
                case 0x1F9865CEu:
                    result.Type = typeof(IntelDB);
                    result.TypeName = nameof(IntelDB);
                    result.ProcessingHash = num ^ 0xFBB64F90u;
                    result.TypeHash = 0xFBB64F90u;
                    break;
                case 0x21BA45A7u:
                    result.Type = typeof(ImageSequence);
                    result.TypeName = nameof(ImageSequence);
                    result.ProcessingHash = num ^ 0x217CF953u;
                    result.TypeHash = 0x217CF953u;
                    break;
                case 0x245EB4F9u:
                    result.Type = typeof(InGameUIVoiceChatCommandSlots);
                    result.TypeName = nameof(InGameUIVoiceChatCommandSlots);
                    result.ProcessingHash = num ^ 0x3592E352u;
                    result.TypeHash = 0x3592E352u;
                    break;
                case 0x2B49BF71u:
                    result.Type = typeof(Achievement);
                    result.TypeName = nameof(Achievement);
                    result.ProcessingHash = num ^ 0xC8D16E6Du;
                    result.TypeHash = 0xC8D16E6Du;
                    break;
                case 0x2C358B80u:
                    result.Type = typeof(MpGameRules);
                    result.TypeName = nameof(MpGameRules);
                    result.ProcessingHash = num ^ 0xEDDBB607u;
                    result.TypeHash = 0xEDDBB607u;
                    break;
                case 0x395A0FD6u:
                    result.Type = typeof(InGameUILookAtCommandSlots);
                    result.TypeName = nameof(InGameUILookAtCommandSlots);
                    result.ProcessingHash = num ^ 0x8F9F9918u;
                    result.TypeHash = 0x8F9F9918u;
                    break;
                case 0x5080A5D8u:
                    result.Type = typeof(MappableKey);
                    result.TypeName = nameof(MappableKey);
                    result.ProcessingHash = num ^ 0xE005A668u;
                    result.TypeHash = 0xE005A668u;
                    break;
                case 0x56626220u:
                    result.Type = typeof(PackedTextureImage);
                    result.TypeName = nameof(PackedTextureImage);
                    result.ProcessingHash = num ^ 0x2FAEB748u;
                    result.TypeHash = 0x2FAEB748u;
                    break;
                case 0x582FDC2Au:
                    result.Type = typeof(WaterTransparency);
                    result.TypeName = nameof(WaterTransparency);
                    result.ProcessingHash = num ^ 0x331DA6CEu;
                    result.TypeHash = 0x331DA6CEu;
                    break;
                case 0x6114137Eu:
                    result.Type = typeof(InGameUIGroupSelectionCommandSlots);
                    result.TypeName = nameof(InGameUIGroupSelectionCommandSlots);
                    result.ProcessingHash = num ^ 0xF6CE1A68u;
                    result.TypeHash = 0xF6CE1A68u;
                    break;
                case 0x7D464170u:
                    result.Type = typeof(LogicCommand);
                    result.TypeName = nameof(LogicCommand);
                    result.ProcessingHash = num ^ 0x97D0A46Eu;
                    result.TypeHash = 0x97D0A46Eu;
                    break;
                case 0x9053D603u:
                    result.Type = typeof(UnitOverlayIconSettings);
                    result.TypeName = nameof(UnitOverlayIconSettings);
                    result.ProcessingHash = num ^ 0xDFC78E66u;
                    result.TypeHash = 0xDFC78E66u;
                    break;
                case 0x90D951ADu:
                    result.Type = typeof(Weather);
                    result.TypeName = nameof(Weather);
                    result.ProcessingHash = num ^ 0x368A8BA2u;
                    result.TypeHash = 0x368A8BA2u;
                    break;
                case 0x94D4D96Eu:
                    result.Type = typeof(WeaponTemplate);
                    result.TypeName = nameof(WeaponTemplate);
                    result.ProcessingHash = num ^ 0xE3996069u;
                    result.TypeHash = 0xE3996069u;
                    break;
                case 0x98EE2743u:
                    result.Type = typeof(InGameUISideBarCommandSlots);
                    result.TypeName = nameof(InGameUISideBarCommandSlots);
                    result.ProcessingHash = num ^ 0xAF956455u;
                    result.TypeHash = 0xAF956455u;
                    break;
                case 0x9A104B07u:
                    result.Type = typeof(CommandSet);
                    result.TypeName = nameof(CommandSet);
                    result.ProcessingHash = num ^ 0x3CFF78A1u;
                    result.TypeHash = 0x3CFF78A1u;
                    break;
                case 0x928F51E4u:
                    result.Type = typeof(InGameUIFixedElementHotKeySlotMap);
                    result.TypeName = nameof(InGameUIFixedElementHotKeySlotMap);
                    result.ProcessingHash = num ^ 0x475EA260u;
                    result.TypeHash = 0x475EA260u;
                    break;
                case 0xA6E6BBA7u:
                    result.Type = typeof(HotKeySlot);
                    result.TypeName = nameof(HotKeySlot);
                    result.ProcessingHash = num ^ 0x1AC54E60u;
                    result.TypeHash = 0x1AC54E60u;
                    break;
                case 0xA78E592Eu:
                    result.Type = typeof(InGameUIUnitAbilityCommandSlots);
                    result.TypeName = nameof(InGameUIUnitAbilityCommandSlots);
                    result.ProcessingHash = num ^ 0x9DAA4182u;
                    result.TypeHash = 0x9DAA4182u;
                    break;
                case 0xA7A65DACu:
                    result.Type = typeof(InGameUITacticalCommandSlots);
                    result.TypeName = nameof(InGameUITacticalCommandSlots);
                    result.ProcessingHash = num ^ 0xC24AEFF1u;
                    result.TypeHash = 0xC24AEFF1u;
                    break;
                case 0xC8E41828u:
                    result.Type = typeof(BootupDisplaySequence);
                    result.TypeName = nameof(BootupDisplaySequence);
                    result.ProcessingHash = num ^ 0x84C1C2F0u;
                    result.TypeHash = 0x84C1C2F0u;
                    break;
                case 0xD76B50C7u:
                    result.Type = typeof(UnitTypeIcon);
                    result.TypeName = nameof(UnitTypeIcon);
                    result.ProcessingHash = num ^ 0xF7AB74BEu;
                    result.TypeHash = 0xF7AB74BEu;
                    break;
                case 0xD99C40A9u:
                    result.Type = typeof(PhaseEffect);
                    result.TypeName = nameof(PhaseEffect);
                    result.ProcessingHash = num ^ 0x4877D566u;
                    result.TypeHash = 0x4877D566u;
                    break;
                case 0xDEBF8788u:
                    result.Type = typeof(GameScriptList);
                    result.TypeName = nameof(GameScriptList);
                    result.ProcessingHash = num ^ 0x5AC6FA18u;
                    result.TypeHash = 0x5AC6FA18u;
                    break;
                case 0xDEFCA2F6:
                    result.Type = typeof(DefaultHotKeys);
                    result.TypeName = nameof(DefaultHotKeys);
                    result.ProcessingHash = num ^ 0x0E12479Du;
                    result.TypeHash = 0x0E12479Du;
                    break;
                case 0xEC066D65u:
                    result.Type = typeof(LogicCommandSet);
                    result.TypeName = nameof(LogicCommandSet);
                    result.ProcessingHash = num ^ 0x6D148BD7u;
                    result.TypeHash = 0x6D148BD7u;
                    break;
                case 0xECC2A1D3u:
                    result.Type = typeof(LocomotorTemplate);
                    result.TypeName = nameof(LocomotorTemplate);
                    result.ProcessingHash = num ^ 0xBD8F61A4u;
                    result.TypeHash = 0xBD8F61A4u;
                    break;
                case 0xF7CE0BBDu:
                    result.Type = typeof(ShadowMap);
                    result.TypeName = nameof(ShadowMap);
                    result.ProcessingHash = num ^ 0xC6389FA6u;
                    result.TypeHash = 0xC6389FA6u;
                    break;
                case 0xFC82DC06u:
                    result.Type = typeof(TheVersion);
                    result.TypeName = nameof(TheVersion);
                    result.ProcessingHash = num ^ 0xF659EF49u;
                    result.TypeHash = 0xF659EF49u;
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
            if (!_handleMethods.TryGetValue(declaration.Handle.TypeId, out MethodInfo handleType))
            {
                handleType = GetType().GetMethod(nameof(HandleType));
                ExtendedTypeInformation extendedTypeInformation = GetExtendedTypeInformation(declaration.Handle.TypeId);
                handleType = handleType.MakeGenericMethod(extendedTypeInformation.Type);
                if (handleType is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Unable to find handle method for type '{0}", extendedTypeInformation.TypeName);
                }
                _handleMethods.Add(extendedTypeInformation.TypeId, handleType);
            }
            handleType.Invoke(this, new object[] { declaration, result });
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
            if (!_marshalMethods.TryGetValue(declaration.Handle.TypeId, out Delegate marshal))
            {
                MethodInfo method = typeof(Marshaler).GetMethod(nameof(Marshaler.Marshal), new[] { typeof(Node), typeof(T*), typeof(Tracker) });
                if (method is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Cannot find marshal method for type '{0}'", typeof(T*).Name);
                }
                marshal = Delegate.CreateDelegate(typeof(MarshalDelegate<T>), method);
                if (marshal is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Cannot convert marshal method to delegate for type '{0}'", typeof(T*).Name);
                }
                _marshalMethods.Add(declaration.Handle.TypeId, marshal);
            }
            (marshal as MarshalDelegate<T>)(node, objT, tracker);
            WriteAssetBuffer(buffer, tracker);
        }
    }
}
