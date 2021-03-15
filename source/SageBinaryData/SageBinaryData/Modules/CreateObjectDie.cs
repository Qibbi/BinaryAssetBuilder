using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CreateObjectDieModuleData
    {
        public DieModuleData Base;
        public AssetReference<ObjectCreationList> CreationList;
        public AnsiString DebrisPortionOfSelf;
        public List<AssetReference<UpgradeTemplate>> UpgradeRequired;
        public List<AssetReference<UpgradeTemplate>> UpgradeForbidden;
    }
}
