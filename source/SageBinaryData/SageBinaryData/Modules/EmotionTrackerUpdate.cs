using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct EmotionTrackerUpdateModuleData
    {
        public UpdateModuleData Base;
        public float TauntAndPointDistance;
        public float HeroScanDistance;
        public Time TauntAndPointUpdateDelay;
        public float FearScanDistance;
        public Percentage QuarrelProbability;
        public int ImmuneToFearLevel;
        public unsafe ObjectFilter* TauntAndPointExcluded;
        public unsafe ObjectFilter* AfraidOf;
        public unsafe ObjectFilter* AlwaysAfraidOf;
        public unsafe ObjectFilter* PointAt;
        public List<AnsiString> AddEmotion;
        public SageBool IgnoreVeterancy;
    }
}
