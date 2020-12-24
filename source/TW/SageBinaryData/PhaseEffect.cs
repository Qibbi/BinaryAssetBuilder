using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TemporalSineWave
    {
        public Time WaveLength;
        public float Amplitude;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CameraShift
    {
        public ClientRandomVariable Randomness;
        public List<TemporalSineWave> SineWave;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PhaseEffect
    {
        public BaseInheritableAsset Base;
        public AssetReference<BaseRenderAssetType> PhaseMaskModel;
        public FXShaderMaterial PhaseStateShader;
        public CameraShift CameraShift;
    }
}
