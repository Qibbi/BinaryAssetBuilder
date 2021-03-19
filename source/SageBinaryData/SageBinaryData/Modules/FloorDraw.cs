using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct W3DFloorDrawModuleData
    {
        public W3DPropDrawModuleData Base;
        public float FloorFadeRateOnObjectDeath;
        public List<WeatherTexture> WeatherTexture;
        public List<ModelConditionBitFlags> HideIfModelConditions;
        public SageBool StaticModelLODMode;
        public SageBool ForceToBack;
        public SageBool StartHidden;
    }
}
