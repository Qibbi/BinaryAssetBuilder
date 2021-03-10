using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ExperienceLevelTemplateLevelUpFxList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplateLevelUpFxList.FxList), null), &objT->FxList, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplateLevelUpFxList.BoneName), null), &objT->BoneName, state);
    }

    public static unsafe void Marshal(Node node, ExperienceLevelTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.Rank), "0"), &objT->Rank, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.RequiredExperience), "1"), &objT->RequiredExperience, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.ExperienceAward), "0"), &objT->ExperienceAward, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.ExperienceAwardOwnGuysDie), "0"), &objT->ExperienceAwardOwnGuysDie, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.Prerequisite), null), &objT->Prerequisite, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.LevelUpOCL), null), &objT->LevelUpOCL, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.ModelConditionState), null), &objT->ModelConditionState, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.InformUpdateModule), "false"), &objT->InformUpdateModule, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.SinglePlayerOnly), "false"), &objT->SinglePlayerOnly, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.MultiPlayerOnly), "false"), &objT->MultiPlayerOnly, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.ShowLevelUpTint), "false"), &objT->ShowLevelUpTint, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.LevelUpTintPreColorTime), "0.0s"), &objT->LevelUpTintPreColorTime, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.LevelUpTintPostColorTime), "0.0s"), &objT->LevelUpTintPostColorTime, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.LevelUpTintSustainColorTime), "0.0s"), &objT->LevelUpTintSustainColorTime, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.LevelUpTintFrequency), "0.0"), &objT->LevelUpTintFrequency, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelTemplate.LevelUpTintAmplitude), "0.0"), &objT->LevelUpTintAmplitude, state);
        Marshal(node.GetChildNode(nameof(ExperienceLevelTemplate.LevelUpTintColor), null), &objT->LevelUpTintColor, state);
        Marshal(node.GetChildNodes(nameof(ExperienceLevelTemplate.Upgrade)), &objT->Upgrade, state);
        Marshal(node.GetChildNodes(nameof(ExperienceLevelTemplate.LevelUpFxList)), &objT->LevelUpFxList, state);
        Marshal(node.GetChildNodes(nameof(ExperienceLevelTemplate.Target)), &objT->Target, state);
        Marshal(node.GetChildNodes(nameof(ExperienceLevelTemplate.AttributeModifier)), &objT->AttributeModifier, state);
        Marshal(node.GetChildNode(nameof(ExperienceLevelTemplate.Decal), null), &objT->Decal, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
