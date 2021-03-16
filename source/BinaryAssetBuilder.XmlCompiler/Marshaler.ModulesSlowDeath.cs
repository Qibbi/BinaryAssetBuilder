using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SlowDeathBaseType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SlowDeathBaseType.Type), null), &objT->Type, state);
    }

    public static unsafe void Marshal(Node node, SlowDeathFXListType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(SlowDeathFXListType.FX)), &objT->FX, state);
        Marshal(node, (SlowDeathBaseType*)objT, state);
    }

    public static unsafe void Marshal(Node node, SlowDeathOCLType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(SlowDeathOCLType.OCL)), &objT->OCL, state);
        Marshal(node, (SlowDeathBaseType*)objT, state);
    }

    public static unsafe void Marshal(Node node, SlowDeathWeaponType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(SlowDeathWeaponType.Weapon)), &objT->Weapon, state);
        Marshal(node, (SlowDeathBaseType*)objT, state);
    }

    public static unsafe void Marshal(Node node, SlowDeathSoundType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(SlowDeathSoundType.List)), &objT->List, state);
        Marshal(node, (SlowDeathBaseType*)objT, state);
    }

    public static unsafe void Marshal(Node node, SlowDeathBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.SinkRate), "0"), &objT->SinkRate, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.ProbabilityModifier), "10"), &objT->ProbabilityModifier, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.ModifierBonusPerOverkillPercent), "0"), &objT->ModifierBonusPerOverkillPercent, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.SinkDelay), "0s"), &objT->SinkDelay, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.SinkDelayVariance), "0s"), &objT->SinkDelayVariance, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.DestructionDelay), "0s"), &objT->DestructionDelay, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.DestructionDelayVariance), "0s"), &objT->DestructionDelayVariance, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.DecayBeginTime), "0s"), &objT->DecayBeginTime, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.FlingForce), "0"), &objT->FlingForce, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.FlingForceVariance), "0"), &objT->FlingForceVariance, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.FlingPitch), null), &objT->FlingPitch, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.FlingPitchVariance), null), &objT->FlingPitchVariance, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.DeathFlags), null), &objT->DeathFlags, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.ShadowWhenDead), "false"), &objT->ShadowWhenDead, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.Fade), "false"), &objT->Fade, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.FadeTime), "0s"), &objT->FadeTime, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.FadeDelay), "0s"), &objT->FadeDelay, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.DeathTypes), null), &objT->DeathTypes, state);
        Marshal(node.GetAttributeValue(nameof(SlowDeathBehaviorModuleData.DeathObjectStatusBits), null), &objT->DeathObjectStatusBits, state);
        Marshal(node.GetChildNodes(nameof(SlowDeathBehaviorModuleData.FX)), &objT->FX, state);
        Marshal(node.GetChildNodes(nameof(SlowDeathBehaviorModuleData.OCL)), &objT->OCL, state);
        Marshal(node.GetChildNodes(nameof(SlowDeathBehaviorModuleData.Weapon)), &objT->Weapon, state);
        Marshal(node.GetChildNodes(nameof(SlowDeathBehaviorModuleData.Sound)), &objT->Sound, state);
        Marshal(node.GetChildNode(nameof(SlowDeathBehaviorModuleData.DieMuxData), null), &objT->DieMuxData, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
