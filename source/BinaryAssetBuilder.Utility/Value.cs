
public class Value
{
    private readonly string _value;

    public Value(string value)
    {
        _value = value;
    }

    public string GetText()
    {
        return _value;
    }
}
