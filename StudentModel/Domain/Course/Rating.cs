using System.Numerics;

namespace TestApp;

public class Rating
{
    private int _value;

    public int Value
    {
        get => _value;
        set => _value = Math.Min(Math.Max(value, 0), 100);
    }
}