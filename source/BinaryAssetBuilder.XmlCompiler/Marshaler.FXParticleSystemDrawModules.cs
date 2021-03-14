using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FXParticleDrawBase* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (FXParticleBaseModule*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleDrawGpu* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawGpu.Shader), "GPUParticle.fx"), &objT->Shader, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawGpu.FramesPerRow), "1"), &objT->FramesPerRow, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawGpu.TotalFrames), "1"), &objT->TotalFrames, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawGpu.DetailTexture), null), &objT->DetailTexture, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawGpu.SpeedMultiplier), "1.0"), &objT->SpeedMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawGpu.GeometryType), "SIMPLE_QUAD"), &objT->GeometryType, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawGpu.SortParticles), "false"), &objT->SortParticles, state);
        Marshal(node, (FXParticleDrawBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleDrawLightningRandomSet* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(FXParticleDrawLightningRandomSet.StartAmplitude), null), &objT->StartAmplitude, state);
        Marshal(node.GetChildNode(nameof(FXParticleDrawLightningRandomSet.EndAmplitude), null), &objT->EndAmplitude, state);
        Marshal(node.GetChildNode(nameof(FXParticleDrawLightningRandomSet.StartFrequency), null), &objT->StartFrequency, state);
        Marshal(node.GetChildNode(nameof(FXParticleDrawLightningRandomSet.EndFrequency), null), &objT->EndFrequency, state);
        Marshal(node.GetChildNode(nameof(FXParticleDrawLightningRandomSet.StartPhase), null), &objT->StartPhase, state);
        Marshal(node.GetChildNode(nameof(FXParticleDrawLightningRandomSet.EndPhase), null), &objT->EndPhase, state);
    }

    public static unsafe void Marshal(Node node, FXParticleDrawLightning* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(FXParticleDrawLightning.StartPoint), null), &objT->StartPoint, state);
        Marshal(node.GetChildNode(nameof(FXParticleDrawLightning.EndPoint), null), &objT->EndPoint, state);
        Marshal(node.GetChildNodes(nameof(FXParticleDrawLightning.RandomSet)), &objT->RandomSet, state);
        Marshal(node, (FXParticleDrawBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleDrawRenderObjectObjectSet* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawRenderObjectObjectSet.RenderGroup), null), &objT->RenderGroup, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawRenderObjectObjectSet.NumObjects), "0"), &objT->NumObjects, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawRenderObjectObjectSet.Percent), "0.0"), &objT->Percent, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawRenderObjectObjectSet.Shader), "W3D_DIFFUSE"), &objT->Shader, state);
    }

    public static unsafe void Marshal(Node node, FXParticleDrawRenderObject* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawRenderObject.SinkRate), "0.0"), &objT->SinkRate, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawRenderObject.MultiRenderObjects), "false"), &objT->MultiRenderObjects, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawRenderObject.SinkOnTerrainCollision), "false"), &objT->SinkOnTerrainCollision, state);
        Marshal(node.GetChildNodes(nameof(FXParticleDrawRenderObject.ObjectSet)), &objT->ObjectSet, state);
        Marshal(node, (FXParticleDrawBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleDrawStreak* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (FXParticleDrawBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleDrawSwarm* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawSwarm.OpaqueSpeed), "0"), &objT->OpaqueSpeed, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawSwarm.TransparentSpeed), "100.0"), &objT->TransparentSpeed, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawSwarm.SpeedStretchAmount), "1.0"), &objT->SpeedStretchAmount, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawSwarm.AttractStrength), "0.0"), &objT->AttractStrength, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawSwarm.EnvironmentTexture), null), &objT->EnvironmentTexture, state);
        Marshal(node, (FXParticleDrawBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleDrawTrail* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawTrail.TrailLife), "30"), &objT->TrailLife, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawTrail.UTile), "1.0"), &objT->UTile, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawTrail.VTile), "1.0"), &objT->VTile, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawTrail.UScrollRate), "0.0"), &objT->UScrollRate, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleDrawTrail.VScrollRate), "0.0"), &objT->VScrollRate, state);
        Marshal(node, (FXParticleDrawBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleDrawBase** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x6F3323A5u:
                MarshalPolymorphicType<FXParticleDrawTrail, FXParticleDrawBase>(node, objT, state);
                break;
            case 0x8DF6B125u:
                MarshalPolymorphicType<FXParticleDrawSwarm, FXParticleDrawBase>(node, objT, state);
                break;
            case 0xE30B2280u:
                MarshalPolymorphicType<FXParticleDrawStreak, FXParticleDrawBase>(node, objT, state);
                break;
            case 0xCB25505Bu:
                MarshalPolymorphicType<FXParticleDrawRenderObject, FXParticleDrawBase>(node, objT, state);
                break;
            case 0xB503BC4Cu:
                MarshalPolymorphicType<FXParticleDrawLightning, FXParticleDrawBase>(node, objT, state);
                break;
            case 0x85FE07DFu:
                MarshalPolymorphicType<FXParticleDrawGpu, FXParticleDrawBase>(node, objT, state);
                break;
            case 0xBED78E9Du:
                MarshalPolymorphicType<FXParticleDrawBase, FXParticleDrawBase>(node, objT, state);
                break;
        }
    }
}
