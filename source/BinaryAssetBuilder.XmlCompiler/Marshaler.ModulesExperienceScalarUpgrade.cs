using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ExperienceScalarUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ExperienceScalarUpgradeModuleData.AddXPScalar), "0"), &objT->AddXPScalar, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
