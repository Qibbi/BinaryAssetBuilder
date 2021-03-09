using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentAptMediator* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentAptMediator.AptGlobalLoadVarName), null), &objT->AptGlobalLoadVarName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentAptMediator.AptEventHandlerName), null), &objT->AptEventHandlerName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentAptMediator.AptFSCommandHandlerName), null), &objT->AptFSCommandHandlerName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentAptMediator.AptTokenDelimiters), null), &objT->AptTokenDelimiters, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentAptMediator.NewSkoolIndicator), null), &objT->NewSkoolIndicator, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentAptMediator.FunctionSeparator), null), &objT->FunctionSeparator, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentAptMediator.ValueSeparator), null), &objT->ValueSeparator, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentAptMediator.InputParameterSeparator), null), &objT->InputParameterSeparator, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentAptMediator.ParameterNameSeparator), null), &objT->ParameterNameSeparator, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentAptMediator.ParameterStartIndicator), null), &objT->ParameterStartIndicator, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentAptMediator.SubObjectSeparator), null), &objT->SubObjectSeparator, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentAptMediator.OutputParameterSeparator), null), &objT->OutputParameterSeparator, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}