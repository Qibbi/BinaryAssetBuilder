using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentGameViewJoypad
    {
        public UIBaseComponent Base;
        public float LeftStickMultiplier;
        public float RightStickMultiplier;
        public float ObjectAttractivityForce;
        public float MinAttractDistance;
        public float MinAttractDistanceZoomed;
        public float MaxAttractiveForce;
        public KindOfBitFlags KindOfExemptFromAttraction;
        public float ScrollSpeedMin;
        public float ScrollSpeedMax;
        public float ScrollSpeedMaxCutoff;
        public float ScrollSpeedMinCutoff;
        public float InternalZoomInValue;
        public float InternalZoomOutValue;
        public float MagnetismTuning_LOW_Strength;
        public float MagnetismTuning_LOW_Distance;
        public float MagnetismTuning_HIGH_Strength;
        public float MagnetismTuning_HIGH_Distance;
        public unsafe ObjectFilter* MagnetismObjectFilter;
    }
}
