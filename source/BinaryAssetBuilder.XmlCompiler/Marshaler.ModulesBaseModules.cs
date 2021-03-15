using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AnimAndDuration* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AnimAndDuration.AnimState), null), &objT->AnimState, state);
        Marshal(node.GetAttributeValue(nameof(AnimAndDuration.Frames), "0"), &objT->Frames, state);
        Marshal(node.GetAttributeValue(nameof(AnimAndDuration.Trigger), "0"), &objT->Trigger, state);
    }

    public static unsafe void Marshal(Node node, AnimAndDuration** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AnimAndDuration), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, ModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ModuleData.id), null), &objT->id, state);
    }

    public static unsafe void Marshal(Node node, ClientBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (ModuleData*)objT, state);
    }

    public static unsafe void Marshal(Node node, DrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (ModuleData*)objT, state);
    }

    public static unsafe void Marshal(Node node, BehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (ModuleData*)objT, state);
    }

    public static unsafe void Marshal(Node node, ContainModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (BehaviorModuleData*)objT, state);
    }

    public static unsafe void Marshal(Node node, ClientUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (BehaviorModuleData*)objT, state);
    }

    public static unsafe void Marshal(Node node, UpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (ContainModuleData*)objT, state);
    }

    public static unsafe void Marshal(Node node, DieMuxDataType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DieMuxDataType.VeterancyLevels), null), &objT->VeterancyLevels, state);
        Marshal(node.GetAttributeValue(nameof(DieMuxDataType.ExemptStatus), null), &objT->ExemptStatus, state);
        Marshal(node.GetAttributeValue(nameof(DieMuxDataType.RequiredStatus), null), &objT->RequiredStatus, state);
        Marshal(node.GetAttributeValue(nameof(DieMuxDataType.DamageAmountRequired), "-1"), &objT->DamageAmountRequired, state);
        Marshal(node.GetAttributeValue(nameof(DieMuxDataType.MinKillerAngle), "1d"), &objT->MinKillerAngle, state);
        Marshal(node.GetAttributeValue(nameof(DieMuxDataType.MaxKillerAngle), "-1d"), &objT->MaxKillerAngle, state);
        Marshal(node.GetAttributeValue(nameof(DieMuxDataType.DeathTypes), null), &objT->DeathTypes, state);
        Marshal(node.GetAttributeValue(nameof(DieMuxDataType.DeathTypesForbidden), null), &objT->DeathTypesForbidden, state);
    }
}
