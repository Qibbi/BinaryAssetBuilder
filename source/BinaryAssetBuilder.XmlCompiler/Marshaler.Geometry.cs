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

    private static unsafe void Marshal(Node node, ContactPoint** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(ContactPoint), 1u);
        Marshal(node, *objT, state);
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

    public static unsafe void Marshal(Node node, GeometryShape* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GeometryShape.Type), null), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(GeometryShape.Height), "0"), &objT->Height, state);
        Marshal(node.GetAttributeValue(nameof(GeometryShape.MajorRadius), "0"), &objT->MajorRadius, state);
        Marshal(node.GetAttributeValue(nameof(GeometryShape.MinorRadius), "0"), &objT->MinorRadius, state);
        Marshal(node.GetAttributeValue(nameof(GeometryShape.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(GeometryShape.BActive), "false"), &objT->BActive, state);
        Marshal(node.GetChildNode(nameof(GeometryShape.Offset), null), &objT->Offset, state);
    }

    public static unsafe void Marshal(Node node, GeometryInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GeometryInfo.IsSmall), "false"), &objT->IsSmall, state);
        Marshal(node.GetAttributeValue(nameof(GeometryInfo.BoundingCircleRadius), "0"), &objT->BoundingCircleRadius, state);
        Marshal(node.GetAttributeValue(nameof(GeometryInfo.BoundingSphereRadius), "0"), &objT->BoundingSphereRadius, state);
        Marshal(node.GetAttributeValue(nameof(GeometryInfo.XWidth), "0"), &objT->XWidth, state);
        Marshal(node.GetAttributeValue(nameof(GeometryInfo.YDepth), "0"), &objT->YDepth, state);
        Marshal(node.GetChildNodes(nameof(GeometryInfo.Shapes)), &objT->Shapes, state);
        Marshal(node.GetChildNode(nameof(GeometryInfo.RotationAnchorOffset), null), &objT->RotationAnchorOffset, state);
        Marshal(node.GetChildNode(nameof(GeometryInfo.Center), null), &objT->Center, state);
        Marshal(node.GetChildNode(nameof(GeometryInfo.HighestContactPoint), null), &objT->HighestContactPoint, state);
        Marshal(node.GetChildNode(nameof(GeometryInfo.InnermostContactPoint), null), &objT->InnermostContactPoint, state);
        Marshal(node.GetChildNode(nameof(GeometryInfo.ContactPoints), null), &objT->ContactPoints, state);
    }

    private static unsafe void Marshal(Node node, GeometryInfo** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(GeometryInfo), 1u);
        Marshal(node, *objT, state);
    }
}
