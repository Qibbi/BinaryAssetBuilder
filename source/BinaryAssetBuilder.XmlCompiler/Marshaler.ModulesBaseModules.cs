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

    public static unsafe void Marshal(Node node, ModelConditionStateTurret* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ModelConditionStateTurret.TurretNameKey), null), &objT->TurretNameKey, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionStateTurret.TurretArtAngle), null), &objT->TurretArtAngle, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionStateTurret.TurretPitch), null), &objT->TurretPitch, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionStateTurret.TurretArtPitch), null), &objT->TurretArtPitch, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionStateTurret.TurretID), "-1"), &objT->TurretID, state);
    }

    public static unsafe void Marshal(Node node, ModelConditionStateTurret** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(ModelConditionStateTurret), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, FXEvent* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXEvent.Frame), null), &objT->Frame, state);
        Marshal(node.GetAttributeValue(nameof(FXEvent.FrameStep), null), &objT->FrameStep, state);
        Marshal(node.GetAttributeValue(nameof(FXEvent.FrameStop), null), &objT->FrameStop, state);
        Marshal(node.GetAttributeValue(nameof(FXEvent.FireWhenSkipped), "false"), &objT->FireWhenSkipped, state);
        Marshal(node.GetAttributeValue(nameof(FXEvent.Effect), null), &objT->Effect, state);
        Marshal(node.GetAttributeValue(nameof(FXEvent.Bone), null), &objT->Bone, state);
    }

    public static unsafe void Marshal(Node node, LuaEvent* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LuaEvent.Frame), null), &objT->Frame, state);
        Marshal(node.GetAttributeValue(nameof(LuaEvent.Data), null), &objT->Data, state);
        Marshal(node.GetAttributeValue(nameof(LuaEvent.OnStateEnter), "false"), &objT->OnStateEnter, state);
        Marshal(node.GetAttributeValue(nameof(LuaEvent.OnStateLeave), "false"), &objT->OnStateLeave, state);
        Marshal(node.GetChildNode(nameof(LuaEvent.Turret), null), &objT->Turret, state);
    }

    public static unsafe void Marshal(Node node, ParticleSysBone* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ParticleSysBone.BoneName), null), &objT->BoneName, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSysBone.FXParticleSystemTemplate), null), &objT->FXParticleSystemTemplate, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSysBone.FollowBone), "false"), &objT->FollowBone, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSysBone.FXTrigger), null), &objT->FXTrigger, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSysBone.Persist), null), &objT->Persist, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSysBone.PersistID), "0"), &objT->PersistID, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSysBone.OnlyIfOnWater), "false"), &objT->OnlyIfOnWater, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSysBone.OnlyIfOnLand), "false"), &objT->OnlyIfOnLand, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSysBone.id), null), &objT->id, state);
    }

    public static unsafe void Marshal(Node node, ScriptedModelDrawModel* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ScriptedModelDrawModel.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(ScriptedModelDrawModel.ExtraMesh), "false"), &objT->ExtraMesh, state);
    }

    public static unsafe void Marshal(Node node, BoneAttachPoint* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(BoneAttachPoint.WeaponSlotID), "1"), &objT->WeaponSlotID, state);
        Marshal(node.GetAttributeValue(nameof(BoneAttachPoint.WeaponSlotType), "PRIMARY_WEAPON"), &objT->WeaponSlotType, state);
        Marshal(node.GetAttributeValue(nameof(BoneAttachPoint.BoneName), null), &objT->BoneName, state);
    }

    public static unsafe void Marshal(Node node, ModelConditionState* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ModelConditionState.ParseCondStateType), null), &objT->ParseCondStateType, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionState.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionState.ConditionsYes), null), &objT->ConditionsYes, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionState.Skeleton), null), &objT->Skeleton, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionState.ModelAnimationPrefix), null), &objT->ModelAnimationPrefix, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionState.PortraitImage), null), &objT->PortraitImage, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionState.ButtonImage), null), &objT->ButtonImage, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionState.OverrideTooltip), null), &objT->OverrideTooltip, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionState.RetainSubObjects), "false"), &objT->RetainSubObjects, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionState.id), null), &objT->id, state);
        Marshal(node.GetChildNodes(nameof(ModelConditionState.Model)), &objT->Model, state);
        Marshal(node.GetChildNodes(nameof(ModelConditionState.Texture)), &objT->Texture, state);
        Marshal(node.GetChildNodes(nameof(ModelConditionState.WeaponFireFXBone)), &objT->WeaponFireFXBone, state);
        Marshal(node.GetChildNodes(nameof(ModelConditionState.WeaponRecoilBone)), &objT->WeaponRecoilBone, state);
        Marshal(node.GetChildNodes(nameof(ModelConditionState.WeaponMuzzleFlash)), &objT->WeaponMuzzleFlash, state);
        Marshal(node.GetChildNodes(nameof(ModelConditionState.WeaponLaunchBone)), &objT->WeaponLaunchBone, state);
        Marshal(node.GetChildNodes(nameof(ModelConditionState.ParticleSysBone)), &objT->ParticleSysBone, state);
        Marshal(node.GetChildNodes(nameof(ModelConditionState.FXEvent)), &objT->FXEvent, state);
        Marshal(node.GetChildNode(nameof(ModelConditionState.ShadowInfo), null), &objT->ShadowInfo, state);
        Marshal(node.GetChildNodes(nameof(ModelConditionState.Turret)), &objT->Turret, state);
    }

    public static unsafe void Marshal(Node node, AttachModelStruct* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AttachModelStruct.Object), null), &objT->Object, state);
        Marshal(node.GetAttributeValue(nameof(AttachModelStruct.Probability), "-1"), &objT->Probability, state);
    }

    public static unsafe void Marshal(Node node, ScriptedModelDrawAttachModel* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ScriptedModelDrawAttachModel.FlagMask), null), &objT->FlagMask, state);
        Marshal(node.GetAttributeValue(nameof(ScriptedModelDrawAttachModel.Bone), null), &objT->Bone, state);
        Marshal(node.GetChildNode(nameof(ScriptedModelDrawAttachModel.Model), null), &objT->Model, state);
        Marshal(node.GetChildNode(nameof(ScriptedModelDrawAttachModel.Offset), null), &objT->Offset, state);
    }

    public static unsafe void Marshal(Node node, ScriptedModelDrawEmbedPortal* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ScriptedModelDrawEmbedPortal.PortalType), null), &objT->PortalType, state);
        Marshal(node.GetAttributeValue(nameof(ScriptedModelDrawEmbedPortal.BonePrefix), null), &objT->BonePrefix, state);
    }

    public static unsafe void Marshal(Node node, WeatherTexture* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(WeatherTexture.Weather), "NORMAL"), &objT->Weather, state);
        Marshal(node.GetAttributeValue(nameof(WeatherTexture.Texture), ""), &objT->Texture, state);
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

    public static unsafe void Marshal(Node node, InvisibilityNuggetType** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(InvisibilityNuggetType), 1u);
        Marshal(node, *objT, state);
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

    public static unsafe void Marshal(Node node, ObjectStatusValidationDataType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ObjectStatusValidationDataType.ForbiddenStatus), null), &objT->ForbiddenStatus, state);
        Marshal(node.GetAttributeValue(nameof(ObjectStatusValidationDataType.RequiredStatus), null), &objT->RequiredStatus, state);
    }

    public static unsafe void Marshal(Node node, ObjectStatusValidationDataType** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(ObjectStatusValidationDataType), 1u);
        Marshal(node, *objT, state);
    }
}
