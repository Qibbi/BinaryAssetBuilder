using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential, Size = 12)]
    public struct LogicCommandSet
    {
        public BaseInheritableAsset Base;
        public List<AssetReference<LogicCommand>> Cmd;
    }
}
