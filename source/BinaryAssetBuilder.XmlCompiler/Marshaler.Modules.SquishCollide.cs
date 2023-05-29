using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SquishCollideModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SquishCollideModuleData.CrushAnimTime), "1s"), &objT->CrushAnimTime, state);
        Marshal(node.GetAttributeValue(nameof(SquishCollideModuleData.CrushKillDelay), ".5s"), &objT->CrushKillDelay, state);
        Marshal(node.GetAttributeValue(nameof(SquishCollideModuleData.UseDirectionCheck), "true"), &objT->UseDirectionCheck, state);
        Marshal(node, (CollideModuleData*)objT, state);
    }
}
