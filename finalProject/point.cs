namespace finalProject;

public struct Point
{
    public Point()
    {
        
    }
    public int X = 0;
    public int Y = 0;
    public void move(int x, int y)
    {
        X=x;
        Y=y;
    }
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}