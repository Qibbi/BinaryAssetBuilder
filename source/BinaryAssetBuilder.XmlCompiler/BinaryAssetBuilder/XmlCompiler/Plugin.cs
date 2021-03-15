using BinaryAssetBuilder.Core;
using BinaryAssetBuilder.Core.Diagnostics;
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

        public uint AllTypesHash => 0xEB19D975u; // TW 1.09; 0x12B3E763u; // KW 1.02
        public uint VersionNumber => 1;

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
                buffer.RelocationData = Array.Empty<byte>();
            }
            if (chunk.ImportsBuffer.Length > 0)
            {
                buffer.ImportsData = chunk.ImportsBuffer;
            }
            else
            {
                buffer.ImportsData = Array.Empty<byte>();
            }
        }

        public void Initialize(TargetPlatform platform)
        {
            _platform = platform;
        }

        public void ReInitialize(TargetPlatform platform)
        {
            Initialize(platform);
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
                case 0x036B677Bu:
                    result.Type = typeof(MusicScriptConditionNugget_TrackPlayedCount);
                    result.TypeName = nameof(MusicScriptConditionNugget_TrackPlayedCount);
                    result.ProcessingHash = num ^ 0x4FCFFAB1u;
                    result.TypeHash = 0x4FCFFAB1u;
                    break;
                case 0x0559C032u:
                    result.Type = typeof(TargetingCombatChainCompare);
                    result.TypeName = nameof(TargetingCombatChainCompare);
                    result.ProcessingHash = num ^ 0x553808EFu;
                    result.TypeHash = 0x553808EFu;
                    break;
                case 0x064B2184u:
                    result.Type = typeof(ConnectionLineManager);
                    result.TypeName = nameof(ConnectionLineManager);
                    result.ProcessingHash = num ^ 0x7AEB73B2u;
                    result.TypeHash = 0x7AEB73B2u;
                    break;
                case 0x0B3906FAu:
                    result.Type = typeof(MusicScriptConditionNugget_LocalPlayerIsObserver);
                    result.TypeName = nameof(MusicScriptConditionNugget_LocalPlayerIsObserver);
                    result.ProcessingHash = num ^ 0xAFB6AF3Au;
                    result.TypeHash = 0xAFB6AF3Au;
                    break;
                case 0x0B408BD4u:
                    result.Type = typeof(UnitAbilityButtonTemplateStore);
                    result.TypeName = nameof(UnitAbilityButtonTemplateStore);
                    result.ProcessingHash = num ^ 0x5A48D289u;
                    result.TypeHash = 0x5A48D289u;
                    break;
                case 0x0B63AEF0u:
                    result.Type = typeof(MultiplayerSettings);
                    result.TypeName = nameof(MultiplayerSettings);
                    result.ProcessingHash = num ^ 0x1BAF4C42u;
                    result.TypeHash = 0x1BAF4C42u;
                    break;
                case 0x0CAD7864u:
                    result.Type = typeof(DLContent);
                    result.TypeName = nameof(DLContent);
                    result.ProcessingHash = num ^ 0x4E1A5713u;
                    result.TypeHash = 0x4E1A5713u;
                    break;
                case 0x11D8BAC7u:
                    result.Type = typeof(AudioLOD);
                    result.TypeName = nameof(AudioLOD);
                    result.ProcessingHash = num ^ 0x3ABBF00Fu;
                    result.TypeHash = 0x3ABBF00Fu;
                    break;
                case 0x11E5CF64u:
                    result.Type = typeof(StringHashTable);
                    result.TypeName = nameof(StringHashTable);
                    result.ProcessingHash = num ^ 0x2C112832u;
                    result.TypeHash = 0x2C112832u;
                    break;
                case 0x12CFE3EFu:
                    result.Type = typeof(LocalBuildListMonitor);
                    result.TypeName = nameof(LocalBuildListMonitor);
                    result.ProcessingHash = num ^ 0x99CC030Au;
                    result.TypeHash = 0x99CC030Au;
                    break;
                case 0x151D037Cu:
                    result.Type = typeof(GameLODPreset);
                    result.TypeName = nameof(GameLODPreset);
                    result.ProcessingHash = num ^ 0x19DAC24Du;
                    result.TypeHash = 0x19DAC24Du;
                    break;
                case 0x17E53184u:
                    result.Type = typeof(CrowdResponse);
                    result.TypeName = nameof(CrowdResponse);
                    result.ProcessingHash = num ^ 0x66FB33A0u;
                    result.TypeHash = 0x66FB33A0u;
                    break;
                case 0x1A2DC767u:
                    result.Type = typeof(TheaterOfWarTemplate);
                    result.TypeName = nameof(TheaterOfWarTemplate);
                    result.ProcessingHash = num ^ 0xE60C9724u;
                    result.TypeHash = 0xE60C9724u;
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
                case 0x1FB298D1u:
                    result.Type = typeof(StaticGameLOD);
                    result.TypeName = nameof(StaticGameLOD);
                    result.ProcessingHash = num ^ 0xBEAF1CC9u;
                    result.TypeHash = 0xBEAF1CC9u;
                    break;
                case 0x1FD451BFu:
                    result.Type = typeof(LargeGroupAudioMap);
                    result.TypeName = nameof(LargeGroupAudioMap);
                    result.ProcessingHash = num ^ 0x9CBC0553u;
                    result.TypeHash = 0x9CBC0553u;
                    break;
                case 0x21BA45A7u:
                    result.Type = typeof(ImageSequence);
                    result.TypeName = nameof(ImageSequence);
                    result.ProcessingHash = num ^ 0x217CF953u;
                    result.TypeHash = 0x217CF953u;
                    break;
                case 0x242FF6D4u:
                    result.Type = typeof(AIStrategicStateDefinition);
                    result.TypeName = nameof(AIStrategicStateDefinition);
                    result.ProcessingHash = num ^ 0x1E27DA26u;
                    result.TypeHash = 0x1E27DA26u;
                    break;
                case 0x245EB4F9u:
                    result.Type = typeof(InGameUIVoiceChatCommandSlots);
                    result.TypeName = nameof(InGameUIVoiceChatCommandSlots);
                    result.ProcessingHash = num ^ 0x3592E352u;
                    result.TypeHash = 0x3592E352u;
                    break;
                case 0x2893E309u:
                    result.Type = typeof(SageBinaryData.Environment);
                    result.TypeName = nameof(SageBinaryData.Environment);
                    result.ProcessingHash = num ^ 0x878C42E0u;
                    result.TypeHash = 0x878C42E0u;
                    break;
                case 0x28E7FD7Fu:
                    result.Type = typeof(FXParticleSystemTemplate);
                    result.TypeName = nameof(FXParticleSystemTemplate);
                    result.ProcessingHash = num ^ 0xA148D511u;
                    result.TypeHash = 0xA148D511u;
                    break;
                case 0x2B49BF71u:
                    result.Type = typeof(Achievement);
                    result.TypeName = nameof(Achievement);
                    result.ProcessingHash = num ^ 0xC8D16E6Du;
                    result.TypeHash = 0xC8D16E6Du;
                    break;
                case 0x2C108648u:
                    result.Type = typeof(MusicScriptConditionNugget_SpecificTrackTypePlaying);
                    result.TypeName = nameof(MusicScriptConditionNugget_SpecificTrackTypePlaying);
                    result.ProcessingHash = num ^ 0xBCAD9B77u;
                    result.TypeHash = 0xBCAD9B77u;
                    break;
                case 0x2C358B80u:
                    result.Type = typeof(MpGameRules);
                    result.TypeName = nameof(MpGameRules);
                    result.ProcessingHash = num ^ 0xEDDBB607u;
                    result.TypeHash = 0xEDDBB607u;
                    break;
                case 0x30D2F544u:
                    result.Type = typeof(RadiusCursorLibrary);
                    result.TypeName = nameof(RadiusCursorLibrary);
                    result.ProcessingHash = num ^ 0xD62B490Fu;
                    result.TypeHash = 0xD62B490Fu;
                    break;
                case 0x33A671F8u:
                    result.Type = typeof(InGameUISettings);
                    result.TypeName = nameof(InGameUISettings);
                    result.ProcessingHash = num ^ 0x49FE3760u;
                    result.TypeHash = 0x49FE3760u;
                    break;
                case 0x373E10FAu:
                    result.Type = typeof(AITargetingHeuristic);
                    result.TypeName = nameof(AITargetingHeuristic);
                    result.ProcessingHash = num ^ 0xB7A2C222u;
                    result.TypeHash = 0xB7A2C222u;
                    break;
                case 0x395A0FD6u:
                    result.Type = typeof(InGameUILookAtCommandSlots);
                    result.TypeName = nameof(InGameUILookAtCommandSlots);
                    result.ProcessingHash = num ^ 0x8F9F9918u;
                    result.TypeHash = 0x8F9F9918u;
                    break;
                case 0x3A6C5E8Eu:
                    result.Type = typeof(ArmorTemplate);
                    result.TypeName = nameof(ArmorTemplate);
                    result.ProcessingHash = num ^ 0x9CDD1086u;
                    result.TypeHash = 0x9CDD1086u;
                    break;
                case 0x3A9CE0B0u:
                    result.Type = typeof(AptConstData);
                    result.TypeName = nameof(AptConstData);
                    result.ProcessingHash = num ^ 0x1CE8E595u;
                    result.TypeHash = 0x1CE8E595u;
                    break;
                case 0x3DAA8C20u:
                    result.Type = typeof(AptGeometryData);
                    result.TypeName = nameof(AptGeometryData);
                    result.ProcessingHash = num ^ 0x58F89E8Bu;
                    result.TypeHash = 0x58F89E8Bu;
                    break;
                case 0x3DDFA8BDu:
                    result.Type = typeof(MusicScriptTrack);
                    result.TypeName = nameof(MusicScriptTrack);
                    result.ProcessingHash = num ^ 0x702C8407u;
                    result.TypeHash = 0x702C8407u;
                    break;
                case 0x423395E1u:
                    result.Type = typeof(AptDatData);
                    result.TypeName = nameof(AptDatData);
                    result.ProcessingHash = num ^ 0x3BF7FEB9u;
                    result.TypeHash = 0x3BF7FEB9u;
                    break;
                case 0x44A5973Du:
                    result.Type = typeof(ObjectFilterAsset);
                    result.TypeName = nameof(ObjectFilterAsset);
                    result.ProcessingHash = num ^ 0x25970AF7u;
                    result.TypeHash = 0x25970AF7u;
                    break;
                case 0x5016F8C3u:
                    result.Type = typeof(MusicScriptConditionNugget_And);
                    result.TypeName = nameof(MusicScriptConditionNugget_And);
                    result.ProcessingHash = num ^ 0x10173347u;
                    result.TypeHash = 0x10173347u;
                    break;
                case 0x502EED32u:
                    result.Type = typeof(OnlineChatColors);
                    result.TypeName = nameof(OnlineChatColors);
                    result.ProcessingHash = num ^ 0xF3645AA7u;
                    result.TypeHash = 0xF3645AA7u;
                    break;
                case 0x5080A5D8u:
                    result.Type = typeof(MappableKey);
                    result.TypeName = nameof(MappableKey);
                    result.ProcessingHash = num ^ 0xE005A668u;
                    result.TypeHash = 0xE005A668u;
                    break;
                case 0x5608EE71u:
                    result.Type = typeof(AudioSettings);
                    result.TypeName = nameof(AudioSettings);
                    result.ProcessingHash = num ^ 0x89AA7DDEu;
                    result.TypeHash = 0x89AA7DDEu;
                    break;
                case 0x564A9693u:
                    result.Type = typeof(VideoEventList);
                    result.TypeName = nameof(VideoEventList);
                    result.ProcessingHash = num ^ 0x999FCBE3u;
                    result.TypeHash = 0x999FCBE3u;
                    break;
                case 0x56626220u:
                    result.Type = typeof(PackedTextureImage);
                    result.TypeName = nameof(PackedTextureImage);
                    result.ProcessingHash = num ^ 0x2FAEB748u;
                    result.TypeHash = 0x2FAEB748u;
                    break;
                case 0x57495B42u:
                    result.Type = typeof(MusicScriptConditionNugget_TimeFromStartOfLevel);
                    result.TypeName = nameof(MusicScriptConditionNugget_TimeFromStartOfLevel);
                    result.ProcessingHash = num ^ 0xAA4A9E23u;
                    result.TypeHash = 0xAA4A9E23u;
                    break;
                case 0x582FDC2Au:
                    result.Type = typeof(WaterTransparency);
                    result.TypeName = nameof(WaterTransparency);
                    result.ProcessingHash = num ^ 0x331DA6CEu;
                    result.TypeHash = 0x331DA6CEu;
                    break;
                case 0x585E034Eu:
                    result.Type = typeof(CampaignTemplate);
                    result.TypeName = nameof(CampaignTemplate);
                    result.ProcessingHash = num ^ 0xAC60B530u;
                    result.TypeHash = 0xAC60B530u;
                    break;
                case 0x5F969146u:
                    result.Type = typeof(MapMetaDataType);
                    result.TypeName = nameof(MapMetaDataType);
                    result.ProcessingHash = num ^ 0x59013A51u;
                    result.TypeHash = 0x59013A51u;
                    break;
                case 0x6114137Eu:
                    result.Type = typeof(InGameUIGroupSelectionCommandSlots);
                    result.TypeName = nameof(InGameUIGroupSelectionCommandSlots);
                    result.ProcessingHash = num ^ 0xF6CE1A68u;
                    result.TypeHash = 0xF6CE1A68u;
                    break;
                case 0x66219699u:
                    result.Type = typeof(PlayerPowerButtonTemplateStore);
                    result.TypeName = nameof(PlayerPowerButtonTemplateStore);
                    result.ProcessingHash = num ^ 0xDB57AB4Fu;
                    result.TypeHash = 0xDB57AB4Fu;
                    break;
                case 0x6C41E6DCu:
                    result.Type = typeof(AptAptData);
                    result.TypeName = nameof(AptAptData);
                    result.ProcessingHash = num ^ 0x36866072u;
                    result.TypeHash = 0x36866072u;
                    break;
                case 0x6CDDC801u:
                    result.Type = typeof(MissionObjectiveList);
                    result.TypeName = nameof(MissionObjectiveList);
                    result.ProcessingHash = num ^ 0xC385A8C1u;
                    result.TypeHash = 0xC385A8C1u;
                    break;
                case 0x6FBC4A9Fu:
                    result.Type = typeof(ExperienceLevelTemplate);
                    result.TypeName = nameof(ExperienceLevelTemplate);
                    result.ProcessingHash = num ^ 0xAE55047Bu;
                    result.TypeHash = 0xAE55047Bu;
                    break;
                case 0x7046D9F8u:
                    result.Type = typeof(MusicTrack);
                    result.TypeName = nameof(MusicTrack);
                    result.ProcessingHash = num ^ 0x1469548Au;
                    result.TypeHash = 0x1469548Au;
                    break;
                case 0x77AC3B08u:
                    result.Type = typeof(TargetingInTurretArcCompare);
                    result.TypeName = nameof(TargetingInTurretArcCompare);
                    result.ProcessingHash = num ^ 0xCD24391Au;
                    result.TypeHash = 0xCD24391Au;
                    break;
                case 0x7B6AE7D5u:
                    result.Type = typeof(MiscAudio);
                    result.TypeName = nameof(MiscAudio);
                    result.ProcessingHash = num ^ 0xFA4817E2u;
                    result.TypeHash = 0xFA4817E2u;
                    break;
                case 0x7D464170u:
                    result.Type = typeof(LogicCommand);
                    result.TypeName = nameof(LogicCommand);
                    result.ProcessingHash = num ^ 0x97D0A46Eu;
                    result.TypeHash = 0x97D0A46Eu;
                    break;
                case 0x81D85EFAu:
                    result.Type = typeof(SpecialPowerTemplate);
                    result.TypeName = nameof(SpecialPowerTemplate);
                    result.ProcessingHash = num ^ 0x5EF0ACA9u;
                    result.TypeHash = 0x5EF0ACA9u;
                    break;
                case 0x844D7B9Fu:
                    result.Type = typeof(AudioEvent);
                    result.TypeName = nameof(AudioEvent);
                    result.ProcessingHash = num ^ 0x1B886049u;
                    result.TypeHash = 0x1B886049u;
                    break;
                case 0x86682E78u:
                    result.Type = typeof(FXList);
                    result.TypeName = nameof(FXList);
                    result.ProcessingHash = num ^ 0xEBE8A8A4u;
                    result.TypeHash = 0xEBE8A8A4u;
                    break;
                case 0x88011B0Eu:
                    result.Type = typeof(MusicScriptConditionNugget_Or);
                    result.TypeName = nameof(MusicScriptConditionNugget_Or);
                    result.ProcessingHash = num ^ 0x81114695u;
                    result.TypeHash = 0x81114695u;
                    break;
                case 0x8CA5A7D7u:
                    result.Type = typeof(TargetingDistanceCompare);
                    result.TypeName = nameof(TargetingDistanceCompare);
                    result.ProcessingHash = num ^ 0xED45F096u;
                    result.TypeHash = 0xED45F096u;
                    break;
                case 0x8E28081Du:
                    result.Type = typeof(MultiplayerColor);
                    result.TypeName = nameof(MultiplayerColor);
                    result.ProcessingHash = num ^ 0x966F336Au;
                    result.TypeHash = 0x966F336Au;
                    break;
                case 0x8F7DC19Bu:
                    result.Type = typeof(MusicPalette);
                    result.TypeName = nameof(MusicPalette);
                    result.ProcessingHash = num ^ 0x6A7AF822u;
                    result.TypeHash = 0x6A7AF822u;
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
                case 0x9684C743u:
                    result.Type = typeof(StanceTemplate);
                    result.TypeName = nameof(StanceTemplate);
                    result.ProcessingHash = num ^ 0x5C6E0E41u;
                    result.TypeHash = 0x5C6E0E41u;
                    break;
                case 0x9687F57Bu:
                    result.Type = typeof(Mouse);
                    result.TypeName = nameof(Mouse);
                    result.ProcessingHash = num ^ 0x73FE99B0u;
                    result.TypeHash = 0x73FE99B0u;
                    break;
                case 0x9C361A08u:
                    result.Type = typeof(MusicScriptConditionNugget_UnitsFarFromBase);
                    result.TypeName = nameof(MusicScriptConditionNugget_UnitsFarFromBase);
                    result.ProcessingHash = num ^ 0xD889BF98u;
                    result.TypeHash = 0xD889BF98u;
                    break;
                case 0x942FFF2Du:
                    result.Type = typeof(GameObject);
                    result.TypeName = nameof(GameObject);
                    result.ProcessingHash = num ^ 0x132408DBu;
                    result.TypeHash = 0x132408DBu;
                    break;
                case 0xA38DB775u:
                    result.Type = typeof(MusicScriptConditionNugget_EvaEventPlayedRecently);
                    result.TypeName = nameof(MusicScriptConditionNugget_EvaEventPlayedRecently);
                    result.ProcessingHash = num ^ 0x1F200F13u;
                    result.TypeHash = 0x1F200F13u;
                    break;
                case 0xA3A7AF37u:
                    result.Type = typeof(Multisound);
                    result.TypeName = nameof(Multisound);
                    result.ProcessingHash = num ^ 0x12B1C67Cu;
                    result.TypeHash = 0x12B1C67Cu;
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
                case 0xAC78CE63u:
                    result.Type = typeof(AIBudgetStateDefinition);
                    result.TypeName = nameof(AIBudgetStateDefinition);
                    result.ProcessingHash = num ^ 0xA10F9630u;
                    result.TypeHash = 0xA10F9630u;
                    break;
                case 0xACEF31A4u:
                    result.Type = typeof(DynamicGameLOD);
                    result.TypeName = nameof(DynamicGameLOD);
                    result.ProcessingHash = num ^ 0x71BAD792u;
                    result.TypeHash = 0x71BAD792u;
                    break;
                case 0xAD3568F5u:
                    result.Type = typeof(DamageFX);
                    result.TypeName = nameof(DamageFX);
                    result.ProcessingHash = num ^ 0x4DF81EBDu;
                    result.TypeHash = 0x4DF81EBDu;
                    break;
                case 0xB71D7323u:
                    result.Type = typeof(UIConfigList);
                    result.TypeName = nameof(UIConfigList);
                    result.ProcessingHash = num ^ 0xB3B7607Au;
                    result.TypeHash = 0xB3B7607Au;
                    break;
                case 0xBE06A9E5u:
                    result.Type = typeof(TargetingCompareList);
                    result.TypeName = nameof(TargetingCompareList);
                    result.ProcessingHash = num ^ 0x57CA5C81u;
                    result.TypeHash = 0x57CA5C81u;
                    break;
                case 0xC11D7E83u:
                    result.Type = typeof(AIStateDefinition);
                    result.TypeName = nameof(AIStateDefinition);
                    result.ProcessingHash = num ^ 0x262BE85Fu;
                    result.TypeHash = 0x262BE85Fu;
                    break;
                case 0xC5E07887u:
                    result.Type = typeof(AttributeModifier);
                    result.TypeName = nameof(AttributeModifier);
                    result.ProcessingHash = num ^ 0xD24E7201u;
                    result.TypeHash = 0xD24E7201u;
                    break;
                case 0xC8E41828u:
                    result.Type = typeof(BootupDisplaySequence);
                    result.TypeName = nameof(BootupDisplaySequence);
                    result.ProcessingHash = num ^ 0x84C1C2F0u;
                    result.TypeHash = 0x84C1C2F0u;
                    break;
                case 0xC9DD2E6Du:
                    result.Type = typeof(MusicScriptConditionNugget_ObjectsNearEvaEvent);
                    result.TypeName = nameof(MusicScriptConditionNugget_ObjectsNearEvaEvent);
                    result.ProcessingHash = num ^ 0x0EC4D160u;
                    result.TypeHash = 0x0EC4D160u;
                    break;
                case 0xCAD58CC1u:
                    result.Type = typeof(MusicScriptConditionNugget_AnyTrackPlaying);
                    result.TypeName = nameof(MusicScriptConditionNugget_AnyTrackPlaying);
                    result.ProcessingHash = num ^ 0x337BC326u;
                    result.TypeHash = 0x337BC326u;
                    break;
                case 0xCF4AED23u:
                    result.Type = typeof(MissionTemplate);
                    result.TypeName = nameof(MissionTemplate);
                    result.ProcessingHash = num ^ 0x0D283295u;
                    result.TypeHash = 0x0D283295u;
                    break;
                case 0xD19D90C6u:
                    result.Type = typeof(Road);
                    result.TypeName = nameof(Road);
                    result.ProcessingHash = num ^ 0xDCF3C28Bu;
                    result.TypeHash = 0xDCF3C28Bu;
                    break;
                case 0xD414D1C3u:
                    result.Type = typeof(DialogEvent);
                    result.TypeName = nameof(DialogEvent);
                    result.ProcessingHash = num ^ 0x8655CDB4u;
                    result.TypeHash = 0x8655CDB4u;
                    break;
                case 0xD51AE5E1u:
                    result.Type = typeof(GameMap);
                    result.TypeName = nameof(GameMap);
                    result.ProcessingHash = num ^ 0x3EC9C79Bu;
                    result.TypeHash = 0x3EC9C79Bu;
                    break;
                case 0xD5D580F6u:
                    result.Type = typeof(ArmyDefinition);
                    result.TypeName = nameof(ArmyDefinition);
                    result.ProcessingHash = num ^ 0x57213EA5u;
                    result.TypeHash = 0x57213EA5u;
                    break;
                case 0xD6D4F18Eu:
                    result.Type = typeof(AIPersonalityDefinition);
                    result.TypeName = nameof(AIPersonalityDefinition);
                    result.ProcessingHash = num ^ 0x7DCE182Fu;
                    result.TypeHash = 0x7DCE182Fu;
                    break;
                case 0xD76B50C7u:
                    result.Type = typeof(UnitTypeIcon);
                    result.TypeName = nameof(UnitTypeIcon);
                    result.ProcessingHash = num ^ 0xF7AB74BEu;
                    result.TypeHash = 0xF7AB74BEu;
                    break;
                case 0xD7D07964u:
                    result.Type = typeof(MusicScriptConditionNugget_ScoredKillCount);
                    result.TypeName = nameof(MusicScriptConditionNugget_ScoredKillCount);
                    result.ProcessingHash = num ^ 0x5C0F93DCu;
                    result.TypeHash = 0x5C0F93DCu;
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
                case 0xDEFCA2F6u:
                    result.Type = typeof(DefaultHotKeys);
                    result.TypeName = nameof(DefaultHotKeys);
                    result.ProcessingHash = num ^ 0x0E12479Du;
                    result.TypeHash = 0x0E12479Du;
                    break;
                case 0xE1AFE75Bu:
                    result.Type = typeof(UpgradeTemplate);
                    result.TypeName = nameof(UpgradeTemplate);
                    result.ProcessingHash = num ^ 0x1E53F384u;
                    result.TypeHash = 0x1E53F384u;
                    break;
                case 0xE86E4D61u:
                    result.Type = typeof(ObjectCreationList);
                    result.TypeName = nameof(ObjectCreationList);
                    result.ProcessingHash = num ^ 0x683D4DE5u;
                    result.TypeHash = 0x683D4DE5u;
                    break;
                case 0xEA2C2798u:
                    result.Type = typeof(AmbientStream);
                    result.TypeName = nameof(AmbientStream);
                    result.ProcessingHash = num ^ 0xDABB1C4Bu;
                    result.TypeHash = 0xDABB1C4Bu;
                    break;
                case 0xEC066D65u:
                    result.Type = typeof(LogicCommandSet);
                    result.TypeName = nameof(LogicCommandSet);
                    result.ProcessingHash = num ^ 0x6D148BD7u;
                    result.TypeHash = 0x6D148BD7u;
                    break;
                case 0xECBE73E8u:
                    result.Type = typeof(SkirmishOpeningMove);
                    result.TypeName = nameof(SkirmishOpeningMove);
                    result.ProcessingHash = num ^ 0x21EE29FAu;
                    result.TypeHash = 0x21EE29FAu;
                    break;
                case 0xECC2A1D3u:
                    result.Type = typeof(LocomotorTemplate);
                    result.TypeName = nameof(LocomotorTemplate);
                    result.ProcessingHash = num ^ 0xBD8F61A4u;
                    result.TypeHash = 0xBD8F61A4u;
                    break;
                case 0xEED6A240u:
                    result.Type = typeof(MusicScriptConditionNugget_Not);
                    result.TypeName = nameof(MusicScriptConditionNugget_Not);
                    result.ProcessingHash = num ^ 0xB886383Bu;
                    result.TypeHash = 0xB886383Bu;
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
                case 0xFF7BDFBFu:
                    result.Type = typeof(MusicScriptConditionNugget_ObjectsOfTypeExist);
                    result.TypeName = nameof(MusicScriptConditionNugget_ObjectsOfTypeExist);
                    result.ProcessingHash = num ^ 0x9586411Cu;
                    result.TypeHash = 0x9586411Cu;
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
