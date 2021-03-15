using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DamageCreationList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DamageCreationList.ObjectCreationList), null), &objT->ObjectCreationList, state);
        Marshal(node.GetAttributeValue(nameof(DamageCreationList.TriggerFX), null), &objT->TriggerFX, state);
        Marshal(node.GetAttributeValue(nameof(DamageCreationList.DestroyedSide), null), &objT->DestroyedSide, state);
    }

    public static unsafe void Marshal(Node node, ActiveBodyModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.MaxHealth), "0"), &objT->MaxHealth, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.MaxHealthDamaged), "0"), &objT->MaxHealthDamaged, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.MaxHealthReallyDamaged), "0"), &objT->MaxHealthReallyDamaged, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.InitialHealth), "-1.0"), &objT->InitialHealth, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.RecoveryTime), "0"), &objT->RecoveryTime, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.DodgePercent), "0"), &objT->DodgePercent, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.EnteringDamagedTransitionTime), "0s"), &objT->EnteringDamagedTransitionTime, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.EnteringReallyDamagedTransitionTime), "0s"), &objT->EnteringReallyDamagedTransitionTime, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.GrabObject), null), &objT->GrabObject, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.GrabFX), null), &objT->GrabFX, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.GrabDamage), "200.0"), &objT->GrabDamage, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.UseDefaultDamageSettings), "true"), &objT->UseDefaultDamageSettings, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.HealingBuffFX), null), &objT->HealingBuffFX, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.DamagedAttributeModifier), null), &objT->DamagedAttributeModifier, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.ReallyDamagedAttributeModifier), null), &objT->ReallyDamagedAttributeModifier, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.CheerRadius), "200.0"), &objT->CheerRadius, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.RemoveUpgradesOnDeath), "false"), &objT->RemoveUpgradesOnDeath, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.BurningDeathBehavior), "false"), &objT->BurningDeathBehavior, state);
        Marshal(node.GetAttributeValue(nameof(ActiveBodyModuleData.BurningDeathFX), null), &objT->BurningDeathFX, state);
        Marshal(node.GetChildNode(nameof(ActiveBodyModuleData.GrabOffset), null), &objT->GrabOffset, state);
        Marshal(node.GetChildNodes(nameof(ActiveBodyModuleData.DamageCreation)), &objT->DamageCreation, state);
        Marshal(node, (BodyModuleData*)objT, state);
    }
}
