using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TurretAIData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TurretAIData.TurretTurnRate), "0.0"), &objT->TurretTurnRate, state);
        Marshal(node.GetAttributeValue(nameof(TurretAIData.TurretPitchRate), "0.0"), &objT->TurretPitchRate, state);
        Marshal(node.GetAttributeValue(nameof(TurretAIData.AllowsPitch), "false"), &objT->AllowsPitch, state);
        Marshal(node.GetAttributeValue(nameof(TurretAIData.MinimumPitch), "0d"), &objT->MinimumPitch, state);
        Marshal(node.GetAttributeValue(nameof(TurretAIData.PitchHeight), "50%"), &objT->PitchHeight, state);
        Marshal(node.GetAttributeValue(nameof(TurretAIData.ControlledWeaponSlots), null), &objT->ControlledWeaponSlots, state);
        Marshal(node.GetAttributeValue(nameof(TurretAIData.MinIdleScanTime), "0.0s"), &objT->MinIdleScanTime, state);
        Marshal(node.GetAttributeValue(nameof(TurretAIData.MaxIdleScanTime), "0.0s"), &objT->MaxIdleScanTime, state);
        Marshal(node.GetAttributeValue(nameof(TurretAIData.MinIdleScanAngle), "0.0"), &objT->MinIdleScanAngle, state);
        Marshal(node.GetAttributeValue(nameof(TurretAIData.MaxIdleScanAngle), "0.0"), &objT->MaxIdleScanAngle, state);
        Marshal(node.GetAttributeValue(nameof(TurretAIData.MaxDeflectionClockwise), "180d"), &objT->MaxDeflectionClockwise, state);
        Marshal(node.GetAttributeValue(nameof(TurretAIData.MaxDeflectionAntiClockwise), "180d"), &objT->MaxDeflectionAntiClockwise, state);
        Marshal(node.GetAttributeValue(nameof(TurretAIData.NaturalTurretAngle), "0d"), &objT->NaturalTurretAngle, state);
        Marshal(node.GetAttributeValue(nameof(TurretAIData.RecenterWhenOutOfTurnRange), "true"), &objT->RecenterWhenOutOfTurnRange, state);
        Marshal(node.GetChildNode(nameof(TurretAIData.TurretAITargetChooserData), null), &objT->TurretAITargetChooserData, state);
    }
}
