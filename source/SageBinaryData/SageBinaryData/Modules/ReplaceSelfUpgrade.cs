using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ReplaceSelfUpgradeModuleData
    {
        public UpgradeModuleData Base;
        public Time NewObjectUnpackTime;
        public List<TypedAssetId<GameObject>> ReplacementTemplate;
        public SageBool DisabledDuringUnpack;
        public SageBool CheckBuildAssistant;
    }
}
