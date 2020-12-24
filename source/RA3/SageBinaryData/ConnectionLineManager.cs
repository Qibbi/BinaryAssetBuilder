using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ConnectionLineManager
    {
        public BaseInheritableAsset Base;
        public FXShaderMaterial FXShader;
    }
}
