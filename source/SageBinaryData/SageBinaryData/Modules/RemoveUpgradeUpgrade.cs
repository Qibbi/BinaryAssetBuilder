using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RemoveUpgradeUpgradeModuleData
    {
        public UpgradeModuleData Base;
        public List<AnsiString> UpradesGroupsToRemove;
        public List<TypedAssetId<UpgradeTemplate>> UpgradeToRemove;
        public SageBool SuppressEvaEventForRemoval;
        public SageBool RemoveFromAllPlayerObjects;
    }
}
