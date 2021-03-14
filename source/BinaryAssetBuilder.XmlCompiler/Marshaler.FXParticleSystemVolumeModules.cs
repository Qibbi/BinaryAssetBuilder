using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FXParticleEmissionVolumeBase* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleEmissionVolumeBase.IsHollow), null), &objT->IsHollow, state);
        Marshal(node, (FXParticleBaseModule*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEmissionVolumeBox* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(FXParticleEmissionVolumeBox.HalfSize), null), &objT->HalfSize, state);
        Marshal(node, (FXParticleEmissionVolumeBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEmissionVolumeCylinder* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleEmissionVolumeCylinder.Radius), null), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleEmissionVolumeCylinder.RadiusRate), null), &objT->RadiusRate, state);
        Marshal(node.GetAttributeValue(nameof(FXParticleEmissionVolumeCylinder.Length), null), &objT->Length, state);
        Marshal(node.GetChildNode(nameof(FXParticleEmissionVolumeCylinder.Offset), null), &objT->Offset, state);
        Marshal(node, (FXParticleEmissionVolumeBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEmissionVolumeLine* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(FXParticleEmissionVolumeLine.StartPoint), null), &objT->StartPoint, state);
        Marshal(node.GetChildNode(nameof(FXParticleEmissionVolumeLine.EndPoint), null), &objT->EndPoint, state);
        Marshal(node, (FXParticleEmissionVolumeBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEmissionVolumeSpline* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(FXParticleEmissionVolumeSpline.StartPoint), null), &objT->StartPoint, state);
        Marshal(node.GetChildNode(nameof(FXParticleEmissionVolumeSpline.EndPoint), null), &objT->EndPoint, state);
        Marshal(node, (FXParticleEmissionVolumeBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEmissionVolumePoint* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (FXParticleEmissionVolumeBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEmissionVolumeSphere* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleEmissionVolumeSphere.Radius), null), &objT->Radius, state);
        Marshal(node, (FXParticleEmissionVolumeBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEmissionVolumeTerrainFire* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXParticleEmissionVolumeTerrainFire.CellEmissionChance), null), &objT->CellEmissionChance, state);
        Marshal(node.GetChildNode(nameof(FXParticleEmissionVolumeTerrainFire.Offset), null), &objT->Offset, state);
        Marshal(node, (FXParticleEmissionVolumeBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEmissionVolumeLightning* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (FXParticleEmissionVolumeBase*)objT, state);
    }

    public static unsafe void Marshal(Node node, FXParticleEmissionVolumeBase** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x54D712BFu:
                MarshalPolymorphicType<FXParticleEmissionVolumeLightning, FXParticleEmissionVolumeBase>(node, objT, state);
                break;
            case 0xE0E03E35u:
                MarshalPolymorphicType<FXParticleEmissionVolumeTerrainFire, FXParticleEmissionVolumeBase>(node, objT, state);
                break;
            case 0xEDF83B69u:
                MarshalPolymorphicType<FXParticleEmissionVolumeSphere, FXParticleEmissionVolumeBase>(node, objT, state);
                break;
            case 0xD32FC96Bu:
                MarshalPolymorphicType<FXParticleEmissionVolumePoint, FXParticleEmissionVolumeBase>(node, objT, state);
                break;
            case 0x2F6F162Au:
                MarshalPolymorphicType<FXParticleEmissionVolumeSpline, FXParticleEmissionVolumeBase>(node, objT, state);
                break;
            case 0x0DA35F9Cu:
                MarshalPolymorphicType<FXParticleEmissionVolumeLine, FXParticleEmissionVolumeBase>(node, objT, state);
                break;
            case 0x5C8A6F16u:
                MarshalPolymorphicType<FXParticleEmissionVolumeCylinder, FXParticleEmissionVolumeBase>(node, objT, state);
                break;
            case 0x4A0B96F4u:
                MarshalPolymorphicType<FXParticleEmissionVolumeBox, FXParticleEmissionVolumeBase>(node, objT, state);
                break;
        }
    }
}
