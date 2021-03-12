using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CreateUnitInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CreateUnitInfo.MinUnits), "1"), &objT->MinUnits, state);
        Marshal(node.GetAttributeValue(nameof(CreateUnitInfo.MaxUnits), "1"), &objT->MaxUnits, state);
        Marshal(node.GetAttributeValue(nameof(CreateUnitInfo.UnitName), null), &objT->UnitName, state);
        Marshal(node.GetAttributeValue(nameof(CreateUnitInfo.ExperienceLevel), "1"), &objT->ExperienceLevel, state);
    }

    public static unsafe void Marshal(Node node, AITeamTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AITeamTemplate.MinUnits), "1"), &objT->MinUnits, state);
        Marshal(node.GetAttributeValue(nameof(AITeamTemplate.MaxUnits), null), &objT->MaxUnits, state);
        Marshal(node.GetAttributeValue(nameof(AITeamTemplate.IncludeKindOf), null), &objT->IncludeKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AITeamTemplate.ExcludeKindOf), null), &objT->ExcludeKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AITeamTemplate.AlwaysRecruit), "false"), &objT->AlwaysRecruit, state);
        Marshal(node.GetAttributeValue(nameof(AITeamTemplate.AlwaysRelease), "false"), &objT->AlwaysRelease, state);
        Marshal(node.GetAttributeValue(nameof(AITeamTemplate.AutoReinforce), "false"), &objT->AutoReinforce, state);
        Marshal(node.GetChildNodes(nameof(AITeamTemplate.CreateUnits)), &objT->CreateUnits, state);
    }
}
