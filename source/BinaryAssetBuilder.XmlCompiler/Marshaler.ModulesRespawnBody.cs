using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RespawnBodyModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RespawnBodyModuleData.UseRespawn), "false"), &objT->UseRespawn, state);
        Marshal(node.GetChildNode(nameof(RespawnBodyModuleData.PermanentlyKilledByFilter), null), &objT->PermanentlyKilledByFilter, state);
        Marshal(node, (ActiveBodyModuleData*)objT, state);
    }
}
