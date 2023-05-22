using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CrushDieModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CrushDieModuleData.TotalCrushSound), null), &objT->TotalCrushSound, state);
        Marshal(node.GetAttributeValue(nameof(CrushDieModuleData.BackEndCrushSound), null), &objT->BackEndCrushSound, state);
        Marshal(node.GetAttributeValue(nameof(CrushDieModuleData.FrontEndCrushSound), null), &objT->FrontEndCrushSound, state);
        Marshal(node.GetAttributeValue(nameof(CrushDieModuleData.TotalCrushSoundPercent), "100"), &objT->TotalCrushSoundPercent, state);
        Marshal(node.GetAttributeValue(nameof(CrushDieModuleData.BackEndCrushSoundPercent), "100"), &objT->BackEndCrushSoundPercent, state);
        Marshal(node.GetAttributeValue(nameof(CrushDieModuleData.FrontEndCrushSoundPercent), "100"), &objT->FrontEndCrushSoundPercent, state);
        Marshal(node, (DieModuleData*)objT, state);
    }
}
