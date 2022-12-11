namespace finalProject;
public class Player : iperson, igamer
{
    public string name { get; init; }
    public int points { get; set; } = 0;
    static int numberOfPlayers { get; set; } = 1;
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