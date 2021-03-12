using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ArmorListType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ArmorListType.Damage), null), &objT->Damage, state);
        Marshal(node.GetAttributeValue(nameof(ArmorListType.Percent), null), &objT->Percent, state);
    }

    public static unsafe void Marshal(Node node, ArmorTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ArmorTemplate.Default), "100"), &objT->Default, state);
        Marshal(node.GetAttributeValue(nameof(ArmorTemplate.DamageScalar), "100"), &objT->DamageScalar, state);
        Marshal(node.GetAttributeValue(nameof(ArmorTemplate.SideDamageScalar), "100"), &objT->SideDamageScalar, state);
        Marshal(node.GetAttributeValue(nameof(ArmorTemplate.RearDamageScalar), "100"), &objT->RearDamageScalar, state);
        Marshal(node.GetAttributeValue(nameof(ArmorTemplate.FlankedPenalty), "100%"), &objT->FlankedPenalty, state);
        Marshal(node.GetChildNodes(nameof(ArmorTemplate.Armor)), &objT->Armor, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
