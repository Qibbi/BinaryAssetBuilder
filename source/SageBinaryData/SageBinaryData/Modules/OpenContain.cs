using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PassengerDataType
    {
        public AnsiString BonePrefix;
        public AnsiString Flags;
        public ObjectFilter Filter;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MemberTemplateStatusData
    {
        public TypedAssetId<GameObject> ThingTemplate;
        public ObjectStatusType ObjectStatus;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OpenContainModuleData
    {
        public UpdateModuleData Base;
        public uint ContainMax;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> EnterSound;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> ExitSound;
        public Percentage DamagePercentToUnits;
        public float PassengersTestCollisionHeight;
        public int NumberOfExitPaths;
        public uint DoorOpenTime;
        public ObjectStatusBitFlags ObjectStatusOfContained;
        public uint ModifierRequiredTime;
        public Time KillIfEmptyTime;
        public unsafe ObjectFilter* PassengerFilter;
        public unsafe ObjectFilter* ManualPickUpFilter;
        public unsafe DieMuxDataType* DieMuxData;
        public List<PassengerDataType> PassengerData;
        public List<AssetReference<AttributeModifier>> ModifierToGiveOnExit;
        public List<MemberTemplateStatusData> MemberTemplateStatusInfo;
        public SageBool PassengersInTurret;
        public SageBool AllowOwnPlayerInsideOverride;
        public SageBool AllowAlliesInside;
        public SageBool AllowEnemiesInside;
        public SageBool AllowNeutralInside;
        public SageBool ShowPips;
        public SageBool CollidePickup;
        public SageBool EjectPassengersOnDeath;
        public SageBool KillPassengersOnDeath;
        public SageBool HasObjectStatusOfContainedEntry;
        public SageBool Enabled;
    }
}
