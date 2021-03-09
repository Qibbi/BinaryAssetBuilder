using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIBaseComponent** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0u;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x47E97895u:
                MarshalPolymorphicType<UIComponentAptJoypad, UIBaseComponent>(node, objT, state);
                break;
            case 0x1D333456u:
                MarshalPolymorphicType<UIComponentAptMediator, UIBaseComponent>(node, objT, state);
                break;
            case 0xC75F7722u:
                MarshalPolymorphicType<UIComponentSound, UIBaseComponent>(node, objT, state);
                break;
            case 0x07F893BAu:
                MarshalPolymorphicType<UIComponentMovie, UIBaseComponent>(node, objT, state);
                break;
            case 0xDB2E7631u:
                MarshalPolymorphicType<UIComponentSaveLoad, UIBaseComponent>(node, objT, state);
                break;
            case 0x52ED75B5u:
                MarshalPolymorphicType<UIComponentOptions, UIBaseComponent>(node, objT, state);
                break;
            case 0x64A14290u:
                MarshalPolymorphicType<UIComponentMessage, UIBaseComponent>(node, objT, state);
                break;
            case 0xA7EC7DF8u:
                MarshalPolymorphicType<UIComponentGameInfo, UIBaseComponent>(node, objT, state);
                break;
            case 0x30E30564u:
                MarshalPolymorphicType<UIComponentStats, UIBaseComponent>(node, objT, state);
                break;
            case 0x0AB24764u:
                MarshalPolymorphicType<UIComponentPlasmaInterface, UIBaseComponent>(node, objT, state);
                break;
            case 0x6A74768Eu:
                MarshalPolymorphicType<UIComponentCheats, UIBaseComponent>(node, objT, state);
                break;
            case 0xE6E3D312u:
                MarshalPolymorphicType<UIComponentGameViewJoypad, UIBaseComponent>(node, objT, state);
                break;
            case 0x0CE26AFDu:
                MarshalPolymorphicType<UIComponentObjectSelector, UIBaseComponent>(node, objT, state);
                break;
            case 0xCB0DC87Au:
                MarshalPolymorphicType<UIComponentCursor, UIBaseComponent>(node, objT, state);
                break;
            case 0x0A47CF24u:
                MarshalPolymorphicType<UIComponentObjectAction, UIBaseComponent>(node, objT, state);
                break;
            case 0x7A11709Fu:
                MarshalPolymorphicType<UIComponentCommandBar, UIBaseComponent>(node, objT, state);
                break;
            case 0x5D7CA8D3u:
                MarshalPolymorphicType<UIComponentInGameShowHide, UIBaseComponent>(node, objT, state);
                break;
            case 0x6A89163Eu:
                MarshalPolymorphicType<UIComponentMinimap, UIBaseComponent>(node, objT, state);
                break;
            case 0x8E91F5F2u:
                MarshalPolymorphicType<UIComponentPause, UIBaseComponent>(node, objT, state);
                break;
            case 0xFD81EDA6u:
                MarshalPolymorphicType<UIComponentObjectives, UIBaseComponent>(node, objT, state);
                break;
            case 0xEFC072E7u:
                MarshalPolymorphicType<UIComponentVictoryDefeat, UIBaseComponent>(node, objT, state);
                break;
            case 0xA39757A7u:
                MarshalPolymorphicType<UIComponentInGameText, UIBaseComponent>(node, objT, state);
                break;
            case 0x531EA49Bu:
                MarshalPolymorphicType<UIComponentFormation, UIBaseComponent>(node, objT, state);
                break;
            case 0x77951E5Bu:
                MarshalPolymorphicType<UIComponentInputBridge, UIBaseComponent>(node, objT, state);
                break;
            case 0x8BE972E8u:
                MarshalPolymorphicType<UIComponentSpecialPowers, UIBaseComponent>(node, objT, state);
                break;
            case 0xC9AE295Du:
                MarshalPolymorphicType<UIComponentShell, UIBaseComponent>(node, objT, state);
                break;
            case 0xEEA6A3F9u:
                MarshalPolymorphicType<UIComponentShellMultiplayer, UIBaseComponent>(node, objT, state);
                break;
            case 0x821059EDu:
                MarshalPolymorphicType<UIComponentLobby, UIBaseComponent>(node, objT, state);
                break;
            case 0x5F2742C4u:
                MarshalPolymorphicType<UIComponentCampaign, UIBaseComponent>(node, objT, state);
                break;
            case 0x670F301Au:
                MarshalPolymorphicType<UIComponentBootup, UIBaseComponent>(node, objT, state);
                break;
            case 0xD5DF8997u:
                MarshalPolymorphicType<UIComponentTicker, UIBaseComponent>(node, objT, state);
                break;
            case 0x08A7E6C6u:
                MarshalPolymorphicType<UIComponentMovieArchive, UIBaseComponent>(node, objT, state);
                break;
            default:
                MarshalUnknownPolymorphicType(node, objT, state);
                break;

        }
    }

    public static unsafe void Marshal(Node node, UIDynamicConfig* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIDynamicConfig.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(UIDynamicConfig.Type), null), &objT->Type, state);
        Marshal(node.GetChildNode(nameof(UIDynamicConfig.ComponentList), null), &objT->ComponentList, state);
    }

    public static unsafe void Marshal(Node node, UIConfigList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIConfigList.GDIBackground), null), &objT->GDIBackground, state);
        Marshal(node.GetAttributeValue(nameof(UIConfigList.NodBackground), null), &objT->NodBackground, state);
        Marshal(node.GetAttributeValue(nameof(UIConfigList.AlienBackground), null), &objT->AlienBackground, state);
        Marshal(node.GetChildNodes(nameof(UIConfigList.UIDynamicConfig)), &objT->UIDynamicConfig, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
