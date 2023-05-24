using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StealthDetectorUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.DetectionRate), "0.4s"), &objT->DetectionRate, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.DetectionRange), "0.0"), &objT->DetectionRange, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.InitiallyDisabled), "false"), &objT->InitiallyDisabled, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.PingSound), null), &objT->PingSound, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.LoudPingSound), null), &objT->LoudPingSound, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.IRBeaconParticleSys), null), &objT->IRBeaconParticleSys, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.IRParticleSys), null), &objT->IRParticleSys, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.IRBrightParticleSys), null), &objT->IRBrightParticleSys, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.IRGridParticleSys), null), &objT->IRGridParticleSys, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.IRParticleSysBone), null), &objT->IRParticleSysBone, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.ExtraRequiredKindOf), null), &objT->ExtraRequiredKindOf, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.ExtraForbiddenKindOf), null), &objT->ExtraForbiddenKindOf, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.CanDetectWhileGarrisoned), "false"), &objT->CanDetectWhileGarrisoned, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.CanDetectWhileContained), "false"), &objT->CanDetectWhileContained, state);
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.RequiredUpgrade), null), &objT->RequiredUpgrade, state);
#if KANESWRATH
        Marshal(node.GetAttributeValue(nameof(StealthDetectorUpdateModuleData.UseMetaAOI), "false"), &objT->UseMetaAOI, state);
#endif
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
