using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct W3DHordeModelDrawModuleDataLodOptions
    {
        public int MaxRandomTextures;
        public int MaxRandomAnimations;
        public float MaxFrameDelta;
        public Percentage RandomStartFramePercent;
        public SageBool MultipleModels;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct W3DHordeModelDrawModuleData
    {
        public W3DScriptedModelDrawModuleData Base;
        public List<W3DHordeModelDrawModuleDataLodOptions> LodOptions;
    }
}
