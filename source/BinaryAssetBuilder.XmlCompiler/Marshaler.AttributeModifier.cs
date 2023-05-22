using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AttributeModifierListType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AttributeModifierListType.Type), null), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierListType.Value), "0"), &objT->Value, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, AttributeModifier* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AttributeModifier.Category), null), &objT->Category, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifier.Duration), "0s"), &objT->Duration, state);
#if KANESWRATH
        Marshal(node.GetAttributeValue(nameof(AttributeModifier.MetaDuration), "0"), &objT->MetaDuration, state);
#endif
        Marshal(node.GetAttributeValue(nameof(AttributeModifier.ReplaceInCategroyIfLongest), "false"), &objT->ReplaceInCategroyIfLongest, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifier.IgnoreIfAnticategoryActive), "false"), &objT->IgnoreIfAnticategoryActive, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifier.StartFX), null), &objT->StartFX, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifier.EndFX), null), &objT->EndFX, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifier.ModelConditionsSet), ""), &objT->ModelConditionsSet, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifier.ModelConditionsClear), ""), &objT->ModelConditionsClear, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifier.ObjectStatusToSet), null), &objT->ObjectStatusToSet, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifier.StackingLimit), "1"), &objT->StackingLimit, state);
        Marshal(node.GetChildNodes(nameof(AttributeModifier.Modifier)), &objT->Modifier, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
