using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StancesBehaviorModuleData
    {
        public UpdateModuleData Base;
        public AssetReference<StanceTemplate> StanceTemplate;
    }
}
