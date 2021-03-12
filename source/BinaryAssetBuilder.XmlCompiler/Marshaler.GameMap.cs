using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StringPropertyPair* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StringPropertyPair.Key), null), &objT->Key, state);
        Marshal(node.GetAttributeValue(nameof(StringPropertyPair.Value), null), &objT->Value, state);
    }

    public static unsafe void Marshal(Node node, BoolPropertyPair* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(BoolPropertyPair.Key), null), &objT->Key, state);
        Marshal(node.GetAttributeValue(nameof(BoolPropertyPair.Value), null), &objT->Value, state);
    }

    public static unsafe void Marshal(Node node, IntPropertyPair* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(IntPropertyPair.Key), null), &objT->Key, state);
        Marshal(node.GetAttributeValue(nameof(IntPropertyPair.Value), null), &objT->Value, state);
    }

    public static unsafe void Marshal(Node node, RealPropertyPair* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RealPropertyPair.Key), null), &objT->Key, state);
        Marshal(node.GetAttributeValue(nameof(RealPropertyPair.Value), null), &objT->Value, state);
    }

    public static unsafe void Marshal(Node node, AssetIdPropertyPair* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AssetIdPropertyPair.Key), null), &objT->Key, state);
        Marshal(node.GetAttributeValue(nameof(AssetIdPropertyPair.Value), null), &objT->Value, state);
    }

    public static unsafe void Marshal(Node node, AssetIdListPropertyPair* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AssetIdListPropertyPair.Key), null), &objT->Key, state);
        Marshal(node.GetAttributeValue(nameof(AssetIdListPropertyPair.Value), null), &objT->Value, state);
    }

    public static unsafe void Marshal(Node node, Dictionary* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(Dictionary.BoolProperty)), &objT->BoolProperty, state);
        Marshal(node.GetChildNodes(nameof(Dictionary.IntProperty)), &objT->IntProperty, state);
        Marshal(node.GetChildNodes(nameof(Dictionary.RealProperty)), &objT->RealProperty, state);
        Marshal(node.GetChildNodes(nameof(Dictionary.StringProperty)), &objT->StringProperty, state);
        Marshal(node.GetChildNodes(nameof(Dictionary.UnicodeStringProperty)), &objT->UnicodeStringProperty, state);
        Marshal(node.GetChildNodes(nameof(Dictionary.AssetIdProperty)), &objT->AssetIdProperty, state);
        Marshal(node.GetChildNodes(nameof(Dictionary.AssetIdListProperty)), &objT->AssetIdListProperty, state);
    }

    private static unsafe void Marshal(Node node, Dictionary** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(Dictionary), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, MapObject* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MapObject.id), null), &objT->id, state);
        Marshal(node.GetAttributeValue(nameof(MapObject.ThingTemplate), null), &objT->ThingTemplate, state);
        Marshal(node.GetAttributeValue(nameof(MapObject.Flags), null), &objT->Flags, state);
        Marshal(node.GetAttributeValue(nameof(MapObject.Angle), null), &objT->Angle, state);
        Marshal(node.GetChildNode(nameof(MapObject.Position), null), &objT->Position, state);
    }

    public static unsafe void Marshal(Node node, MapObjectUSP* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MapObjectUSP.Faction), null), &objT->Faction, state);
        Marshal(node.GetAttributeValue(nameof(MapObjectUSP.Team), null), &objT->Team, state);
        Marshal(node.GetAttributeValue(nameof(MapObjectUSP.Health), null), &objT->Health, state);
        Marshal(node.GetAttributeValue(nameof(MapObjectUSP.EventList), null), &objT->EventList, state);
        Marshal(node, (MapObject*)objT, state);
    }

    public static unsafe void Marshal(Node node, EnvironmentObject* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(EnvironmentObject.Cloud), null), &objT->Cloud, state);
        Marshal(node.GetAttributeValue(nameof(EnvironmentObject.Macro), null), &objT->Macro, state);
        Marshal(node.GetAttributeValue(nameof(EnvironmentObject.Environment), null), &objT->Environment, state);
    }

    private static unsafe void Marshal(Node node, EnvironmentObject** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(EnvironmentObject), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, RoadObject* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RoadObject.id), null), &objT->id, state);
    }

    public static unsafe void Marshal(Node node, PostEffectObject* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(PostEffectObject.Effect), null), &objT->Effect, state);
    }

    public static unsafe void Marshal(Node node, GameMap* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(GameMap.Waypoint)), &objT->Waypoint, state);
        Marshal(node.GetChildNodes(nameof(GameMap.Structure)), &objT->Structure, state);
        Marshal(node.GetChildNodes(nameof(GameMap.Unit)), &objT->Unit, state);
        Marshal(node.GetChildNodes(nameof(GameMap.Prop)), &objT->Prop, state);
        Marshal(node.GetChildNodes(nameof(GameMap.Audio)), &objT->Audio, state);
        Marshal(node.GetChildNodes(nameof(GameMap.Unknown)), &objT->Unknown, state);
        Marshal(node.GetChildNodes(nameof(GameMap.Road)), &objT->Road, state);
        Marshal(node.GetChildNode(nameof(GameMap.EnvironmentData), null), &objT->EnvironmentData, state);
        Marshal(node.GetChildNode(nameof(GameMap.WorldDict), null), &objT->WorldDict, state);
        Marshal(node.GetChildNodes(nameof(GameMap.PostEffect)), &objT->PostEffect, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
