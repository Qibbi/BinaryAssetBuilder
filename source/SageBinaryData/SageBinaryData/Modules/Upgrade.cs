using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UpgradeModuleData
    {
        public BehaviorModuleData Base;
        public unsafe AnimAndDuration* CustomAnimAndDuration;
        public List<TypedAssetId<UpgradeTemplate>> TriggeredBy;
        public List<TypedAssetId<UpgradeTemplate>> ConflictsWith;
        public SageBool RequiresAllTriggers;
        public SageBool RequiresAllConflictingTriggers;
        public SageBool Permanent;
        public SageBool WaypointMode;
        public SageBool WaypointModeTerminal;
    }
}
