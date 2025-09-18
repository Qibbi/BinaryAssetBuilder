using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    // Hold BitFlags<uint, Type> Marshalers here as C# has no support of values as generic arguments. Hopefully they come in the future, so this is just copy/paste.

    public static unsafe void Marshal(string text, AIDifficultyBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < AIDifficultyBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            AIDifficulty value = (AIDifficulty)(-1);
            Marshal(token, &value, state);
            if (value != (AIDifficulty)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < AIDifficultyBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / AIDifficultyBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % AIDifficultyBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / AIDifficultyBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % AIDifficultyBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < AIDifficultyBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, AIDifficultyBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, ArmorSetBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < ArmorSetBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            ArmorSetType value = (ArmorSetType)(-1);
            Marshal(token, &value, state);
            if (value != (ArmorSetType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < ArmorSetBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / ArmorSetBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % ArmorSetBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / ArmorSetBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % ArmorSetBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < ArmorSetBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, ArmorSetBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, AttachUpdateFlagsBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < AttachUpdateFlagsBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            AttachUpdateFlagsType value = (AttachUpdateFlagsType)(-1);
            Marshal(token, &value, state);
            if (value != (AttachUpdateFlagsType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < AttachUpdateFlagsBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / AttachUpdateFlagsBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % AttachUpdateFlagsBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / AttachUpdateFlagsBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % AttachUpdateFlagsBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < AttachUpdateFlagsBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, AttachUpdateFlagsBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, AttributeModifierAuraUpdateRequiredBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < AttributeModifierAuraUpdateRequiredBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            AttributeModifierAuraUpdateRequired value = (AttributeModifierAuraUpdateRequired)(-1);
            Marshal(token, &value, state);
            if (value != (AttributeModifierAuraUpdateRequired)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < AttributeModifierAuraUpdateRequiredBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / AttributeModifierAuraUpdateRequiredBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % AttributeModifierAuraUpdateRequiredBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / AttributeModifierAuraUpdateRequiredBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % AttributeModifierAuraUpdateRequiredBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < AttributeModifierAuraUpdateRequiredBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, AttributeModifierAuraUpdateRequiredBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, AttributeModifierCategoryBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < AttributeModifierCategoryBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            AttributeModifierCategoryType value = (AttributeModifierCategoryType)(-1);
            Marshal(token, &value, state);
            if (value != (AttributeModifierCategoryType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < AttributeModifierCategoryBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / AttributeModifierCategoryBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % AttributeModifierCategoryBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / AttributeModifierCategoryBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % AttributeModifierCategoryBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < AttributeModifierCategoryBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, AttributeModifierCategoryBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, AudioControlFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < AudioControlFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            AudioControlFlag value = (AudioControlFlag)(-1);
            Marshal(token, &value, state);
            if (value != (AudioControlFlag)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < AudioControlFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / AudioControlFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % AudioControlFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / AudioControlFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % AudioControlFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < AudioControlFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, AudioControlFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, AudioTypeFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < AudioTypeFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            AudioTypeFlag value = (AudioTypeFlag)(-1);
            Marshal(token, &value, state);
            if (value != (AudioTypeFlag)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < AudioTypeFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / AudioTypeFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % AudioTypeFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / AudioTypeFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % AudioTypeFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < AudioTypeFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, AudioTypeFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, AutoAcquireEnemiesBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < AutoAcquireEnemiesBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            AutoAcquireEnemiesType value = (AutoAcquireEnemiesType)(-1);
            Marshal(token, &value, state);
            if (value != (AutoAcquireEnemiesType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < AutoAcquireEnemiesBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / AutoAcquireEnemiesBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % AutoAcquireEnemiesBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / AutoAcquireEnemiesBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % AutoAcquireEnemiesBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < AutoAcquireEnemiesBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, AutoAcquireEnemiesBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, AutoDepositBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < AutoDepositBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            AutoDepositFlagsType value = (AutoDepositFlagsType)(-1);
            Marshal(token, &value, state);
            if (value != (AutoDepositFlagsType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < AutoDepositBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / AutoDepositBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % AutoDepositBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / AutoDepositBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % AutoDepositBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < AutoDepositBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, AutoDepositBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, BuildPlacementTypeBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < BuildPlacementTypeBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            BuildPlacementType value = (BuildPlacementType)(-1);
            Marshal(token, &value, state);
            if (value != (BuildPlacementType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < BuildPlacementTypeBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / BuildPlacementTypeBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % BuildPlacementTypeBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / BuildPlacementTypeBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % BuildPlacementTypeBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < BuildPlacementTypeBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, BuildPlacementTypeBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, CampaignFlagBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < CampaignFlagBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            CampaignFlagType value = (CampaignFlagType)(-1);
            Marshal(token, &value, state);
            if (value != (CampaignFlagType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < CampaignFlagBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / CampaignFlagBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % CampaignFlagBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / CampaignFlagBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % CampaignFlagBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < CampaignFlagBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, CampaignFlagBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, CommandSourceBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < CommandSourceBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            CommandSourceType value = (CommandSourceType)(-1);
            Marshal(token, &value, state);
            if (value != (CommandSourceType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < CommandSourceBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / CommandSourceBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % CommandSourceBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / CommandSourceBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % CommandSourceBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < CommandSourceBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, CommandSourceBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, ConditionsBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < ConditionsBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            ConditionsType value = (ConditionsType)(-1);
            Marshal(token, &value, state);
            if (value != (ConditionsType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < ConditionsBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / ConditionsBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % ConditionsBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / ConditionsBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % ConditionsBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < ConditionsBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, ConditionsBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, DamageBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < DamageBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            DamageType value = (DamageType)(-1);
            Marshal(token, &value, state);
            if (value != (DamageType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < DamageBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / DamageBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % DamageBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / DamageBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % DamageBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < DamageBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, DamageBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, DeathBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < DeathBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            DeathType value = (DeathType)(-1);
            Marshal(token, &value, state);
            if (value != (DeathType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < DeathBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / DeathBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % DeathBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / DeathBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % DeathBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < DeathBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, DeathBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, DisabledBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < DisabledBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            DisabledType value = (DisabledType)(-1);
            Marshal(token, &value, state);
            if (value != (DisabledType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < DisabledBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / DisabledBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % DisabledBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / DisabledBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % DisabledBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < DisabledBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, DisabledBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, DispositionTypeFlag* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < DispositionTypeFlag.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            DispositionType value = (DispositionType)(-1);
            Marshal(token, &value, state);
            if (value != (DispositionType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < DispositionTypeFlag.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / DispositionTypeFlag.BitsInSpan] |= (uint)(1 << (int)(uintValue % DispositionTypeFlag.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / DispositionTypeFlag.BitsInSpan] ^= (uint)(1 << (int)(uintValue % DispositionTypeFlag.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < DispositionTypeFlag.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, DispositionTypeFlag* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, FireWeaponFlagsBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < FireWeaponFlagsBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            FireWeaponFlagsType value = (FireWeaponFlagsType)(-1);
            Marshal(token, &value, state);
            if (value != (FireWeaponFlagsType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < FireWeaponFlagsBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / FireWeaponFlagsBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % FireWeaponFlagsBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / FireWeaponFlagsBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % FireWeaponFlagsBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < FireWeaponFlagsBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, FireWeaponFlagsBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, HotKeyModifierFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < HotKeyModifierFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            HotKeyModifier value = (HotKeyModifier)(-1);
            Marshal(token, &value, state);
            if (value != (HotKeyModifier)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < HotKeyModifierFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / HotKeyModifierFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % HotKeyModifierFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / HotKeyModifierFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % HotKeyModifierFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < HotKeyModifierFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, HotKeyModifierFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, InfoWarEffectBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < InfoWarEffectBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            InfoWarEffect value = (InfoWarEffect)(-1);
            Marshal(token, &value, state);
            if (value != (InfoWarEffect)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < InfoWarEffectBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / InfoWarEffectBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % InfoWarEffectBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / InfoWarEffectBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % InfoWarEffectBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < InfoWarEffectBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, InfoWarEffectBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, InitiateRepairDieOptionsFlag* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < InitiateRepairDieOptionsFlag.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            InitiateRepairDieOptions value = (InitiateRepairDieOptions)(-1);
            Marshal(token, &value, state);
            if (value != (InitiateRepairDieOptions)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < InitiateRepairDieOptionsFlag.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / InitiateRepairDieOptionsFlag.BitsInSpan] |= (uint)(1 << (int)(uintValue % InitiateRepairDieOptionsFlag.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / InitiateRepairDieOptionsFlag.BitsInSpan] ^= (uint)(1 << (int)(uintValue % InitiateRepairDieOptionsFlag.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < InitiateRepairDieOptionsFlag.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, InitiateRepairDieOptionsFlag* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, InvisibilityNuggetOptionsBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < InvisibilityNuggetOptionsBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            InvisibilityNuggetOptions value = (InvisibilityNuggetOptions)(-1);
            Marshal(token, &value, state);
            if (value != (InvisibilityNuggetOptions)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < InvisibilityNuggetOptionsBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / InvisibilityNuggetOptionsBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % InvisibilityNuggetOptionsBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / InvisibilityNuggetOptionsBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % InvisibilityNuggetOptionsBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < InvisibilityNuggetOptionsBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, InvisibilityNuggetOptionsBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, InvisibilityUpdateOptionsBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < InvisibilityUpdateOptionsBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            InvisibilityUpdateOptions value = (InvisibilityUpdateOptions)(-1);
            Marshal(token, &value, state);
            if (value != (InvisibilityUpdateOptions)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < InvisibilityUpdateOptionsBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / InvisibilityUpdateOptionsBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % InvisibilityUpdateOptionsBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / InvisibilityUpdateOptionsBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % InvisibilityUpdateOptionsBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < InvisibilityUpdateOptionsBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, InvisibilityUpdateOptionsBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, KindOfBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < KindOfBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            KindOf value = (KindOf)(-1);
            Marshal(token, &value, state);
            if (value != (KindOf)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < KindOfBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / KindOfBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % KindOfBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / KindOfBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % KindOfBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < KindOfBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, KindOfBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, LocomotorSurfaceBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < LocomotorSurfaceBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            Surface value = (Surface)(-1);
            Marshal(token, &value, state);
            if (value != (Surface)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < LocomotorSurfaceBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / LocomotorSurfaceBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % LocomotorSurfaceBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / LocomotorSurfaceBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % LocomotorSurfaceBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < LocomotorSurfaceBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, LocomotorSurfaceBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, LogicCommandOptionsBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < LogicCommandOptionsBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            LogicCommandOptions value = (LogicCommandOptions)(-1);
            Marshal(token, &value, state);
            if (value != (LogicCommandOptions)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < LogicCommandOptionsBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / LogicCommandOptionsBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % LogicCommandOptionsBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / LogicCommandOptionsBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % LogicCommandOptionsBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < LogicCommandOptionsBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, LogicCommandOptionsBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, MapObjectBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < MapObjectBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            MapObjectFlagType value = (MapObjectFlagType)(-1);
            Marshal(token, &value, state);
            if (value != (MapObjectFlagType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < MapObjectBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / MapObjectBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % MapObjectBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / MapObjectBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % MapObjectBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < MapObjectBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, MapObjectBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

#if KANESWRATH
    public static unsafe void Marshal(string text, MetaGameDependenciesType* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < MetaGameDependenciesType.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            MetaGameDependencyEnum value = (MetaGameDependencyEnum)(-1);
            Marshal(token, &value, state);
            if (value != (MetaGameDependencyEnum)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < MetaGameDependenciesType.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / MetaGameDependenciesType.BitsInSpan] |= (uint)(1 << (int)(uintValue % MetaGameDependenciesType.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / MetaGameDependenciesType.BitsInSpan] ^= (uint)(1 << (int)(uintValue % MetaGameDependenciesType.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < MetaGameDependenciesType.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, MetaGameDependenciesType* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(Value value, MetaGameDependenciesType** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(MetaGameDependenciesType), 1u);
        Marshal(value, *objT, state);
    }

    public static unsafe void Marshal(Node node, MetaGameDependenciesType** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    public static unsafe void Marshal(string text, MetagamePhaseBitflags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < MetagamePhaseBitflags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            MetagamePhaseEnum value = (MetagamePhaseEnum)(-1);
            Marshal(token, &value, state);
            if (value != (MetagamePhaseEnum)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < MetagamePhaseBitflags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / MetagamePhaseBitflags.BitsInSpan] |= (uint)(1 << (int)(uintValue % MetagamePhaseBitflags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / MetagamePhaseBitflags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % MetagamePhaseBitflags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < MetagamePhaseBitflags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, MetagamePhaseBitflags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }
#endif

    public static unsafe void Marshal(string text, ModelConditionBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < ModelConditionBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            ModelConditionFlagType value = (ModelConditionFlagType)(-1);
            Marshal(token, &value, state);
            if (value != (ModelConditionFlagType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < ModelConditionBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / ModelConditionBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % ModelConditionBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / ModelConditionBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % ModelConditionBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < ModelConditionBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, ModelConditionBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(Value value, ModelConditionBitFlags** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(ModelConditionBitFlags), 1u);
        Marshal(value, *objT, state);
    }

    public static unsafe void Marshal(string text, MultisoundControlFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < MultisoundControlFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            MultisoundControlFlag value = (MultisoundControlFlag)(-1);
            Marshal(token, &value, state);
            if (value != (MultisoundControlFlag)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < MultisoundControlFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / MultisoundControlFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % MultisoundControlFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / MultisoundControlFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % MultisoundControlFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < MultisoundControlFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, MultisoundControlFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, ObjectFilterRelationshipBitMask* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < ObjectFilterRelationshipBitMask.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            ObjectFilterRelationship value = (ObjectFilterRelationship)(-1);
            Marshal(token, &value, state);
            if (value != (ObjectFilterRelationship)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < ObjectFilterRelationshipBitMask.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / ObjectFilterRelationshipBitMask.BitsInSpan] |= (uint)(1 << (int)(uintValue % ObjectFilterRelationshipBitMask.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / ObjectFilterRelationshipBitMask.BitsInSpan] ^= (uint)(1 << (int)(uintValue % ObjectFilterRelationshipBitMask.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < ObjectFilterRelationshipBitMask.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, ObjectFilterRelationshipBitMask* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, ObjectStatusBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < ObjectStatusBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            ObjectStatusType value = (ObjectStatusType)(-1);
            Marshal(token, &value, state);
            if (value != (ObjectStatusType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < ObjectStatusBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / ObjectStatusBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % ObjectStatusBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / ObjectStatusBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % ObjectStatusBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < ObjectStatusBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, ObjectStatusBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(Value value, ObjectStatusBitFlags** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(ObjectStatusBitFlags), 1u);
        Marshal(value, *objT, state);
    }

    public static unsafe void Marshal(string text, OCLMonitorOptionFlag* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < OCLMonitorOptionFlag.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            OCLMonitorOption value = (OCLMonitorOption)(-1);
            Marshal(token, &value, state);
            if (value != (OCLMonitorOption)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < OCLMonitorOptionFlag.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / OCLMonitorOptionFlag.BitsInSpan] |= (uint)(1 << (int)(uintValue % OCLMonitorOptionFlag.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / OCLMonitorOptionFlag.BitsInSpan] ^= (uint)(1 << (int)(uintValue % OCLMonitorOptionFlag.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < OCLMonitorOptionFlag.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, OCLMonitorOptionFlag* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, OCNuggetOptionFlag* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < OCNuggetOptionFlag.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            OCNuggetOption value = (OCNuggetOption)(-1);
            Marshal(token, &value, state);
            if (value != (OCNuggetOption)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < OCNuggetOptionFlag.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / OCNuggetOptionFlag.BitsInSpan] |= (uint)(1 << (int)(uintValue % OCNuggetOptionFlag.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / OCNuggetOptionFlag.BitsInSpan] ^= (uint)(1 << (int)(uintValue % OCNuggetOptionFlag.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < OCNuggetOptionFlag.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, OCNuggetOptionFlag* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, ShroudClearOptionsBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < ShroudClearOptionsBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            ShroudClearOptionsType value = (ShroudClearOptionsType)(-1);
            Marshal(token, &value, state);
            if (value != (ShroudClearOptionsType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < ShroudClearOptionsBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / ShroudClearOptionsBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % ShroudClearOptionsBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / ShroudClearOptionsBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % ShroudClearOptionsBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < ShroudClearOptionsBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, ShroudClearOptionsBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, SpawnCrateUpdateFlagsBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < SpawnCrateUpdateFlagsBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            SpawnCrateUpdateFlagsType value = (SpawnCrateUpdateFlagsType)(-1);
            Marshal(token, &value, state);
            if (value != (SpawnCrateUpdateFlagsType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < SpawnCrateUpdateFlagsBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / SpawnCrateUpdateFlagsBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % SpawnCrateUpdateFlagsBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / SpawnCrateUpdateFlagsBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % SpawnCrateUpdateFlagsBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < SpawnCrateUpdateFlagsBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, SpawnCrateUpdateFlagsBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, SpecialAbilityUpdateOptionsTypeBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < SpecialAbilityUpdateOptionsTypeBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            SpecialAbilityUpdateOptionsType value = (SpecialAbilityUpdateOptionsType)(-1);
            Marshal(token, &value, state);
            if (value != (SpecialAbilityUpdateOptionsType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < SpecialAbilityUpdateOptionsTypeBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / SpecialAbilityUpdateOptionsTypeBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % SpecialAbilityUpdateOptionsTypeBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / SpecialAbilityUpdateOptionsTypeBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % SpecialAbilityUpdateOptionsTypeBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < SpecialAbilityUpdateOptionsTypeBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, SpecialAbilityUpdateOptionsTypeBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, SpecialPowerTemplateBitFlag* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < SpecialPowerTemplateBitFlag.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            SpecialPowerTemplateFlag value = (SpecialPowerTemplateFlag)(-1);
            Marshal(token, &value, state);
            if (value != (SpecialPowerTemplateFlag)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < SpecialPowerTemplateBitFlag.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / SpecialPowerTemplateBitFlag.BitsInSpan] |= (uint)(1 << (int)(uintValue % SpecialPowerTemplateBitFlag.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / SpecialPowerTemplateBitFlag.BitsInSpan] ^= (uint)(1 << (int)(uintValue % SpecialPowerTemplateBitFlag.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < SpecialPowerTemplateBitFlag.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, SpecialPowerTemplateBitFlag* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, WeaponAffectsBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < WeaponAffectsBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            WeaponAffectsType value = (WeaponAffectsType)(-1);
            Marshal(token, &value, state);
            if (value != (WeaponAffectsType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < WeaponAffectsBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / WeaponAffectsBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % WeaponAffectsBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / WeaponAffectsBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % WeaponAffectsBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < WeaponAffectsBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, WeaponAffectsBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, WeaponAntiBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < WeaponAntiBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            WpnAntiT value = (WpnAntiT)(-1);
            Marshal(token, &value, state);
            if (value != (WpnAntiT)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < WeaponAntiBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / WeaponAntiBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % WeaponAntiBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / WeaponAntiBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % WeaponAntiBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < WeaponAntiBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, WeaponAntiBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, WeaponCollideBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < WeaponCollideBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            WeaponCollideType value = (WeaponCollideType)(-1);
            Marshal(token, &value, state);
            if (value != (WeaponCollideType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < WeaponCollideBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / WeaponCollideBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % WeaponCollideBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / WeaponCollideBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % WeaponCollideBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < WeaponCollideBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, WeaponCollideBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, WeaponFlagsBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < WeaponFlagsBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            WeaponFlagsType value = (WeaponFlagsType)(-1);
            Marshal(token, &value, state);
            if (value != (WeaponFlagsType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < WeaponFlagsBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / WeaponFlagsBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % WeaponFlagsBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / WeaponFlagsBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % WeaponFlagsBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < WeaponFlagsBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, WeaponFlagsBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(string text, WeaponSetBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < WeaponSetBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            WeaponSetType value = (WeaponSetType)(-1);
            Marshal(token, &value, state);
            if (value != (WeaponSetType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < WeaponSetBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / WeaponSetBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % WeaponSetBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / WeaponSetBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % WeaponSetBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < WeaponSetBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, WeaponSetBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }

    public static unsafe void Marshal(Value value, WeaponSetBitFlags** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(WeaponSetBitFlags), 1u);
        Marshal(value, *objT, state);
    }

    public static unsafe void Marshal(Node node, WeaponSetBitFlags** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetValue(), objT, state);
    }

    public static unsafe void Marshal(string text, WeaponSlotBitFlags* objT, Tracker state)
    {
        string[] tokens = text.Split(WhiteSpaces, System.StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
        {
            return;
        }
        for (int idy = 0; idy < tokens.Length; ++idy)
        {
            string token = tokens[idy];
            bool includeToken = true;
            if (token[0] == '+')
            {
                includeToken = true;
            }
            else if (token[0] == '-')
            {
                includeToken = false;
            }
            if (string.Equals(token, "ALL", System.StringComparison.Ordinal))
            {
                for (int idx = 0; idx < WeaponSlotBitFlags.NumSpans; ++idx)
                {
                    objT->Value[idx] = uint.MaxValue;
                }
                continue;
            }
            WeaponSlotType value = (WeaponSlotType)(-1);
            Marshal(token, &value, state);
            if (value != (WeaponSlotType)(-1))
            {
                uint uintValue = (uint)value;
                if (uintValue < WeaponSlotBitFlags.Count)
                {
                    if (includeToken)
                    {
                        objT->Value[uintValue / WeaponSlotBitFlags.BitsInSpan] |= (uint)(1 << (int)(uintValue % WeaponSlotBitFlags.BitsInSpan));
                    }
                    else
                    {
                        objT->Value[uintValue / WeaponSlotBitFlags.BitsInSpan] ^= (uint)(1 << (int)(uintValue % WeaponSlotBitFlags.BitsInSpan));
                    }
                }
            }
        }
        for (int idx = 0; idx < WeaponSlotBitFlags.NumSpans; ++idx)
        {
            state.InplaceEndianToPlatform(&objT->Value[idx]);
        }
    }

    public static unsafe void Marshal(Value value, WeaponSlotBitFlags* objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        Marshal(value.GetText(), objT, state);
    }
}
