#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FloodMemberData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FloodMemberData.UnitType), null), &objT->UnitType, state);
        Marshal(node.GetAttributeValue(nameof(FloodMemberData.Speed), null), &objT->Speed, state);
        Marshal(node.GetChildNode(nameof(FloodMemberData.ControlPointOffsetOne), null), &objT->ControlPointOffsetOne, state);
        Marshal(node.GetChildNode(nameof(FloodMemberData.ControlPointOffsetTwo), null), &objT->ControlPointOffsetTwo, state);
        Marshal(node.GetChildNode(nameof(FloodMemberData.ControlPointOffsetThree), null), &objT->ControlPointOffsetThree, state);
        Marshal(node.GetChildNode(nameof(FloodMemberData.ControlPointOffsetFour), null), &objT->ControlPointOffsetFour, state);
    }

    public static unsafe void Marshal(Node node, FloodUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FloodUpdateModuleData.AngleOfFlow), "0"), &objT->AngleOfFlow, state);
        Marshal(node.GetAttributeValue(nameof(FloodUpdateModuleData.IsDirectionRelative), "false"), &objT->IsDirectionRelative, state);
        Marshal(node.GetChildNodes(nameof(FloodUpdateModuleData.DataList)), &objT->DataList, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
#endif
