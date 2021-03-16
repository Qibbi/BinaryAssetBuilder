using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GeometryUpgradeModuleData
    {
        public UpgradeModuleData Base;
        public List<AnsiString> ShowGeometry;
        public List<AnsiString> HideGeometry;
        public AnsiString WallBoundsMesh;
        public AnsiString RampMesh1;
        public AnsiString RampMesh2;
    }
}
