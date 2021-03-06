using Relo;
using SageBinaryData;
using SageBinaryData.InGameUI;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentInGameText* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.AdjustFactor), null), &objT->AdjustFactor, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.TextIndent), null), &objT->TextIndent, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.TooltipAppearDelayMS), "3000"), &objT->TooltipAppearDelayMS, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.TooltipDisappearDelayMS), "3000"), &objT->TooltipDisappearDelayMS, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.AptTokenTitle), null), &objT->AptTokenTitle, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.AptTokenPrereq), null), &objT->AptTokenPrereq, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.AptTokenCost), null), &objT->AptTokenCost, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.AptTokenTime), null), &objT->AptTokenTime, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.AptTokenEnergy), null), &objT->AptTokenEnergy, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.AptTokenShortDesc), null), &objT->AptTokenShortDesc, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.AptTokenLongDesc), null), &objT->AptTokenLongDesc, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.ProductionTextConstruction), null), &objT->ProductionTextConstruction, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.ProductionTextUpgrade), null), &objT->ProductionTextUpgrade, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.ProductionTextRecruit), null), &objT->ProductionTextRecruit, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.ProductionTextScale), null), &objT->ProductionTextScale, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.SubtitleStringLabelPrefix), null), &objT->SubtitleStringLabelPrefix, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.SubtitleStringLabelSuffix), null), &objT->SubtitleStringLabelSuffix, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentInGameText.SubtitleStringExclusionChar), null), &objT->SubtitleStringExclusionChar, state);
        Marshal(node.GetChildNode(nameof(UIComponentInGameText.StatusTextPosition), null), &objT->StatusTextPosition, state);
        Marshal(node.GetChildNode(nameof(UIComponentInGameText.ProductionTextColor), null), &objT->ProductionTextColor, state);
        Marshal(node.GetChildNode(nameof(UIComponentInGameText.ProductionTextFont), null), &objT->ProductionTextFont, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}