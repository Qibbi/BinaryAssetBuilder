using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct StancesBehaviorModuleData
{
    public UpdateModuleData Base;
    public AssetReference<StanceTemplate> StanceTemplate;
}
