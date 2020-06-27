using System;

namespace Native.Direct3D9
{
    public partial struct Capabilities
    {
        public Version PixelShaderVersion => new Version((_PixelShaderVersion >> 8) & 0xFF, _PixelShaderVersion & 0xFF);
        public Version VertexShaderVersion => new Version((_VertexShaderVersion >> 8) & 0xFF, _VertexShaderVersion & 0xFF);
    }
}
