using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RebuildHoleExposeDieModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RebuildHoleExposeDieModuleData.HoleId), null), &objT->HoleId, state);
        Marshal(node.GetAttributeValue(nameof(RebuildHoleExposeDieModuleData.HoleMaxHealth), "0"), &objT->HoleMaxHealth, state);
        Marshal(node.GetAttributeValue(nameof(RebuildHoleExposeDieModuleData.FadeInSeconds), "0s"), &objT->FadeInSeconds, state);
        Marshal(node.GetAttributeValue(nameof(RebuildHoleExposeDieModuleData.TransferAttackers), "0"), &objT->TransferAttackers, state);
        Marshal(node, (DieModuleData*)objT, state);
    }
}
