using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, HelicopterSlowDeathBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.SpiralOrbitTurnRate), null), &objT->SpiralOrbitTurnRate, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.SpiralOrbitForwardSpeed), null), &objT->SpiralOrbitForwardSpeed, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.SpiralOrbitForwardSpeedDamping), "1.0"), &objT->SpiralOrbitForwardSpeedDamping, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.MinSelfSpin), null), &objT->MinSelfSpin, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.MaxSelfSpin), null), &objT->MaxSelfSpin, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.SelfSpinUpdateDelay), null), &objT->SelfSpinUpdateDelay, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.SelfSpinUpdateAmount), null), &objT->SelfSpinUpdateAmount, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.FallHowFast), null), &objT->FallHowFast, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.MinBladeFlyOffDelay), null), &objT->MinBladeFlyOffDelay, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.MaxBladeFlyOffDelay), null), &objT->MaxBladeFlyOffDelay, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.AttachParticleSystem), null), &objT->AttachParticleSystem, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.AttachParticleBone), null), &objT->AttachParticleBone, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.BladeBone), null), &objT->BladeBone, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.OclEjectPilot), null), &objT->OclEjectPilot, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.FxBlade), null), &objT->FxBlade, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.OclBlade), null), &objT->OclBlade, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.FxHitGround), null), &objT->FxHitGround, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.OclHitGround), null), &objT->OclHitGround, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.FxFinalBlowUp), null), &objT->FxFinalBlowUp, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.OclFinalBlowUp), null), &objT->OclFinalBlowUp, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.DelayFromGroundToFinalDeath), null), &objT->DelayFromGroundToFinalDeath, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.FinalRubbleObject), null), &objT->FinalRubbleObject, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.MaxBraking), "99999.9"), &objT->MaxBraking, state);
        Marshal(node.GetAttributeValue(nameof(HelicopterSlowDeathBehaviorModuleData.DeathSound), null), &objT->DeathSound, state);
        Marshal(node.GetChildNode(nameof(HelicopterSlowDeathBehaviorModuleData.AttachParticleLoc), null), &objT->AttachParticleLoc, state);
        Marshal(node, (SlowDeathBehaviorModuleData*)objT, state);
    }
}
