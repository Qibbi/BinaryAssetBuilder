using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AimWeaponBehaviorModuleData
    {
        public UpdateModuleData Base;
        public float AimLowThreshold;
        public float AimHighThreshold;
        public float AimNearDistance;
        public float AimFarDistance;
    }
}
