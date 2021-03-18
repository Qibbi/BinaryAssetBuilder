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

    public static unsafe void Marshal(Node node, InvisibilityNuggetType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InvisibilityNuggetType.ForbiddenConditions), "PREATTACK_A FIRING_A FIRING_OR_PREATTACK_A RELOADING_A USING_WEAPON_A PREATTACK_B FIRING_B FIRING_OR_PREATTACK_B RELOADING_B USING_WEAPON_B PREATTACK_C FIRING_C FIRING_OR_PREATTACK_C RELOADING_C USING_WEAPON_C"), &objT->ForbiddenConditions, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityNuggetType.ForbiddenConditionExceptions), ""), &objT->ForbiddenConditionExceptions, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityNuggetType.ForbiddenWeaponSets), null), &objT->ForbiddenWeaponSets, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityNuggetType.ForbiddenStatus), "IS_FIRING_WEAPON IS_AIMING_WEAPON SPECIAL_ABILITY_PACKING_UNPACKING_OR_USING USING_ABILITY"), &objT->ForbiddenStatus, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityNuggetType.CamouflageLevel), null), &objT->CamouflageLevel, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityNuggetType.InvisibilityType), "STEALTH"), &objT->InvisibilityType, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityNuggetType.Options), null), &objT->Options, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityNuggetType.EnteringStealthFX), null), &objT->EnteringStealthFX, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityNuggetType.LeavingStealthFX), null), &objT->LeavingStealthFX, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityNuggetType.HintDetectableStates), "IS_ATTACKING"), &objT->HintDetectableStates, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilityNuggetType.NoStealthForAttackWindow), "0s"), &objT->NoStealthForAttackWindow, state);
        Marshal(node.GetChildNodes(nameof(InvisibilityNuggetType.IgnoreTreeCheckUpgrade)), &objT->IgnoreTreeCheckUpgrade, state);
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

    public static unsafe void Marshal(Node node, DieMuxDataType** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(DieMuxDataType), 1u);
        Marshal(node, *objT, state);
    }
}
