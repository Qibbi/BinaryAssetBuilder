using System.Reflection;
using BinaryAssetBuilder.Core.Diagnostics;
using BinaryAssetBuilder.Core.SageXml;

namespace BinaryAssetBuilder.Core
{
    public class ExpressionEvaluatorWrapper
    {
        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(ExpressionEvaluatorWrapper), "Provides expression evaluation functionality");
        private static Assembly _library;

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
                if (_library is not null)
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
