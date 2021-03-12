using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MissionTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.IntroMovieName), null), &objT->IntroMovieName, state);
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.DisplayName), null), &objT->DisplayName, state);
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.Title), null), &objT->Title, state);
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.BriefingText), null), &objT->BriefingText, state);
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.BriefingMovie), null), &objT->BriefingMovie, state);
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.BriefingMovieFullScreen), "false"), &objT->BriefingMovieFullScreen, state);
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.LoadScreenImage), null), &objT->LoadScreenImage, state);
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.LoadScreenText), null), &objT->LoadScreenText, state);
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.LoadScreenMusic), null), &objT->LoadScreenMusic, state);
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.LoadScreenVoice), null), &objT->LoadScreenVoice, state);
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.MapName), null), &objT->MapName, state);
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.VictoryMovieName), null), &objT->VictoryMovieName, state);
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.DefeatMovieName), null), &objT->DefeatMovieName, state);
        Marshal(node.GetAttributeValue(nameof(MissionTemplate.RequiredToCompleteTheaterOfWar), "true"), &objT->RequiredToCompleteTheaterOfWar, state);
        Marshal(node.GetChildNodes(nameof(MissionTemplate.Prerequisite)), &objT->Prerequisite, state);
        Marshal(node.GetChildNodes(nameof(MissionTemplate.Objective)), &objT->Objective, state);
        Marshal(node.GetChildNodes(nameof(MissionTemplate.BonusObjective)), &objT->BonusObjective, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, TheaterOfWarTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TheaterOfWarTemplate.DisplayName), null), &objT->DisplayName, state);
        Marshal(node.GetAttributeValue(nameof(TheaterOfWarTemplate.AptTow), "Temp"), &objT->AptTow, state);
        Marshal(node.GetAttributeValue(nameof(TheaterOfWarTemplate.AutoStartMission), "-1"), &objT->AutoStartMission, state);
        Marshal(node.GetAttributeValue(nameof(TheaterOfWarTemplate.SummaryScreenMusic), null), &objT->SummaryScreenMusic, state);
        Marshal(node.GetAttributeValue(nameof(TheaterOfWarTemplate.SelectionScreenMusic), null), &objT->SelectionScreenMusic, state);
        Marshal(node.GetChildNodes(nameof(TheaterOfWarTemplate.Mission)), &objT->Mission, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, CampaignTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CampaignTemplate.DisplayName), null), &objT->DisplayName, state);
        Marshal(node.GetAttributeValue(nameof(CampaignTemplate.FinalMovie), null), &objT->FinalMovie, state);
        Marshal(node.GetAttributeValue(nameof(CampaignTemplate.AlternateFinalMovie), null), &objT->AlternateFinalMovie, state);
        Marshal(node.GetAttributeValue(nameof(CampaignTemplate.ConsoleAutosaveFilename), null), &objT->ConsoleAutosaveFilename, state);
        Marshal(node.GetChildNodes(nameof(CampaignTemplate.TheaterOfWar)), &objT->TheaterOfWar, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
