using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXNugget.RequiredSecondaryModelConditions), null), &objT->RequiredSecondaryModelConditions, state);
        Marshal(node.GetAttributeValue(nameof(FXNugget.ExcludedSecondaryModelConditions), null), &objT->ExcludedSecondaryModelConditions, state);
        Marshal(node.GetAttributeValue(nameof(FXNugget.RequiredSourceModelConditions), null), &objT->RequiredSourceModelConditions, state);
        Marshal(node.GetAttributeValue(nameof(FXNugget.ExcludedSourceModelConditions), null), &objT->ExcludedSourceModelConditions, state);
        Marshal(node.GetAttributeValue(nameof(FXNugget.StopIfPlayed), null), &objT->StopIfPlayed, state);
        Marshal(node.GetAttributeValue(nameof(FXNugget.Weather), "WEATHER"), &objT->Weather, state);
        Marshal(node.GetAttributeValue(nameof(FXNugget.OnlyIfOnLand), "false"), &objT->OnlyIfOnLand, state);
        Marshal(node.GetAttributeValue(nameof(FXNugget.PlayIfSourceIsStealthed), "false"), &objT->PlayIfSourceIsStealthed, state);
        Marshal(node.GetChildNode(nameof(FXNugget.SecondaryObjectFilter), null), &objT->SecondaryObjectFilter, state);
        Marshal(node.GetChildNode(nameof(FXNugget.SourceObjectFilter), null), &objT->SourceObjectFilter, state);
        Marshal(node.GetChildNodes(nameof(FXNugget.SourceMustNotHaveBeenDisabledThisFrameByType)), &objT->SourceMustNotHaveBeenDisabledThisFrameByType, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, EvaEventFXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(EvaEventFXNugget.EvaEventOwner), "EVA_INVALID"), &objT->EvaEventOwner, state);
        Marshal(node.GetAttributeValue(nameof(EvaEventFXNugget.EvaEventAlly), "EVA_INVALID"), &objT->EvaEventAlly, state);
        Marshal(node.GetAttributeValue(nameof(EvaEventFXNugget.EvaEventEnemy), "EVA_INVALID"), &objT->EvaEventEnemy, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, SoundFXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SoundFXNugget.Value), null), &objT->Value, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, RayEffectFXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RayEffectFXNugget.Thing), null), &objT->Thing, state);
        Marshal(node.GetChildNode(nameof(RayEffectFXNugget.PrimaryOffset), null), &objT->PrimaryOffset, state);
        Marshal(node.GetChildNode(nameof(RayEffectFXNugget.SecondaryOffset), null), &objT->SecondaryOffset, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, LightPulseFXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LightPulseFXNugget.Radius), null), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(LightPulseFXNugget.RadiusAsPercentOfObjectSize), null), &objT->RadiusAsPercentOfObjectSize, state);
        Marshal(node.GetAttributeValue(nameof(LightPulseFXNugget.IncreaseTime), null), &objT->IncreaseTime, state);
        Marshal(node.GetAttributeValue(nameof(LightPulseFXNugget.DecreaseTime), null), &objT->DecreaseTime, state);
        Marshal(node.GetChildNode(nameof(LightPulseFXNugget.Color), null), &objT->Color, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, DynamicDecalFXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DynamicDecalFXNugget.Decal), null), &objT->Decal, state);
        Marshal(node.GetAttributeValue(nameof(DynamicDecalFXNugget.Shader), "ALPHA"), &objT->Shader, state);
        Marshal(node.GetAttributeValue(nameof(DynamicDecalFXNugget.Size), null), &objT->Size, state);
        Marshal(node.GetAttributeValue(nameof(DynamicDecalFXNugget.OrientToObject), "true"), &objT->OrientToObject, state);
        Marshal(node.GetAttributeValue(nameof(DynamicDecalFXNugget.OpacityStart), null), &objT->OpacityStart, state);
        Marshal(node.GetAttributeValue(nameof(DynamicDecalFXNugget.OpacityPeak), "1.0"), &objT->OpacityPeak, state);
        Marshal(node.GetAttributeValue(nameof(DynamicDecalFXNugget.OpacityEnd), null), &objT->OpacityEnd, state);
        Marshal(node.GetAttributeValue(nameof(DynamicDecalFXNugget.OpacityFadeTimeOne), null), &objT->OpacityFadeTimeOne, state);
        Marshal(node.GetAttributeValue(nameof(DynamicDecalFXNugget.OpacityFadeTimeTwo), null), &objT->OpacityFadeTimeTwo, state);
        Marshal(node.GetAttributeValue(nameof(DynamicDecalFXNugget.OpacityPeakTime), null), &objT->OpacityPeakTime, state);
        Marshal(node.GetAttributeValue(nameof(DynamicDecalFXNugget.StartingDelay), null), &objT->StartingDelay, state);
        Marshal(node.GetAttributeValue(nameof(DynamicDecalFXNugget.Lifetime), null), &objT->Lifetime, state);
        Marshal(node.GetChildNode(nameof(DynamicDecalFXNugget.Color), null), &objT->Color, state);
        Marshal(node.GetChildNode(nameof(DynamicDecalFXNugget.Offset), null), &objT->Offset, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, BuffNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(BuffNugget.BuffType), null), &objT->BuffType, state);
        Marshal(node.GetAttributeValue(nameof(BuffNugget.ComplexBuff), null), &objT->ComplexBuff, state);
        Marshal(node.GetAttributeValue(nameof(BuffNugget.Template), null), &objT->Template, state);
        Marshal(node.GetAttributeValue(nameof(BuffNugget.OrcTemplate), null), &objT->OrcTemplate, state);
        Marshal(node.GetAttributeValue(nameof(BuffNugget.InfantryTemplate), null), &objT->InfantryTemplate, state);
        Marshal(node.GetAttributeValue(nameof(BuffNugget.CavalryTemplate), null), &objT->CavalryTemplate, state);
        Marshal(node.GetAttributeValue(nameof(BuffNugget.VehicleTemplate), null), &objT->VehicleTemplate, state);
        Marshal(node.GetAttributeValue(nameof(BuffNugget.TrollTemplate), null), &objT->TrollTemplate, state);
        Marshal(node.GetAttributeValue(nameof(BuffNugget.MumakilTemplate), null), &objT->MumakilTemplate, state);
        Marshal(node.GetAttributeValue(nameof(BuffNugget.ShipTemplate), null), &objT->ShipTemplate, state);
        Marshal(node.GetAttributeValue(nameof(BuffNugget.MonsterTemplate), null), &objT->MonsterTemplate, state);
        Marshal(node.GetAttributeValue(nameof(BuffNugget.Lifetime), null), &objT->Lifetime, state);
        Marshal(node.GetAttributeValue(nameof(BuffNugget.Extrusion), null), &objT->Extrusion, state);
        Initialize(&objT->Color, state, 0.2f, 0.4f, 1.0f);
        Marshal(node.GetChildNode(nameof(BuffNugget.Color), null), &objT->Color, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, LaserFXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LaserFXNugget.LaserTemplate), null), &objT->LaserTemplate, state);
        Marshal(node.GetAttributeValue(nameof(LaserFXNugget.LaserBackwards), "false"), &objT->LaserBackwards, state);
        Marshal(node.GetChildNode(nameof(LaserFXNugget.Offset), null), &objT->Offset, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, CameraShakerVolumeFXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CameraShakerVolumeFXNugget.Radius), null), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(CameraShakerVolumeFXNugget.Duration), null), &objT->Duration, state);
        Marshal(node.GetAttributeValue(nameof(CameraShakerVolumeFXNugget.Amplitude), null), &objT->Amplitude, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, ViewShakeFXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ViewShakeFXNugget.Type), null), &objT->Type, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, AttachedModelFXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AttachedModelFXNugget.Model), null), &objT->Model, state);
        Marshal(node.GetAttributeValue(nameof(AttachedModelFXNugget.RandomlyRotate), "false"), &objT->RandomlyRotate, state);
        Marshal(node.GetAttributeValue(nameof(AttachedModelFXNugget.ExpireTimer), "8s"), &objT->ExpireTimer, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, TerrainScorchFXNuggetRandomRange* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TerrainScorchFXNuggetRandomRange.Low), "SCORCH_1"), &objT->Low, state);
        Marshal(node.GetAttributeValue(nameof(TerrainScorchFXNuggetRandomRange.High), "SCORCH_4"), &objT->High, state);
    }

    public static unsafe void Marshal(Node node, TerrainScorchFXNuggetRandomRange** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(TerrainScorchFXNuggetRandomRange), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, TerrainScorchFXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TerrainScorchFXNugget.Type), "RANDOM"), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(TerrainScorchFXNugget.Radius), null), &objT->Radius, state);
        Marshal(node.GetChildNode(nameof(TerrainScorchFXNugget.RandomRange), null), &objT->RandomRange, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, TintDrawableFXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TintDrawableFXNugget.PreColorTime), "2s"), &objT->PreColorTime, state);
        Marshal(node.GetAttributeValue(nameof(TintDrawableFXNugget.PostColorTime), "2s"), &objT->PostColorTime, state);
        Marshal(node.GetAttributeValue(nameof(TintDrawableFXNugget.SustainedColorTime), "1s"), &objT->SustainedColorTime, state);
        Marshal(node.GetAttributeValue(nameof(TintDrawableFXNugget.Frequency), "1.0"), &objT->Frequency, state);
        Marshal(node.GetAttributeValue(nameof(TintDrawableFXNugget.Amplitude), "1.0"), &objT->Amplitude, state);
        Marshal(node.GetChildNode(nameof(TintDrawableFXNugget.Color), null), &objT->Color, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXListAtBonePosFXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXListAtBonePosFXNugget.FX), null), &objT->FX, state);
        Marshal(node.GetAttributeValue(nameof(FXListAtBonePosFXNugget.Bone), null), &objT->Bone, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleSysBoneNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleSysBoneNugget.Bone), null), &objT->Bone, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSysBoneNugget.RequireFrequentUpdate), null), &objT->RequireFrequentUpdate, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSysBoneNugget.TriggerType), null), &objT->TriggerType, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSysBoneNugget.HoldBetweenStateID), null), &objT->HoldBetweenStateID, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSysBoneNugget.ActionType), null), &objT->ActionType, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSysBoneNugget.Particle), null), &objT->Particle, state);
        Marshal(node.GetChildNode(nameof(FXParticleSysBoneNugget.Offset), null), &objT->Offset, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, ParticleSystemFXNuggetRotate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNuggetRotate.X), null), &objT->X, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNuggetRotate.Y), null), &objT->Y, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNuggetRotate.Z), null), &objT->Z, state);
    }

    public static unsafe void Marshal(Node node, ParticleSystemFXNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.Particle), null), &objT->Particle, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.Count), "1"), &objT->Count, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.OrientToObject), null), &objT->OrientToObject, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.Ricochet), null), &objT->Ricochet, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.AttachToObject), null), &objT->AttachToObject, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.AttachToBone), null), &objT->AttachToBone, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.CreateAtGroundHeight), null), &objT->CreateAtGroundHeight, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.CreateOverrideBone), null), &objT->CreateOverrideBone, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.UseTarget), null), &objT->UseTarget, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.TargetOverrideBone), null), &objT->TargetOverrideBone, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.TargetCoeff), "1.0"), &objT->TargetCoeff, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.SystemLife), "-1s"), &objT->SystemLife, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.SetTargetMatrix), null), &objT->SetTargetMatrix, state);
        Marshal(node.GetAttributeValue(nameof(ParticleSystemFXNugget.OnlyIfOnWater), null), &objT->OnlyIfOnWater, state);
        Marshal(node.GetChildNode(nameof(ParticleSystemFXNugget.Rotate), null), &objT->Rotate, state);
        Marshal(node.GetChildNode(nameof(ParticleSystemFXNugget.Offset), null), &objT->Offset, state);
        Marshal(node.GetChildNode(nameof(ParticleSystemFXNugget.TargetOffset), null), &objT->TargetOffset, state);
        Marshal(node.GetChildNode(nameof(ParticleSystemFXNugget.Radius), null), &objT->Radius, state);
        Marshal(node.GetChildNode(nameof(ParticleSystemFXNugget.Height), null), &objT->Height, state);
        Initialize((RandomVariable*)&objT->InitialDelay, state, -1.0f, -1.0f, DistributionType.CONSTANT);
        Marshal(node.GetChildNode(nameof(ParticleSystemFXNugget.InitialDelay), null), &objT->InitialDelay, state);
        Marshal(node, (FXNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXNugget** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x2CCC1572u:
                MarshalPolymorphicType<ParticleSystemFXNugget, FXNugget>(node, objT, state);
                break;
            case 0xBA0B1771u:
                MarshalPolymorphicType<FXParticleSysBoneNugget, FXNugget>(node, objT, state);
                break;
            case 0xFC640E01u:
                MarshalPolymorphicType<FXListAtBonePosFXNugget, FXNugget>(node, objT, state);
                break;
            case 0x7D926E58u:
                MarshalPolymorphicType<TintDrawableFXNugget, FXNugget>(node, objT, state);
                break;
            case 0x083CAFA6u:
                MarshalPolymorphicType<TerrainScorchFXNugget, FXNugget>(node, objT, state);
                break;
            case 0x86E8845Fu:
                MarshalPolymorphicType<AttachedModelFXNugget, FXNugget>(node, objT, state);
                break;
            case 0xEF181572u:
                MarshalPolymorphicType<ViewShakeFXNugget, FXNugget>(node, objT, state);
                break;
            case 0xE0A231E5u:
                MarshalPolymorphicType<CameraShakerVolumeFXNugget, FXNugget>(node, objT, state);
                break;
            case 0x35E93221u:
                MarshalPolymorphicType<LaserFXNugget, FXNugget>(node, objT, state);
                break;
            case 0xC3EFC433u:
                MarshalPolymorphicType<BuffNugget, FXNugget>(node, objT, state);
                break;
            case 0x33A6DCEEu:
                MarshalPolymorphicType<DynamicDecalFXNugget, FXNugget>(node, objT, state);
                break;
            case 0xFFE75CA1u:
                MarshalPolymorphicType<LightPulseFXNugget, FXNugget>(node, objT, state);
                break;
            case 0x8E39BC26u:
                MarshalPolymorphicType<RayEffectFXNugget, FXNugget>(node, objT, state);
                break;
            case 0x1E08C8FBu:
                MarshalPolymorphicType<SoundFXNugget, FXNugget>(node, objT, state);
                break;
            case 0x907FB364u:
                MarshalPolymorphicType<EvaEventFXNugget, FXNugget>(node, objT, state);
                break;
        }
    }

    public static unsafe void Marshal(Node node, FXList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXList.PlayEvenIfShrouded), "false"), &objT->PlayEvenIfShrouded, state);
        Marshal(node.GetAttributeValue(nameof(FXList.Tailorable), "false"), &objT->Tailorable, state);
        Marshal(node.GetAttributeValue(nameof(FXList.CullTracking), null), &objT->CullTracking, state);
        Marshal(node.GetAttributeValue(nameof(FXList.CullTrackingMin), null), &objT->CullTrackingMin, state);
        Marshal(node.GetAttributeValue(nameof(FXList.CullTrackingMax), null), &objT->CullTrackingMax, state);
        Marshal(node.GetChildNode(nameof(FXList.NuggetList), null), &objT->NuggetList, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
