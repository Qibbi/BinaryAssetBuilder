using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RandomAlphaKeyframe* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RandomAlphaKeyframe.RelativeAge), null), &objT->RelativeAge, state);
        Marshal(node.GetAttributeValue(nameof(RandomAlphaKeyframe.Frame), "1000"), &objT->Frame, state);
        Marshal(node, (ClientRandomVariable*)objT, state);
    }

    public static unsafe void Marshal(Node node, RGBColorKeyframe* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RGBColorKeyframe.RelativeAge), null), &objT->RelativeAge, state);
        Marshal(node.GetAttributeValue(nameof(RGBColorKeyframe.Frame), "1000"), &objT->Frame, state);
        Marshal(node.GetChildNode(nameof(RGBColorKeyframe.Color), null), &objT->Color, state);
    }

    public static unsafe void Marshal(Node node, FXParticlePhysicsBase* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (FXParticleBaseModule*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleDefaultPhysics* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleDefaultPhysics.Gravity), null), &objT->Gravity, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDefaultPhysics.Swirly), null), &objT->Swirly, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDefaultPhysics.ParticlesAttachToBone), null), &objT->ParticlesAttachToBone, state);
        Marshal(node.GetChildNode(nameof(FXParticleDefaultPhysics.VelocityDamping), null), &objT->VelocityDamping, state);
        Marshal(node.GetChildNode(nameof(FXParticleDefaultPhysics.DriftVelocity), null), &objT->DriftVelocity, state);
        Marshal(node, (FXParticlePhysicsBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleSwarmPhysics* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleSwarmPhysics.AttractStrength), "0.0"), &objT->AttractStrength, state);
        Marshal(node, (FXParticlePhysicsBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticlePhysicsBase** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x75CD18B3u:
                MarshalPolymorphicType<FXParticleSwarmPhysics, FXParticlePhysicsBase>(node, objT, state);
                break;
            case 0xB96643FFu:
                MarshalPolymorphicType<FXParticleDefaultPhysics, FXParticlePhysicsBase>(node, objT, state);
                break;
        }
    }

    public static unsafe void Marshal(Node node, FXParticleAlpha* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(FXParticleAlpha.Alpha)), &objT->Alpha, state);
    }

    public static unsafe void Marshal(Node node, FXParticleAlpha** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(FXParticleAlpha), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleColor* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleColor.UseHouseColor), "false"), &objT->UseHouseColor, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleColor.HouseColorSaturation), "1.0"), &objT->HouseColorSaturation, state);
        Marshal(node.GetChildNodes(nameof(FXParticleColor.Color)), &objT->Color, state);
        Marshal(node.GetChildNode(nameof(FXParticleColor.ColorScale), null), &objT->ColorScale, state);
    }

    public static unsafe void Marshal(Node node, FXParticleColor** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(FXParticleColor), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleWind* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleWind.Motion), "NOT_USED"), &objT->Motion, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleWind.Strength), "2.0"), &objT->Strength, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleWind.FullStrengthDist), "75.0"), &objT->FullStrengthDist, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleWind.ZeroStrengthDist), "200.0"), &objT->ZeroStrengthDist, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleWind.AngleChangeMin), ".15"), &objT->AngleChangeMin, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleWind.AngleChangeMax), ".45"), &objT->AngleChangeMax, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleWind.PingPongStartAngleMin), "0.0"), &objT->PingPongStartAngleMin, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleWind.PingPongStartAngleMax), "0.7853981633974483"), &objT->PingPongStartAngleMax, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleWind.PingPongEndAngleMin), "5.4977871437821381"), &objT->PingPongEndAngleMin, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleWind.PingPongEndAngleMax), "6.2831853071795864"), &objT->PingPongEndAngleMax, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleWind.TurbulenceAmplitude), "0"), &objT->TurbulenceAmplitude, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleWind.TurbulenceFrequency), "0"), &objT->TurbulenceFrequency, state);
    }

    public static unsafe void Marshal(Node node, FXParticleWind** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(FXParticleWind), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleSystemTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.Priority), "ULTRA_HIGH_ONLY"), &objT->Priority, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.IsOneShot), "false"), &objT->IsOneShot, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.Shader), "ADDITIVE"), &objT->Shader, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.Type), "PARTICLE"), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.ParticleTexture), null), &objT->ParticleTexture, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.Drawable), null), &objT->Drawable, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.SlaveSystem), null), &objT->SlaveSystem, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.PerParticleAttachedSystem), null), &objT->PerParticleAttachedSystem, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.SystemLifetime), "0"), &objT->SystemLifetime, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.SortLevel), "0"), &objT->SortLevel, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.IsGroundAligned), "false"), &objT->IsGroundAligned, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.IsEmitAboveGroundOnly), "false"), &objT->IsEmitAboveGroundOnly, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.IsParticleUpTowardsEmitter), "false"), &objT->IsParticleUpTowardsEmitter, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.UseMaximumHeight), "false"), &objT->UseMaximumHeight, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleSystemTemplate.EmitterSound), null), &objT->EmitterSound, state);
        Marshal(node.GetChildNode(nameof(FXParticleSystemTemplate.SlavePosOffset), null), &objT->SlavePosOffset, state);
        Marshal(node.GetChildNode(nameof(FXParticleSystemTemplate.Lifetime), null), &objT->Lifetime, state);
        Marshal(node.GetChildNode(nameof(FXParticleSystemTemplate.Size), null), &objT->Size, state);
        Marshal(node.GetChildNode(nameof(FXParticleSystemTemplate.StartSizeRate), null), &objT->StartSizeRate, state);
        Marshal(node.GetChildNode(nameof(FXParticleSystemTemplate.BurstDelay), null), &objT->BurstDelay, state);
        Marshal(node.GetChildNode(nameof(FXParticleSystemTemplate.BurstCount), null), &objT->BurstCount, state);
        Marshal(node.GetChildNode(nameof(FXParticleSystemTemplate.InitialDelay), null), &objT->InitialDelay, state);
        Marshal(node.GetChildNode(nameof(FXParticleSystemTemplate.Alphas), null), &objT->Alphas, state);
        Marshal(node.GetChildNode(nameof(FXParticleSystemTemplate.Colors), null), &objT->Colors, state);
        Marshal(node.GetChildNode(nameof(FXParticleSystemTemplate.Wind), null), &objT->Wind, state);
        MarshalSinglePolymorphic(node.GetChildNode(nameof(FXParticleSystemTemplate.Physics), null), &objT->Physics, state);
        MarshalSinglePolymorphic(node.GetChildNode(nameof(FXParticleSystemTemplate.Draw), null), &objT->Draw, state);
        MarshalSinglePolymorphic(node.GetChildNode(nameof(FXParticleSystemTemplate.Volume), null), &objT->Volume, state);
        MarshalSinglePolymorphic(node.GetChildNode(nameof(FXParticleSystemTemplate.Velocity), null), &objT->Velocity, state);
        Marshal(node.GetChildNode(nameof(FXParticleSystemTemplate.Event), null), &objT->Event, state);
        MarshalSinglePolymorphic(node.GetChildNode(nameof(FXParticleSystemTemplate.Update), null), &objT->Update, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
