using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ParticleSystemList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(ParticleSystemList.ParticleSys)), &objT->ParticleSys, state);
    }

    public static unsafe void Marshal(Node node, ParticleSystemList** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(ParticleSystemList), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, W3DStreamDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DStreamDrawModuleData.UseDistortionShader), "false"), &objT->UseDistortionShader, state);
        Marshal(node.GetAttributeValue(nameof(W3DStreamDrawModuleData.Velocity), "200.0"), &objT->Velocity, state);
        Marshal(node.GetAttributeValue(nameof(W3DStreamDrawModuleData.ArcHeightFactor), "0.0"), &objT->ArcHeightFactor, state);
        Marshal(node.GetAttributeValue(nameof(W3DStreamDrawModuleData.UVWorldSize), "10.0"), &objT->UVWorldSize, state);
        Marshal(node.GetAttributeValue(nameof(W3DStreamDrawModuleData.NumTubeSides), "8"), &objT->NumTubeSides, state);
        Marshal(node.GetAttributeValue(nameof(W3DStreamDrawModuleData.TubeRadius), "1.0"), &objT->TubeRadius, state);
        Marshal(node.GetAttributeValue(nameof(W3DStreamDrawModuleData.HitFx), null), &objT->HitFx, state);
        Marshal(node.GetAttributeValue(nameof(W3DStreamDrawModuleData.WeaponSlotID), "-1"), &objT->WeaponSlotID, state);
        Marshal(node.GetAttributeValue(nameof(W3DStreamDrawModuleData.StreamStateID), "0"), &objT->StreamStateID, state);
        Marshal(node.GetChildNode(nameof(W3DStreamDrawModuleData.FXShader), null), &objT->FXShader, state);
        Marshal(node.GetChildNode(nameof(W3DStreamDrawModuleData.ParticleSystems), null), &objT->ParticleSystems, state);
        Marshal(node, (DrawModuleData*)objT, state);
    }
}