using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ContactPoint* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ContactPoint.Label), null), &objT->Label, state);
        Marshal(node.GetChildNode(nameof(ContactPoint.Pos), null), &objT->Pos, state);
    }

    public static unsafe void Marshal(Node node, Shape* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Shape.Type), "SPHERE"), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(Shape.ContactPointGeneration), "NONE"), &objT->ContactPointGeneration, state);
        Marshal(node.GetAttributeValue(nameof(Shape.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(Shape.Active), "true"), &objT->Active, state);
        Marshal(node.GetAttributeValue(nameof(Shape.UsedForHealthBox), "true"), &objT->UsedForHealthBox, state);
        Marshal(node.GetAttributeValue(nameof(Shape.MajorRadius), "1.0"), &objT->MajorRadius, state);
        Marshal(node.GetAttributeValue(nameof(Shape.MinorRadius), "1.0"), &objT->MinorRadius, state);
        Marshal(node.GetAttributeValue(nameof(Shape.Other), null), &objT->Other, state);
        Marshal(node.GetAttributeValue(nameof(Shape.Height), "1.0"), &objT->Height, state);
        Marshal(node.GetAttributeValue(nameof(Shape.FrontAngle), null), &objT->FrontAngle, state);
        Marshal(node.GetChildNode(nameof(Shape.Offset), null), &objT->Offset, state);
    }

    public static unsafe void Marshal(Node node, Geometry* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Geometry.IsSmall), "false"), &objT->IsSmall, state);
        Marshal(node.GetChildNode(nameof(Geometry.RotationAnchorOffset), null), &objT->RotationAnchorOffset, state);
        Marshal(node.GetChildNodes(nameof(Geometry.Shape)), &objT->Shape, state);
        Marshal(node.GetChildNodes(nameof(Geometry.ContactPoint)), &objT->ContactPoint, state);
    }

    private static unsafe void Marshal(Node node, Geometry** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(Geometry), 1u);
        Marshal(node, *objT, state);
    }
}
