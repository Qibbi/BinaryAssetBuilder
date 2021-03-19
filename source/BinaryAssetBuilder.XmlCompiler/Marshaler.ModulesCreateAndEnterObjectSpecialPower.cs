using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CreateAndEnterObjectSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(CreateAndEnterObjectSpecialPowerModuleData.FXOffset), null), &objT->FXOffset, state);
        Marshal(node, (OCLSpecialPowerModuleData*)objT, state);
    }
}
