using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DamageFXGroup* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DamageFXGroup.Type), "DEFAULT"), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(DamageFXGroup.Amount), "0.0"), &objT->Amount, state);
        Marshal(node.GetAttributeValue(nameof(DamageFXGroup.ThrottleTime), "0s"), &objT->ThrottleTime, state);
        Marshal(node.GetAttributeValue(nameof(DamageFXGroup.MajorFX), null), &objT->MajorFX, state);
        Marshal(node.GetAttributeValue(nameof(DamageFXGroup.MinorFX), null), &objT->MinorFX, state);
        Marshal(node.GetAttributeValue(nameof(DamageFXGroup.MajorVeteranFX), null), &objT->MajorVeteranFX, state);
        Marshal(node.GetAttributeValue(nameof(DamageFXGroup.MinorVeteranFX), null), &objT->MinorVeteranFX, state);
    }

    public static unsafe void Marshal(Node node, VeterancyDamageFXGroup* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(VeterancyDamageFXGroup.Veterancy), "REGULAR"), &objT->Veterancy, state);
        Marshal(node, (DamageFXGroup*)objT, state);
    }

    public static unsafe void Marshal(Node node, DamageFX* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(DamageFX.FXGroup)), &objT->FXGroup, state);
        Marshal(node.GetChildNodes(nameof(DamageFX.VeterancyFXGroup)), &objT->VeterancyFXGroup, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}