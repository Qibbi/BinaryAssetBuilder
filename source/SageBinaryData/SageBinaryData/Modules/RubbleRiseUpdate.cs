using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum RubbleRisePhaseType
    {
        INITIAL,
        DELAY,
        BURST,
        FINAL
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RubbleRisePhaseEvent
    {
        public RubbleRisePhaseType Phase;
        public uint OclCount;
        public uint FxCount;
        public List<AssetReference<ObjectCreationList>> Ocl;
        public List<AssetReference<FXList>> Fx;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RubbleRiseUpdateModuleData
    {
        public UpdateModuleData Base;
        public int MinRubbleRiseDelay;
        public int MaxRubbleRiseDelay;
        public int MinBurstDelay;
        public int MaxBurstDelay;
        public int BigBurstFrequency;
        public float RubbleRiseDamping;
        public float RubbleHeight;
        public float MaxShudder;
        public List<RubbleRisePhaseEvent> Phase;
        public unsafe DieMuxDataType* Die;
    }
}
