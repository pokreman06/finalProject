namespace finalProject;

public class NewGame
{
    private int maxX { get; init; } = 5;
    private int maxY { get; init; } = 5;
    public (Player person, int lives, int x, int y)[] players { get; set; }
    public bool Move(Player PlayerMoved, (int x, int y) newlocation)
    {
        int playerNum = findPlayer(PlayerMoved);
        if (0 < newlocation.x && 0 < newlocation.y && maxX > newlocation.x && maxY > newlocation.x)
        {
            if ((newlocation.x + newlocation.y - players[playerNum].x - players[playerNum].y) < players[playerNum].lives)
            {
                players[playerNum].x = newlocation.x;
                players[playerNum].x = newlocation.y;
                return true;
            }
        }
        return false;
    }
    public bool fire(Player player, (int x, int y) newlocation)
    {
        int playerNum = findPlayer(player);
        if (0 < newlocation.x && 0 < newlocation.y && maxX > newlocation.x && maxY > newlocation.x)
        {
            if (newlocation.x == players[playerNum].x && newlocation.y == players[playerNum].y)
            {
                players[playerNum].lives -= 2;
                if (won(playerNum))
                    players[1-playerNum].person.HasWon(1);
                return true;
            }
            if (players[playerNum].x - 1 < newlocation.x && players[playerNum].y - 1 < newlocation.y && players[playerNum].x + 1 > newlocation.x && players[playerNum].y + 1 > newlocation.x)
            {
                players[playerNum].lives -= 1;
                if (won(playerNum))
                    players[1-playerNum].person.HasWon(1);
                return true;
            }
        }

        return false;
    }
    public bool won(int num)
    {
        if (players[num].lives == 0)
            return true;
        return false;
    }
    public int findPlayer(Player person)
    {
        for (var x = 0; x < 2; x++)
        {
            if (players[x].person == person)
            {
                return x;
            }
        }
        throw new Exception("Player not found");
    }
}