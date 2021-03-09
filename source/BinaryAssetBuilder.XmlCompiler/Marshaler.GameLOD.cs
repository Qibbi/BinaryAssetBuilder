using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ProcessorRequirement* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ProcessorRequirement.Type), null), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(ProcessorRequirement.MinMHz), null), &objT->MinMHz, state);
    }

    public static unsafe void Marshal(Node node, GameLODPreset* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GameLODPreset.Level), "MEDIUM"), &objT->Level, state);
        Marshal(node.GetAttributeValue(nameof(GameLODPreset.SystemMemory), "500"), &objT->SystemMemory, state);
        Marshal(node.GetAttributeValue(nameof(GameLODPreset.GraphicsCard), "_MINIMUM_FOR_MEDIUM_LOD"), &objT->GraphicsCard, state);
        Marshal(node.GetAttributeValue(nameof(GameLODPreset.Xres), "1024"), &objT->Xres, state);
        Marshal(node.GetAttributeValue(nameof(GameLODPreset.Yres), "768"), &objT->Yres, state);
        Marshal(node.GetChildNodes(nameof(GameLODPreset.Processor)), &objT->Processor, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, StaticGameLOD* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.Level), "MEDIUM"), &objT->Level, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.ModelLOD), "HIGH"), &objT->ModelLOD, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.EffectsLOD), "MEDIUM"), &objT->EffectsLOD, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.MaxParticleCount), "1500"), &objT->MaxParticleCount, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.UseShadowDecals), "true"), &objT->UseShadowDecals, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.UseShadowMapping), "false"), &objT->UseShadowMapping, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.ShadowLOD), "MEDIUM"), &objT->ShadowLOD, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.TerrainLOD), "MEDIUM"), &objT->TerrainLOD, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.UseTerrainNormalMap), "false"), &objT->UseTerrainNormalMap, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.UseDistanceDependantTerrainTextures), "true"), &objT->UseDistanceDependantTerrainTextures, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.WaterLOD), "MEDIUM"), &objT->WaterLOD, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.MaxTankTrackEdges), "100"), &objT->MaxTankTrackEdges, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.MaxTankTrackOpaqueEdges), "25"), &objT->MaxTankTrackOpaqueEdges, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.MaxTankTrackFadeDelay), "30000"), &objT->MaxTankTrackFadeDelay, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.ShowProps), "true"), &objT->ShowProps, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.TextureReductionFactor), "0"), &objT->TextureReductionFactor, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.AnimationLOD), "HIGH"), &objT->AnimationLOD, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.ShaderLOD), "MEDIUM"), &objT->ShaderLOD, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.UseHeatEffects), "true"), &objT->UseHeatEffects, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.DecalLOD), "HIGH"), &objT->DecalLOD, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.MinParticlePriority), "MEDIUM_OR_ABOVE"), &objT->MinParticlePriority, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.MinParticleSkipPriority), "ALWAYS_RENDER"), &objT->MinParticleSkipPriority, state);
        Marshal(node.GetAttributeValue(nameof(StaticGameLOD.AntiAliasingQuality), "0"), &objT->AntiAliasingQuality, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, DynamicGameLOD* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DynamicGameLOD.Level), "MEDIUM"), &objT->Level, state);
        Marshal(node.GetAttributeValue(nameof(DynamicGameLOD.MinimumFPS), "10"), &objT->MinimumFPS, state);
        Marshal(node.GetAttributeValue(nameof(DynamicGameLOD.ParticleSkipMask), "1"), &objT->ParticleSkipMask, state);
        Marshal(node.GetAttributeValue(nameof(DynamicGameLOD.DebrisSkipMask), "0"), &objT->DebrisSkipMask, state);
        Marshal(node.GetAttributeValue(nameof(DynamicGameLOD.SlowDeathScale), "1.0"), &objT->SlowDeathScale, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, AudioLOD* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AudioLOD.Level), null), &objT->Level, state);
        Marshal(node.GetAttributeValue(nameof(AudioLOD.AllowReverb), null), &objT->AllowReverb, state);
        Marshal(node.GetAttributeValue(nameof(AudioLOD.MaximumAmbientStreams), null), &objT->MaximumAmbientStreams, state);
        Marshal(node.GetAttributeValue(nameof(AudioLOD.AllowCPULimiter), null), &objT->AllowCPULimiter, state);
        Marshal(node.GetAttributeValue(nameof(AudioLOD.CPULimiterLevel), null), &objT->CPULimiterLevel, state);
        Marshal(node.GetAttributeValue(nameof(AudioLOD.CPULimiterLevelDebug), null), &objT->CPULimiterLevelDebug, state);
        Marshal(node.GetAttributeValue(nameof(AudioLOD.MaxVoices), null), &objT->MaxVoices, state);
        Marshal(node.GetAttributeValue(nameof(AudioLOD.OutputBitRate), null), &objT->OutputBitRate, state);
        Marshal(node.GetAttributeValue(nameof(AudioLOD.AllowVolumeCompressor), null), &objT->AllowVolumeCompressor, state);
        Marshal(node.GetAttributeValue(nameof(AudioLOD.MinimumLogicalProcessors), null), &objT->MinimumLogicalProcessors, state);
        Marshal(node.GetChildNodes(nameof(AudioLOD.Processor)), &objT->Processor, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}