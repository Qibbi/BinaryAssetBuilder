using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AIBankBudgetListType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIBankBudgetListType.Account), null), &objT->Account, state);
        Marshal(node.GetAttributeValue(nameof(AIBankBudgetListType.Percent), null), &objT->Percent, state);
    }

    public static unsafe void Marshal(Node node, AIBankBudget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(AIBankBudget.AccountShare)), &objT->AccountShare, state);
    }
}
