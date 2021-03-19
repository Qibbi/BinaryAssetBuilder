using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CreateCrateDieModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CreateCrateDieModuleData.CrateNameList), null), &objT->CrateNameList, state);
        Marshal(node, (DieModuleData*)objT, state);
    }
}
