using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, VeterancyRankOverlayIcon* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(VeterancyRankOverlayIcon.Rank), null), &objT->Rank, state);
        Marshal(node.GetAttributeValue(nameof(VeterancyRankOverlayIcon.Image), null), &objT->Image, state);
    }

    public static unsafe void Marshal(Node node, FactionVeterancyOverlayIcons* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FactionVeterancyOverlayIcons.Faction), null), &objT->Faction, state);
        Marshal(node.GetChildNodes(nameof(FactionVeterancyOverlayIcons.RankIcon)), &objT->RankIcon, state);
    }

    public static unsafe void Marshal(Node node, UnitOverlayIconSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UnitOverlayIconSettings.AmmoPipImage), null), &objT->AmmoPipImage, state);
        Marshal(node.GetAttributeValue(nameof(UnitOverlayIconSettings.AmmoPipFrameImage), null), &objT->AmmoPipFrameImage, state);
        Marshal(node.GetAttributeValue(nameof(UnitOverlayIconSettings.ContainPipImage), null), &objT->ContainPipImage, state);
        Marshal(node.GetAttributeValue(nameof(UnitOverlayIconSettings.ContainPipFrameImage), null), &objT->ContainPipFrameImage, state);
        Marshal(node.GetAttributeValue(nameof(UnitOverlayIconSettings.UnitTypeIconBackgroundImage), null), &objT->UnitTypeIconBackgroundImage, state);
        Marshal(node.GetAttributeValue(nameof(UnitOverlayIconSettings.PowerIconImageSequence), null), &objT->PowerIconImageSequence, state);
        Marshal(node.GetAttributeValue(nameof(UnitOverlayIconSettings.RepairIconImageSequence), null), &objT->RepairIconImageSequence, state);
        Marshal(node.GetAttributeValue(nameof(UnitOverlayIconSettings.AmmoPipScale), "100%"), &objT->AmmoPipScale, state);
        Marshal(node.GetAttributeValue(nameof(UnitOverlayIconSettings.ContainPipScale), "100%"), &objT->ContainPipScale, state);
        Marshal(node.GetAttributeValue(nameof(UnitOverlayIconSettings.UnitTypeIconScale), "100%"), &objT->UnitTypeIconScale, state);
        Marshal(node.GetAttributeValue(nameof(UnitOverlayIconSettings.StatusIconScale), "100%"), &objT->StatusIconScale, state);
        Marshal(node.GetAttributeValue(nameof(UnitOverlayIconSettings.VeterancyIconScale), "100%"), &objT->VeterancyIconScale, state);
        Marshal(node.GetChildNodes(nameof(UnitOverlayIconSettings.FactionVeterancy)), &objT->FactionVeterancy, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}