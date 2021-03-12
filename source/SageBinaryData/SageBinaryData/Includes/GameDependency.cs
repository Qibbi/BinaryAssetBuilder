using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GameDependencyType
    {
        public ModelConditionBitFlags RequiredModelConditionsAny;
        public ModelConditionBitFlags ForbiddenModelConditions;
        public ObjectStatusBitFlags RequiredObjectStatusAny;
        public List<TypedAssetId<GameObject>> RequiredObject;
        public List<TypedAssetId<UpgradeTemplate>> ForbiddenUpgrade;
        public List<TypedAssetId<UpgradeTemplate>> NeededUpgrade;
        public unsafe ObjectFilter* ObjectFilter;
    }
}
