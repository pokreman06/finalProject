namespace finalProject;

public class NewGame : Game<int> // REQUIREMENT #3 and #6 as it is a class inheriting from game
{
    private int maxX { get; init; } = 5;
    private int maxY { get; init; } = 5; // REQUIREMENT #11 some properties
    public (Player player, Point point)[] locations { get; set; }
    public NewGame(Player[] players, int lives = 5) : base(players, lives)
    {
        locations = new (Player player, Point point)[players.Length];
        for (int x = 0; x < players.Length; x++)
        {
            locations[x].point = new Point();
        }

    }
    public Point GetPlayerlocation(int index)
    {
        return locations[index].point;
    }
    public bool Move((int x, int y) newlocation)
    {
        if (0 <= newlocation.x && 0 <= newlocation.y && maxX >= newlocation.x && maxY >= newlocation.x)
        {
            if ((newlocation.x + newlocation.y - locations[currentPlayer].point.X - locations[currentPlayer].point.Y) <= Score[Players[currentPlayer]])
            {
                locations[currentPlayer].point.X = newlocation.x;
                locations[currentPlayer].point.Y = newlocation.y;
                return true;
            }
        }
        return false;
    }

    public bool fire((int x, int y) newlocation, Player? player = null)
    {
        if (player == null)
            player = Players[currentPlayer];

        bool succeded = false;
        if (0 <= newlocation.x && 0 <= newlocation.y && maxX >= newlocation.x && maxY >= newlocation.x)
        {
            if (newlocation.x == locations[currentPlayer].point.X && newlocation.y == locations[currentPlayer].point.Y)
            {
                Score[player] -= 2;

            }
            else if ((locations[currentPlayer].point.X >= newlocation.x - 1 && locations[currentPlayer].point.X <= newlocation.x + 1) && (locations[currentPlayer].point.Y >= newlocation.y - 1 && locations[currentPlayer].point.Y <= newlocation.y + 1))
            {
                Score[player] -= 1;

            }
            succeded = true;
            changePlayer();
        }


        if (won())
            IsOver();
        return succeded;
    }
    public bool won()
    {
        if (Score[Players[1 - currentPlayer]] <= 0)
            return true;
        return false;
    }

}