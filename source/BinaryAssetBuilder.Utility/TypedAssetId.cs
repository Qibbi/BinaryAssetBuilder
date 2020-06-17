using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct TypedAssetId<T> where T : unmanaged
{
    public uint InstanceId;
}
