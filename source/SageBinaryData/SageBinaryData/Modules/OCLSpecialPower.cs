using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct OCLUpgradePair
    {
        public ScienceType Science;
        public AssetReference<ObjectCreationList> OCL;
    }

    public enum OCLCreateLocType
    {
        CREATE_AT_EDGE_NEAR_SOURCE,
        CREATE_AT_EDGE_NEAR_TARGET,
        CREATE_AT_EDGE_NEAR_TARGET_AND_MOVE_TO_LOCATION,
        CREATE_AT_LOCATION,
        USE_OWNER_OBJECT,
        CREATE_ABOVE_LOCATION,
        CREATE_AT_EDGE_FARTHEST_FROM_TARGET,
        CREATE_CLOSEST_TO_SPAWN_POINT,
        USE_SECONDARY_OBJECT_LOCATION,
        USE_MULTIPLE_SECONDARY_OBJECT_LOCATIONS,
        CREATE_AT_EDGE_NEAR_SECONDARY_TARGET,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OCLSpecialPowerModuleData
    {
        public SpecialPowerModuleData Base;
        public AssetReference<ObjectCreationList> OCL;
        public OCLCreateLocType CreateLocation;
        public uint MaxCreateCount;
        public uint NumberToSpawn;
        public AssetReference<ObjectCreationList> DestinationOCL;
        public List<OCLUpgradePair> UpgradeOCL;
        public unsafe ObjectFilter* NearestSecondaryObjectFilter;
        public List<AssetReference<UpgradeTemplate>> Upgrade;
        public SageBool RegisterObjectsWithSpecialAbilityUpdate;
    }
}
