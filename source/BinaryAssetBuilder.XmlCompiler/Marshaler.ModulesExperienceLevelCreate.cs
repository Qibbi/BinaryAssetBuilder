using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ExperienceLevelCreateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelCreateModuleData.Level), "0"), &objT->Level, state);
        Marshal(node.GetAttributeValue(nameof(ExperienceLevelCreateModuleData.MPOnly), "false"), &objT->MPOnly, state);
        Marshal(node, (CreateModuleData*)objT, state);
    }
}
