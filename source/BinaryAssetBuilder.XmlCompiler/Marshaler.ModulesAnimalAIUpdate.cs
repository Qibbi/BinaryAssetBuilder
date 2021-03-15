using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AnimalAIUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AnimalAIUpdateModuleData.FleeRadius), "20"), &objT->FleeRadius, state);
        Marshal(node.GetAttributeValue(nameof(AnimalAIUpdateModuleData.FleeDistance), "100"), &objT->FleeDistance, state);
        Marshal(node.GetAttributeValue(nameof(AnimalAIUpdateModuleData.WanderPercentage), "35"), &objT->WanderPercentage, state);
        Marshal(node.GetAttributeValue(nameof(AnimalAIUpdateModuleData.MinDistance), "15"), &objT->MinDistance, state);
        Marshal(node.GetAttributeValue(nameof(AnimalAIUpdateModuleData.MaxDistance), "50"), &objT->MaxDistance, state);
        Marshal(node.GetAttributeValue(nameof(AnimalAIUpdateModuleData.Radius), "25"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(AnimalAIUpdateModuleData.FleeUpdateTimer), "0.8s"), &objT->FleeUpdateTimer, state);
        Marshal(node.GetAttributeValue(nameof(AnimalAIUpdateModuleData.WanderUpdateTimer), "2.0s"), &objT->WanderUpdateTimer, state);
        Marshal(node.GetAttributeValue(nameof(AnimalAIUpdateModuleData.AfraidOfCastles), "true"), &objT->AfraidOfCastles, state);
        Marshal(node.GetAttributeValue(nameof(AnimalAIUpdateModuleData.InitialFleeBlindlyRadius), "50.0"), &objT->InitialFleeBlindlyRadius, state);
        Marshal(node, (AIUpdateModuleData*)objT, state);
    }
}
