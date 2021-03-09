using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentObjectSelector* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentObjectSelector.ShowAllHealthBars), "true"), &objT->ShowAllHealthBars, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentObjectSelector.PortraitName), "true"), &objT->PortraitName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentObjectSelector.StatusTextNothingSelected), null), &objT->StatusTextNothingSelected, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentObjectSelector.StatusTextSelectedAcrossMap), null), &objT->StatusTextSelectedAcrossMap, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentObjectSelector.StatusTextSelectedAcrossScreen), null), &objT->StatusTextSelectedAcrossScreen, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentObjectSelector.AllArmyImageGDI), null), &objT->AllArmyImageGDI, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentObjectSelector.AllArmyImageNOD), null), &objT->AllArmyImageNOD, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentObjectSelector.AllArmyImageAlien), null), &objT->AllArmyImageAlien, state);
        Marshal(node.GetChildNode(nameof(UIComponentObjectSelector.AlienHighlightDecal), null), &objT->AlienHighlightDecal, state);
        Marshal(node.GetChildNode(nameof(UIComponentObjectSelector.GDIHighlightDecal), null), &objT->GDIHighlightDecal, state);
        Marshal(node.GetChildNode(nameof(UIComponentObjectSelector.NODHighlightDecal), null), &objT->NODHighlightDecal, state);
        Marshal(node.GetChildNodes(nameof(UIComponentObjectSelector.ShortcutObjects)), &objT->ShortcutObjects, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}