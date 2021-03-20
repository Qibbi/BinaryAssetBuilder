using Relo;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct W3DMeshVertexData
{
    public int NumVertices;
    public List<byte> VertexElementData;
    public List<byte> VertexDeclaration;
    public List<ushort> Bones;
}
