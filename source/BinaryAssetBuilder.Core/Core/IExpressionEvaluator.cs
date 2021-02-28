namespace BinaryAssetBuilder.Core
{
    public interface IExpressionEvaluator
    {
        void EvaluateDefinition(Definition definition);

        string Evaluate(string expression);
    }
}