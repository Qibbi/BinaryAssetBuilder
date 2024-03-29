﻿using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StatusBitsUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StatusBitsUpgradeModuleData.StatusToSet), null), &objT->StatusToSet, state);
        Marshal(node.GetAttributeValue(nameof(StatusBitsUpgradeModuleData.StatusToClear), null), &objT->StatusToClear, state);
#if KANESWRATH
        Marshal(node.GetAttributeValue(nameof(StatusBitsUpgradeModuleData.ApplyToContained), "false"), &objT->ApplyToContained, state);
#endif
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
