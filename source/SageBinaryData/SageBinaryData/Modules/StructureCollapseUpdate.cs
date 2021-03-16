using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum StructureCollapsePhaseType
    {
        INITIAL,
        DELAY,
        BURST,
        ALMOST_FINAL,
        FINAL
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SCBaseType
    {
        public StructureCollapsePhaseType Type;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SCFXListType
    {
        public SCBaseType Base;
        public List<AssetReference<FXList>> FX;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SCOCLListType
    {
        public SCBaseType Base;
        public List<AssetReference<ObjectCreationList>> OCL;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructureCollapseUpdateModuleData
    {
        public UpdateModuleData Base;
        public uint MinCollapseDelay;
        public uint MaxCollapseDelay;
        public uint MinBurstDelay;
        public uint MaxBurstDelay;
        public int BigBurstFrequency;
        public float CollapseDamping;
        public float MaxShudder;
        public float CollapseHeight;
        public AssetReference<WeaponTemplate> CrushingWeapon;
        public List<SCOCLListType> OCL;
        public List<SCFXListType> FX;
        public unsafe DieMuxDataType* Die;
        public SageBool DestroyObjectWhenDone;
    }
}
