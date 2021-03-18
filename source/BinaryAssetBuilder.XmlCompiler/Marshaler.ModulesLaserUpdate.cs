using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, LaserUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LaserUpdateModuleData.ParticleSystemId), null), &objT->ParticleSystemId, state);
        Marshal(node.GetAttributeValue(nameof(LaserUpdateModuleData.ParentFireBoneName), null), &objT->ParentFireBoneName, state);
        Marshal(node.GetAttributeValue(nameof(LaserUpdateModuleData.ParentFireBoneOnTurret), "false"), &objT->ParentFireBoneOnTurret, state);
        Marshal(node.GetAttributeValue(nameof(LaserUpdateModuleData.TargetParticleSystemId), null), &objT->TargetParticleSystemId, state);
        Marshal(node.GetAttributeValue(nameof(LaserUpdateModuleData.LaserLifetime), "0"), &objT->LaserLifetime, state);
        Marshal(node, (ClientUpdateModuleData*)objT, state);
    }
}
