namespace finalProject;

public struct Point // REQUIREMENT #4 a struct
{
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;
    public Point()
    {

    }
    public void move(int x, int y)
    {
        X = x;
        Y = y;
    }
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}