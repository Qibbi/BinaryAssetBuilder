using System.Collections.Generic;

namespace BinaryAssetBuilder.Core.SageXml
{
    public class DefinitionSet : SortedDictionary<string, Definition>
    {
        public void AddDefintions(DefinitionSet definitions)
        {
            foreach (Definition definition in definitions.Values)
            {
                if (TryGetValue(definition.Name, out Definition other) && !definition.Document.SourcePath.Equals(other.Document.SourcePath, System.StringComparison.OrdinalIgnoreCase))
                {
                    throw new BinaryAssetBuilderException(ErrorCode.DuplicateDefine,
                                                          "Defintion {0} defined in {1} is already defined in {2}",
                                                          definition.Name,
                                                          definition.Document.SourcePath,
                                                          other.Document.SourcePath);
                }
                this[definition.Name] = definition;
            }
        }

        public string GetEvaluatedValue(string name)
        {
            return TryGetValue(name, out Definition result) ? result.EvaluatedValue : null;
        }
    }
}
