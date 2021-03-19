using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ScriptedModelDrawTexture* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ScriptedModelDrawTexture.Texture), null), &objT->Texture, state);
        Marshal(node.GetAttributeValue(nameof(ScriptedModelDrawTexture.Object), null), &objT->Object, state);
        Marshal(node.GetAttributeValue(nameof(ScriptedModelDrawTexture.TimeOfDay), null), &objT->TimeOfDay, state);
        Marshal(node.GetAttributeValue(nameof(ScriptedModelDrawTexture.TexturePass), null), &objT->TexturePass, state);
    }

    public static unsafe void Marshal(Node node, ScriptedModelDrawTexture** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(ScriptedModelDrawTexture), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, Animation* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Animation.Flags), null), &objT->Flags, state);
        Marshal(node.GetAttributeValue(nameof(Animation.AnimationName), null), &objT->AnimationName, state);
        Marshal(node.GetAttributeValue(nameof(Animation.AnimationMode), null), &objT->AnimationMode, state);
        Marshal(node.GetAttributeValue(nameof(Animation.AnimNickName), null), &objT->AnimNickName, state);
        Marshal(node.GetAttributeValue(nameof(Animation.Distance), "0.0"), &objT->Distance, state);
        Marshal(node.GetAttributeValue(nameof(Animation.AnimationBlendTime), "5.0"), &objT->AnimationBlendTime, state);
        Marshal(node.GetAttributeValue(nameof(Animation.AnimationMustCompleteBlend), "false"), &objT->AnimationMustCompleteBlend, state);
        Marshal(node.GetAttributeValue(nameof(Animation.AnimationSpeedFactorMin), "1.0"), &objT->AnimationSpeedFactorMin, state);
        Marshal(node.GetAttributeValue(nameof(Animation.AnimationSpeedFactorMax), "1.0"), &objT->AnimationSpeedFactorMax, state);
        Marshal(node.GetAttributeValue(nameof(Animation.UseWeaponTiming), "false"), &objT->UseWeaponTiming, state);
        Marshal(node.GetAttributeValue(nameof(Animation.WeaponTimingOrdering), null), &objT->WeaponTimingOrdering, state);
        Marshal(node.GetAttributeValue(nameof(Animation.WeaponTimingSlotID), "1"), &objT->WeaponTimingSlotID, state);
        Marshal(node.GetAttributeValue(nameof(Animation.AnimationPriority), "1"), &objT->AnimationPriority, state);
        Marshal(node.GetAttributeValue(nameof(Animation.FadeBeginFrame), "-1.0"), &objT->FadeBeginFrame, state);
        Marshal(node.GetAttributeValue(nameof(Animation.FadeEndFrame), "-1.0"), &objT->FadeEndFrame, state);
        Marshal(node.GetAttributeValue(nameof(Animation.FadingIn), "false"), &objT->FadingIn, state);
    }
    public static unsafe void Marshal(Node node, AnimationState* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AnimationState.ParseCondStateType), null), &objT->ParseCondStateType, state);
        Marshal(node.GetAttributeValue(nameof(AnimationState.AnimNickName), null), &objT->AnimNickName, state);
        Marshal(node.GetAttributeValue(nameof(AnimationState.ConditionsYes), null), &objT->ConditionsYes, state);
        Marshal(node.GetAttributeValue(nameof(AnimationState.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(AnimationState.StateName), null), &objT->StateName, state);
        Marshal(node.GetAttributeValue(nameof(AnimationState.Flags), null), &objT->Flags, state);
        Marshal(node.GetAttributeValue(nameof(AnimationState.ShareAnimation), "false"), &objT->ShareAnimation, state);
        Marshal(node.GetAttributeValue(nameof(AnimationState.EnteringStateFX), null), &objT->EnteringStateFX, state);
        Marshal(node.GetAttributeValue(nameof(AnimationState.FrameForPristineBonePositions), "0"), &objT->FrameForPristineBonePositions, state);
        Marshal(node.GetAttributeValue(nameof(AnimationState.AllowRepeatInRandomPick), "false"), &objT->AllowRepeatInRandomPick, state);
        Marshal(node.GetAttributeValue(nameof(AnimationState.SimilarRestart), "false"), &objT->SimilarRestart, state);
        Marshal(node.GetChildNodes(nameof(AnimationState.Animation)), &objT->Animation, state);
        Marshal(node.GetChildNode(nameof(AnimationState.Script), null), &objT->Script, state);
        Marshal(node.GetChildNodes(nameof(AnimationState.FXEvent)), &objT->FXEvent, state);
        Marshal(node.GetChildNodes(nameof(AnimationState.LuaEvent)), &objT->LuaEvent, state);
        Marshal(node.GetChildNodes(nameof(AnimationState.ParticleSysBone)), &objT->ParticleSysBone, state);
    }
    public static unsafe void Marshal(Node node, W3DScriptedModelDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.InitialRecoilSpeed), "2.0"), &objT->InitialRecoilSpeed, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.MaxRecoilDistance), "3.0"), &objT->MaxRecoilDistance, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.RecoilDamping), "0.4"), &objT->RecoilDamping, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.RecoilSettleSpeed), "0.065"), &objT->RecoilSettleSpeed, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.OkToChangeModelColor), "false"), &objT->OkToChangeModelColor, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.AnimationsRequirePower), "true"), &objT->AnimationsRequirePower, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.UseYAxisForTurretRotation), "false"), &objT->UseYAxisForTurretRotation, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.MinLODRequired), null), &objT->MinLODRequired, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.ProjectileBoneFeedbackEnabledSlots), null), &objT->ProjectileBoneFeedbackEnabledSlots, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.TrackMarks), null), &objT->TrackMarks, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.TrackMarksOnlyWhenCorneringQuickly), "false"), &objT->TrackMarksOnlyWhenCorneringQuickly, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.ExtraPublicBone), null), &objT->ExtraPublicBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.AttachToBoneInAnotherModule), null), &objT->AttachToBoneInAnotherModule, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.DependencySharedModelFlags), null), &objT->DependencySharedModelFlags, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.UseProducerTexture), "false"), &objT->UseProducerTexture, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.NoRotate), "false"), &objT->NoRotate, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.UseFiringArcRotation), "false"), &objT->UseFiringArcRotation, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.Selectable), "true"), &objT->Selectable, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.RandomTextureFixedRandomIndex), "false"), &objT->RandomTextureFixedRandomIndex, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.ParticlesAttachedToAnimatedBones), "false"), &objT->ParticlesAttachedToAnimatedBones, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.TrackMarksLeftBone), null), &objT->TrackMarksLeftBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.TrackMarksRightBone), null), &objT->TrackMarksRightBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.RampMesh1), null), &objT->RampMesh1, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.RampMesh2), null), &objT->RampMesh2, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.WallBoundsMesh), null), &objT->WallBoundsMesh, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.RaisedWallMesh), null), &objT->RaisedWallMesh, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.ParticleBonesCheckDrawable), "false"), &objT->ParticleBonesCheckDrawable, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.ShadowForceDisable), "false"), &objT->ShadowForceDisable, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.HighDetailLODThreshold), "0.0"), &objT->HighDetailLODThreshold, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.LowDetailLODThreshold), "0.0"), &objT->LowDetailLODThreshold, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.SwitchModelLODMode), "false"), &objT->SwitchModelLODMode, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.StaticModelLODMode), "false"), &objT->StaticModelLODMode, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.ShowShadowWhileContained), "false"), &objT->ShowShadowWhileContained, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.UseStandardModelNames), "false"), &objT->UseStandardModelNames, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.UseDefaultAnimation), "false"), &objT->UseDefaultAnimation, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.WadingParticleSys), null), &objT->WadingParticleSys, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.AlphaCameraFadeOuterRadius), "0.0"), &objT->AlphaCameraFadeOuterRadius, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.AlphaCameraFadeInnerRadius), "0.0"), &objT->AlphaCameraFadeInnerRadius, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.AlphaCameraAtInnerRadius), "100"), &objT->AlphaCameraAtInnerRadius, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.StaticSortLevelWhileFading), "-1"), &objT->StaticSortLevelWhileFading, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.BirthFadeTime), "0"), &objT->BirthFadeTime, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.BirthFadeAdditive), "false"), &objT->BirthFadeAdditive, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.ZWriteDisableOverride), "false"), &objT->ZWriteDisableOverride, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.MultiPlayerOnly), "false"), &objT->MultiPlayerOnly, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.AffectedByStealth), "true"), &objT->AffectedByStealth, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.InvertStealthOpacity), null), &objT->InvertStealthOpacity, state);
        Marshal(node.GetAttributeValue(nameof(W3DScriptedModelDrawModuleData.HighDetailOnly), null), &objT->HighDetailOnly, state);
        Marshal(node.GetChildNodes(nameof(W3DScriptedModelDrawModuleData.ModelConditionState)), &objT->ModelConditionState, state);
        Marshal(node.GetChildNodes(nameof(W3DScriptedModelDrawModuleData.AnimationState)), &objT->AnimationState, state);
        Marshal(node.GetChildNodes(nameof(W3DScriptedModelDrawModuleData.TimeOfDayTexture)), &objT->TimeOfDayTexture, state);
        Marshal(node.GetChildNodes(nameof(W3DScriptedModelDrawModuleData.RandomTexture)), &objT->RandomTexture, state);
        Marshal(node.GetChildNode(nameof(W3DScriptedModelDrawModuleData.BurntTexture), null), &objT->BurntTexture, state);
        Marshal(node.GetChildNodes(nameof(W3DScriptedModelDrawModuleData.AttachModel)), &objT->AttachModel, state);
        Marshal(node.GetChildNodes(nameof(W3DScriptedModelDrawModuleData.EmbedPortal)), &objT->EmbedPortal, state);
        Marshal(node, (DrawModuleData*)objT, state);
    }
}