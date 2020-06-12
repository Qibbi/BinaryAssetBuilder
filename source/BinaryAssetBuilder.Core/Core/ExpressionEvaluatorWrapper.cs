using System.Reflection;

namespace BinaryAssetBuilder.Core
{
    public class ExpressionEvaluatorWrapper
    {
        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(ExpressionEvaluatorWrapper), "Provides expression evaluation functionality");
        private static Assembly _library = null;

        public static void LoadAssembly()
        {
            try
            {
                _library = Assembly.Load("BinaryAssetBuilder.ExpressionEval");
                _library.GetType("BinaryAssetBuilder.ExpressionEval.ExpressionEvaluator");
            }
            catch
            {
                _library = null;
                _tracer.TraceError("Could not load ExpressionEvaluator from BinaryAssetBuilder.ExpressionEval.dll. Expressions are disabled.");
            }
        }

        public static IExpressionEvaluator GetEvaluator(AssetDeclarationDocument document)
        {
            try
            {
                if (_library != null)
                {
                    return (IExpressionEvaluator)_library.CreateInstance("BinaryAssetBuilder.ExpressionEval.ExpressionEvaluator",
                                                                         false,
                                                                         BindingFlags.CreateInstance,
                                                                         null,
                                                                         new object[] { document },
                                                                         null,
                                                                         null);
                }
            }
            catch
            {
                _tracer.TraceError("Could not load ExpressionEvaluator from BinaryAssetBuilder.ExpressionEval.dll. Expressions are disabled.");
            }
            return null;
        }
    }
}