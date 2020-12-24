using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UnitTypeIcon* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UnitTypeIcon.Image), null), &objT->Image, state);
        Marshal(node.GetChildNode(nameof(UnitTypeIcon.Offset), null), &objT->Offset, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}