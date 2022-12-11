namespace finalProject;
public class Player
{
    string name {get; init;}
    int points =0;
    static int numberOfPlayers = 1;
    public Player()
    {
        name = "player" + numberOfPlayers;
        numberOfPlayers++;
    }
    public void HasWon(int upperage)
    {
        points += upperage;
    }
}