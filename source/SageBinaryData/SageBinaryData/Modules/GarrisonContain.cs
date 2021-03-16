using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InitialRoster
    {
        public TypedAssetId<GameObject> TemplateId;
        public int Count;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GarrisonContainModuleData
    {
        public OpenContainModuleData Base;
        public InitialRoster InitialRoster;
        public SageBool MobileGarrison;
        public SageBool ImmuneToClearBuildingAttacks;
        public SageBool ResetInitialTeamOnCapture;
    }
}
