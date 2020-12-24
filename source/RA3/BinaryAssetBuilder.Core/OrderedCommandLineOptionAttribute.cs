namespace BinaryAssetBuilder
{
    public class OrderedCommandLineOptionAttribute : ACommandLineOptionAttribute
    {
        public int Ordinal { get; }

        public OrderedCommandLineOptionAttribute(int ordinal)
        {
            Ordinal = ordinal;
        }

        public OrderedCommandLineOptionAttribute(int ordinal, object minValue, object maxValue) : base(minValue, maxValue)
        {
            Ordinal = ordinal;
        }

        public OrderedCommandLineOptionAttribute(int ordinal, object[] validValueSet) : base(validValueSet)
        {
            Ordinal = ordinal;
        }
    }
}
