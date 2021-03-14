using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FXParticleEventBase* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleEventBase.EventFX), null), &objT->EventFX, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleEventBase.PerParticle), null), &objT->PerParticle, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleEventBase.KillAfterEvent), null), &objT->KillAfterEvent, state);
        Marshal(node, (FXParticleBaseModule*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEventLife* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(FXParticleEventLife.EventTime), null), &objT->EventTime, state);
        Marshal(node, (FXParticleEventBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEventCollision* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleEventCollision.OrientFXToTerrain), "false"), &objT->OrientFXToTerrain, state);
        Marshal(node.GetChildNode(nameof(FXParticleEventCollision.HeightOffset), null), &objT->HeightOffset, state);
        Marshal(node, (FXParticleEventBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEventBase** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x401E3B7Fu:
                MarshalPolymorphicType<FXParticleEventCollision, FXParticleEventBase>(node, objT, state);
                break;
            case 0xCE96A52Du:
                MarshalPolymorphicType<FXParticleEventLife, FXParticleEventBase>(node, objT, state);
                break;
        }
    }
}
