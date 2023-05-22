using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ToppleUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ToppleUpdateModuleData.ToppleFX), null), &objT->ToppleFX, state);
        Marshal(node.GetAttributeValue(nameof(ToppleUpdateModuleData.BounceFX), null), &objT->BounceFX, state);
        Marshal(node.GetAttributeValue(nameof(ToppleUpdateModuleData.StumpId), null), &objT->StumpId, state);
        Marshal(node.GetAttributeValue(nameof(ToppleUpdateModuleData.InitialVelocityPercent), "20%"), &objT->InitialVelocityPercent, state);
        Marshal(node.GetAttributeValue(nameof(ToppleUpdateModuleData.InitialAccelPercent), "1%"), &objT->InitialAccelPercent, state);
        Marshal(node.GetAttributeValue(nameof(ToppleUpdateModuleData.BounceVelocityPercent), "20%"), &objT->BounceVelocityPercent, state);
        Marshal(node.GetAttributeValue(nameof(ToppleUpdateModuleData.MinimumToppleSpeed), "0.5"), &objT->MinimumToppleSpeed, state);
        Marshal(node.GetAttributeValue(nameof(ToppleUpdateModuleData.KillWhenToppled), "false"), &objT->KillWhenToppled, state);
        Marshal(node.GetAttributeValue(nameof(ToppleUpdateModuleData.KillWhenStartToppled), "false"), &objT->KillWhenStartToppled, state);
        Marshal(node.GetAttributeValue(nameof(ToppleUpdateModuleData.KillStumpWhenToppled), "false"), &objT->KillStumpWhenToppled, state);
        Marshal(node.GetAttributeValue(nameof(ToppleUpdateModuleData.ToppleLeftOrRightOnly), "false"), &objT->ToppleLeftOrRightOnly, state);
        Marshal(node.GetAttributeValue(nameof(ToppleUpdateModuleData.ReorientToppledRubble), "false"), &objT->ReorientToppledRubble, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
