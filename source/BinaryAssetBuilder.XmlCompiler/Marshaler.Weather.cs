using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SnowType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SnowType.SnowTexture), null), &objT->SnowTexture, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.SnowFrequencyScaleX), "0.0533"), &objT->SnowFrequencyScaleX, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.SnowFrequencyScaleY), "0.0275"), &objT->SnowFrequencyScaleY, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.SnowAmplitude), "5.0"), &objT->SnowAmplitude, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.SnowPointSize), "1.0"), &objT->SnowPointSize, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.SnowMaxPointSize), "64.0"), &objT->SnowMaxPointSize, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.SnowMinPointSize), "0.0"), &objT->SnowMinPointSize, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.SnowQuadSize), "0.5"), &objT->SnowQuadSize, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.SnowBoxHeight), "200"), &objT->SnowBoxHeight, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.SnowSpacing), "50"), &objT->SnowSpacing, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.SnowSpeed), "100"), &objT->SnowSpeed, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.SnowPointSprites), "true"), &objT->SnowPointSprites, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.SnowEnabled), "false"), &objT->SnowEnabled, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.IsSnowing), "false"), &objT->IsSnowing, state);
        Marshal(node.GetAttributeValue(nameof(SnowType.NumberTiles), "4"), &objT->NumberTiles, state);
        Marshal(node.GetChildNode(nameof(SnowType.SnowXYSpeed), null), &objT->SnowXYSpeed, state);
    }

    public static unsafe void Marshal(Node node, SnowType** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(SnowType), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, RainType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RainType.RainTexture), null), &objT->RainTexture, state);
        Marshal(node.GetAttributeValue(nameof(RainType.IsRaining), "false"), &objT->IsRaining, state);
        Marshal(node.GetAttributeValue(nameof(RainType.NumRaindropsPerBox), "16000"), &objT->NumRaindropsPerBox, state);
        Marshal(node.GetAttributeValue(nameof(RainType.RainBoxWidth), "200"), &objT->RainBoxWidth, state);
        Marshal(node.GetAttributeValue(nameof(RainType.RainBoxLength), "200"), &objT->RainBoxLength, state);
        Marshal(node.GetAttributeValue(nameof(RainType.RainBoxHeight), "200"), &objT->RainBoxHeight, state);
        Marshal(node.GetAttributeValue(nameof(RainType.MinWidth), "0.5"), &objT->MinWidth, state);
        Marshal(node.GetAttributeValue(nameof(RainType.MaxWidth), "1.5"), &objT->MaxWidth, state);
        Marshal(node.GetAttributeValue(nameof(RainType.MinHeight), "5.0"), &objT->MinHeight, state);
        Marshal(node.GetAttributeValue(nameof(RainType.MaxHeight), "15.0"), &objT->MaxHeight, state);
        Marshal(node.GetAttributeValue(nameof(RainType.MinSpeed), "50.0"), &objT->MinSpeed, state);
        Marshal(node.GetAttributeValue(nameof(RainType.MaxSpeed), "150.0"), &objT->MaxSpeed, state);
        Marshal(node.GetAttributeValue(nameof(RainType.MinAlpha), "0.1"), &objT->MinAlpha, state);
        Marshal(node.GetAttributeValue(nameof(RainType.MaxAlpha), "0.5"), &objT->MaxAlpha, state);
        Marshal(node.GetAttributeValue(nameof(RainType.WindStrength), "1.0"), &objT->WindStrength, state);
    }

    public static unsafe void Marshal(Node node, RainType** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(RainType), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, LightningType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LightningType.LightningEnabled), "false"), &objT->LightningEnabled, state);
        Marshal(node.GetAttributeValue(nameof(LightningType.LightningDuration), "30"), &objT->LightningDuration, state);
        Marshal(node.GetAttributeValue(nameof(LightningType.LightningChance), "0.01"), &objT->LightningChance, state);
        Marshal(node.GetChildNode(nameof(LightningType.LightningFactor), null), &objT->LightningFactor, state);
    }

    public static unsafe void Marshal(Node node, LightningType** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(LightningType), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, SpellType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SpellType.SpellEnabled), "true"), &objT->SpellEnabled, state);
        Marshal(node.GetAttributeValue(nameof(SpellType.SpellDuration), "200"), &objT->SpellDuration, state);
    }

    public static unsafe void Marshal(Node node, SpellType** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(SpellType), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, RampType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(RampType.RampControl), null), &objT->RampControl, state);
        Marshal(node.GetChildNode(nameof(RampType.RampSpacing), null), &objT->RampSpacing, state);
        Marshal(node.GetChildNode(nameof(RampType.RampSpeed), null), &objT->RampSpeed, state);
    }

    public static unsafe void Marshal(Node node, RampType** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(RampType), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, CloudType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(CloudType.CloudTextureSize), null), &objT->CloudTextureSize, state);
        Marshal(node.GetChildNode(nameof(CloudType.CloudOffsetPerSecond), null), &objT->CloudOffsetPerSecond, state);
    }

    public static unsafe void Marshal(Node node, CloudType** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(CloudType), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, WeatherData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(WeatherData.id), null), &objT->id, state);
        Marshal(node.GetAttributeValue(nameof(WeatherData.HasLightning), null), &objT->HasLightning, state);
        Marshal(node.GetAttributeValue(nameof(WeatherData.Sound), null), &objT->Sound, state);
    }

    public static unsafe void Marshal(Node node, Weather* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(Weather.Snow), null), &objT->Snow, state);
        Marshal(node.GetChildNode(nameof(Weather.Rain), null), &objT->Rain, state);
        Marshal(node.GetChildNode(nameof(Weather.Lightning), null), &objT->Lightning, state);
        Marshal(node.GetChildNode(nameof(Weather.Spell), null), &objT->Spell, state);
        Marshal(node.GetChildNode(nameof(Weather.Ramp), null), &objT->Ramp, state);
        Marshal(node.GetChildNode(nameof(Weather.Cloud), null), &objT->Cloud, state);
        Marshal(node.GetChildNodes(nameof(Weather.WeatherData)), &objT->WeatherData, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}