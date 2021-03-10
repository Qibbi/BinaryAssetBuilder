using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MusicScriptConditionNuggetBase* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionExpensiveNuggetBase* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionExpensiveNuggetBase.TimeBetweenConditionChecks), "5s"), &objT->TimeBetweenConditionChecks, state);
        Marshal(node, (MusicScriptConditionNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionNugget_LocalPlayerIsObserver* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_LocalPlayerIsObserver.CountDeadPlayersAsObservers), null), &objT->CountDeadPlayersAsObservers, state);
        Marshal(node, (MusicScriptConditionNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionNugget_UnitsFarFromBase* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_UnitsFarFromBase.MinUnitsToPass), null), &objT->MinUnitsToPass, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_UnitsFarFromBase.MinDistanceFromBase), null), &objT->MinDistanceFromBase, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_UnitsFarFromBase.Relationship), null), &objT->Relationship, state);
        Marshal(node, (MusicScriptConditionExpensiveNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionNugget_TimeFromStartOfLevel* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_TimeFromStartOfLevel.Timeout), null), &objT->Timeout, state);
        Marshal(node, (MusicScriptConditionNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionNugget_TrackPlayedCount* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_TrackPlayedCount.Track), null), &objT->Track, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_TrackPlayedCount.Count), null), &objT->Count, state);
        Marshal(node, (MusicScriptConditionNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionNugget_SpecificTrackTypePlaying* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_SpecificTrackTypePlaying.TrackType), null), &objT->TrackType, state);
        Marshal(node, (MusicScriptConditionNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionNugget_AnyTrackPlaying* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (MusicScriptConditionNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionNugget_ObjectsOfTypeExist* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_ObjectsOfTypeExist.Count), "1"), &objT->Count, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_ObjectsOfTypeExist.RequiredModelConditions), ""), &objT->RequiredModelConditions, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_ObjectsOfTypeExist.ExcludedModelConditions), ""), &objT->ExcludedModelConditions, state);
        Marshal(node.GetChildNode(nameof(MusicScriptConditionNugget_ObjectsOfTypeExist.Filter), null), &objT->Filter, state);
        Marshal(node, (MusicScriptConditionExpensiveNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionNugget_EvaEventPlayedRecently* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_EvaEventPlayedRecently.EvaEvent), null), &objT->EvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_EvaEventPlayedRecently.Timeout), "1s"), &objT->Timeout, state);
        Marshal(node, (MusicScriptConditionNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionNugget_ObjectsNearEvaEvent* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_ObjectsNearEvaEvent.EvaEvent), null), &objT->EvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_ObjectsNearEvaEvent.Count), "1"), &objT->Count, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_ObjectsNearEvaEvent.Distance), null), &objT->Distance, state);
        Marshal(node.GetChildNode(nameof(MusicScriptConditionNugget_ObjectsNearEvaEvent.Filter), null), &objT->Filter, state);
        Marshal(node, (MusicScriptConditionExpensiveNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionNugget_ScoredKillCount* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_ScoredKillCount.Count), null), &objT->Count, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_ScoredKillCount.Time), null), &objT->Time, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_ScoredKillCount.CountOnlyKillsAgainstTheLocalPlayer), null), &objT->CountOnlyKillsAgainstTheLocalPlayer, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_ScoredKillCount.CountOnlyKillsByTheLocalPlayer), null), &objT->CountOnlyKillsByTheLocalPlayer, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptConditionNugget_ScoredKillCount.Filter), null), &objT->Filter, state);
        Marshal(node, (MusicScriptConditionNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionNugget_Not* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(MusicScriptConditionNugget_Not.Condition), null), &objT->Condition, state);
        Marshal(node, (MusicScriptConditionNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionNugget_Or* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(MusicScriptConditionNugget_Or.Condition)), &objT->Condition, state);
        Marshal(node, (MusicScriptConditionNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptConditionNugget_And* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(MusicScriptConditionNugget_And.Condition)), &objT->Condition, state);
        Marshal(node, (MusicScriptConditionNuggetBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptTimeoutSpecifier* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MusicScriptTimeoutSpecifier.Weight), "1000"), &objT->Weight, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptTimeoutSpecifier.Duration), null), &objT->Duration, state);
    }

    public static unsafe void Marshal(Node node, MusicScriptTrack* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MusicScriptTrack.TrackTypeKey), ""), &objT->TrackTypeKey, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptTrack.Level), null), &objT->Level, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptTrack.Priority), null), &objT->Priority, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptTrack.Condition), null), &objT->Condition, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptTrack.ConditionsAreLatch), null), &objT->ConditionsAreLatch, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptTrack.Track), null), &objT->Track, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptTrack.FadeInTrack), null), &objT->FadeInTrack, state);
        Marshal(node.GetAttributeValue(nameof(MusicScriptTrack.FadeOutLowerLevelTrack), null), &objT->FadeOutLowerLevelTrack, state);
        Marshal(node.GetChildNodes(nameof(MusicScriptTrack.Timeout)), &objT->Timeout, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicPalette* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MusicPalette.IsDefaultForNewMap), "false"), &objT->IsDefaultForNewMap, state);
        Marshal(node.GetChildNodes(nameof(MusicScriptTrack.Track)), &objT->Track, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
