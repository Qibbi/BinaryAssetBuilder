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
}
