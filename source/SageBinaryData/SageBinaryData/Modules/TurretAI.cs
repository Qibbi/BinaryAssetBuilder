using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TurretAIData
    {
        public float TurretTurnRate;
        public float TurretPitchRate;
        public Angle MinimumPitch;
        public Percentage PitchHeight;
        public WeaponSlotBitFlags ControlledWeaponSlots;
        public Time MinIdleScanTime;
        public Time MaxIdleScanTime;
        public float MinIdleScanAngle;
        public float MaxIdleScanAngle;
        public Angle MaxDeflectionClockwise;
        public Angle MaxDeflectionAntiClockwise;
        public Angle NaturalTurretAngle;
        public unsafe TurretAITargetChooserData* TurretAITargetChooserData;
        public SageBool AllowsPitch;
        public SageBool RecenterWhenOutOfTurnRange;
    }
}
