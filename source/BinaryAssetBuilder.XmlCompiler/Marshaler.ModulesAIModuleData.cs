using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UpdateModuleData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x8D093323u:
                MarshalPolymorphicType<DozerAIUpdateModuleData, UpdateModuleData>(node, objT, state);
                break;
            case 0xCD56659Bu:
                MarshalPolymorphicType<AnimalAIUpdateModuleData, UpdateModuleData>(node, objT, state);
                break;
            case 0xD813AF2Au:
                MarshalPolymorphicType<WanderAIUpdateModuleData, UpdateModuleData>(node, objT, state);
                break;
            case 0xA9936C0Du:
                MarshalPolymorphicType<TransportHelicopterAIUpdateModuleData, UpdateModuleData>(node, objT, state);
                break;
            case 0x9AB8094Du:
                MarshalPolymorphicType<SupplyTruckAIUpdateModuleData, UpdateModuleData>(node, objT, state);
                break;
            case 0x4486CF48u:
                MarshalPolymorphicType<JetAIUpdateModuleData, UpdateModuleData>(node, objT, state);
                break;
            case 0x55D77703u:
                MarshalPolymorphicType<HordeAIUpdateModuleData, UpdateModuleData>(node, objT, state);
                break;
            case 0xBE9CD6FEu:
                MarshalPolymorphicType<TransportAIUpdateModuleData, UpdateModuleData>(node, objT, state);
                break;
            case 0xEE30DFD4u:
                MarshalPolymorphicType<DeployStyleAIUpdateModuleData, UpdateModuleData>(node, objT, state);
                break;
            case 0x347CED1Cu:
                MarshalPolymorphicType<AIGateUpdateModuleData, UpdateModuleData>(node, objT, state);
                break;
            case 0x00BDAFA3u:
                MarshalPolymorphicType<ConstructionYardAIUpdateModuleData, UpdateModuleData>(node, objT, state);
                break;
            case 0x08DBC00Eu:
                MarshalPolymorphicType<AIUpdateModuleData, UpdateModuleData>(node, objT, state);
                break;
        }
    }
}
