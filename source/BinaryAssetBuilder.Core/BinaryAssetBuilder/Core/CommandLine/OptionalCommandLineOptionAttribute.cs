namespace BinaryAssetBuilder.Core.CommandLine
{
    public class OptionalCommandLineOptionAttribute : ACommandLineOptionAttribute
    {
        public string Alias { get; }

        public OptionalCommandLineOptionAttribute(string alias)
        {
            Alias = alias;
        }

        public OptionalCommandLineOptionAttribute(string alias, object minValue, object maxValue) : base(minValue, maxValue)
        {
            Alias = alias;
        }

        public OptionalCommandLineOptionAttribute(string alias, object[] validValueSet) : base(validValueSet)
        {
            Alias = alias;
        }
    }
}
