using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AudioLoopUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AudioLoopUpgradeModuleData.SoundToPlay), null), &objT->SoundToPlay, state);
        Marshal(node.GetAttributeValue(nameof(AudioLoopUpgradeModuleData.KillAfterMS), null), &objT->KillAfterMS, state);
        Marshal(node.GetAttributeValue(nameof(AudioLoopUpgradeModuleData.KillOnDeath), null), &objT->KillOnDeath, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
