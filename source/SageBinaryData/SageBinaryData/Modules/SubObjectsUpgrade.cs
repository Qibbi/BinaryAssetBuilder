using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct SubObjectsUpgradeModuleData
{
    public UpgradeModuleData Base;
    public List<AnsiString> ShowSubObjects;
    public List<AnsiString> HideSubObjects;
    public float FadeTimeInSeconds;
    public float WaitBeforeFadeInSeconds;
    public List<AnsiString> ExcludeSubobjects;
    public List<ReplaceTexture> UpgradeTexture;
    public SageBool RecolorHouse;
    public SageBool SkipFadeOnCreate;
    public SageBool HideSubObjectsOnRemove;
    public SageBool UnHideSubObjectsOnRemove;
}
