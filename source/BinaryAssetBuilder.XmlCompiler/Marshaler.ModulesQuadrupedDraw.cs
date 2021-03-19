using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, W3DQuadrupedDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DQuadrupedDrawModuleData.LeftFrontFootBone), null), &objT->LeftFrontFootBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DQuadrupedDrawModuleData.RightFrontFootBone), null), &objT->RightFrontFootBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DQuadrupedDrawModuleData.LeftRearFootBone), null), &objT->LeftRearFootBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DQuadrupedDrawModuleData.RightRearFootBone), null), &objT->RightRearFootBone, state);
        Marshal(node, (W3DScriptedModelDrawModuleData*)objT, state);
    }
}