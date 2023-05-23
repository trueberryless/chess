namespace Chess.Domain.ValueObjects;

public class Field
{
    public int X { get; set; }
    public int Y { get; set; }

    public Field()
    {
        
    }

    public Field(int x, int y)
    {
        X = x;
        Y = y;
    }
}