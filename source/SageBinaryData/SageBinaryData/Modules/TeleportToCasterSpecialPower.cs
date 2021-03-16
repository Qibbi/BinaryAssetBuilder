using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TeleportToCasterSpecialPowerModuleData
    {
        public SpecialAbilityUpdateModuleData Base;
        public float Radius;
        public float MinDestinationRadius;
        public float MaxDestinationRadius;
        public float MaxRangeFromCasterSP;
        public float MaxRangeFromCasterMP;
        public AssetReference<FXList> TriggerFX;
        public AssetReference<FXList> TargetFX;
        public SageBool RequireStoredObjects;
        public SageBool KillObjectsIfPlacedInBadSpot;
    }
}
