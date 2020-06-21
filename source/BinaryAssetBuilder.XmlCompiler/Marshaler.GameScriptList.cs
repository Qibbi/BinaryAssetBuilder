using Relo;
using SageBinaryData;

public static partial class Marshaler
{

    public static unsafe void Marshal(Node node, GameScriptParameterBase* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
    }

    public static unsafe void Marshal(Node node, GameScriptParameterObjectType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GameScriptParameterObjectType.Object), null), &objT->Object, state);
        Marshal(node, (GameScriptParameterBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, GameScriptParameterObjectTypeList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(GameScriptParameterObjectTypeList.Object)), &objT->Object, state);
        Marshal(node, (GameScriptParameterBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, GameScriptParameterBase** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0u;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x0383BAC7u:
                MarshalPolymorphicType<GameScriptParameterObjectType, GameScriptParameterBase>(node, objT, state);
                break;
            case 0x1F3C3128u:
                MarshalPolymorphicType<GameScriptParameterObjectTypeList, GameScriptParameterBase>(node, objT, state);
                break;
            default:
                MarshalUnknownPolymorphicType(node, objT, state);
                break;

        }
    }

    public static unsafe void Marshal(Node node, GameScriptAction* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GameScriptAction.Type), null), &objT->Type, state);
        Marshal(node.GetChildNode(nameof(GameScriptAction.ParameterList), null), &objT->ParameterList, state);
    }

    public static unsafe void Marshal(Node node, GameScript* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GameScript.id), null), &objT->id, state);
        Marshal(node.GetChildNodes(nameof(GameScript.Action)), &objT->Action, state);
    }

    public static unsafe void Marshal(Node node, GameScriptGroup* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GameScriptGroup.id), null), &objT->id, state);
        Marshal(node.GetChildNodes(nameof(GameScriptGroup.Script)), &objT->Script, state);
        Marshal(node.GetChildNodes(nameof(GameScriptGroup.ScriptGroup)), (List<GameScriptGroup>*)&objT->ScriptGroup, state);
    }

    public static unsafe void Marshal(Node node, GameScriptGroup** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(GameScriptGroup), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, GameScriptList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(GameScriptList.ScriptSet), null), &objT->ScriptSet, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}