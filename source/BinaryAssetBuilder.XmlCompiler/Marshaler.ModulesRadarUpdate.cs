﻿using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RadarUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RadarUpdateModuleData.RadarExtendTime), "0"), &objT->RadarExtendTime, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
