#if KANESWRATH
using System.Runtime.InteropServices;
using Relo;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MetaPowerDataType
{
    public AnsiString Image;
    public AnsiString Title;
    public AnsiString Description;
    public AnsiString TypeDescription;
    public MetagameOperationsEnums MetaGameOp;
}

[StructLayout(LayoutKind.Sequential)]
public struct MetaGameStratButtonInfoModuleData
{
    public BehaviorModuleData Base;
    public AnsiString MetaGameDescription;
    public AnsiString MetaGameTypeDescription;
    public List<MetaPowerDataType> Powers;
}
#endif
