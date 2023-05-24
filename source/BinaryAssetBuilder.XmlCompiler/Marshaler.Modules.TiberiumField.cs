using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TiberiumFieldBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.DamageUpdateFrequencySeconds), "0.67s"), &objT->DamageUpdateFrequencySeconds, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.HealUpdateFrequencySeconds), "0.60s"), &objT->HealUpdateFrequencySeconds, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.Radius), "0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.DamageRadiusAdd), "20"), &objT->DamageRadiusAdd, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.HealRadiusAdd), "20"), &objT->HealRadiusAdd, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.FieldResolution), "40"), &objT->FieldResolution, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.MaxFieldMoney), "0"), &objT->MaxFieldMoney, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.StartingFieldMoney), "0"), &objT->StartingFieldMoney, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.ThingToSpawn), null), &objT->ThingToSpawn, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.SpawnOffset), "0.0"), &objT->SpawnOffset, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.ClusterScaleFactor), "1.0"), &objT->ClusterScaleFactor, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.ClusterPowerFactor), "1.0"), &objT->ClusterPowerFactor, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.CrystalGrowthRate), "0"), &objT->CrystalGrowthRate, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.LifetimeFieldMoney), "0"), &objT->LifetimeFieldMoney, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.KillWhenEmptyAndFinishedSpawning), "false"), &objT->KillWhenEmptyAndFinishedSpawning, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldBehaviorModuleData.AllowStartingFieldCrystalsToGrow), "false"), &objT->AllowStartingFieldCrystalsToGrow, state);
        Marshal(node.GetChildNode(nameof(TiberiumFieldBehaviorModuleData.DamageFilter), null), &objT->DamageFilter, state);
        Marshal(node.GetChildNode(nameof(TiberiumFieldBehaviorModuleData.HealFilter), null), &objT->HealFilter, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
