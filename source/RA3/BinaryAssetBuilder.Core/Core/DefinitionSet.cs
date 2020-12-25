using System.Collections.Generic;

namespace BinaryAssetBuilder.Core
{
    public class DefinitionSet : Dictionary<string, Definition>
    {
        public void AddDefinitions(DefinitionSet definitions)
        {
            foreach (Definition definition in definitions.Values)
            {
                if (TryGetValue(definition.Name, out Definition nDefinition) && !nDefinition.Document.SourcePath.Equals(definition.Document.SourcePath))
                {
                    throw new BinaryAssetBuilderException(ErrorCode.DuplicateDefine,
                                                          "Definition {0} defined in {1} is already defined in {2}",
                                                          definition.Name,
                                                          definition.Document.SourcePath,
                                                          nDefinition.Document.SourcePath);
                }
                this[definition.Name] = definition;
            }
        }

        public string GetEvaluatedValue(string name)
        {
            return !TryGetValue(name, out Definition definition) ? null : definition.EvaluatedValue;
        }
    }
}