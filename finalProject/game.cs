namespace finalProject;
public class Game<T> // REQUIREMENT #2 and #10 a class and generic data type defenition
{
    public Dictionary<Player, T> Score { get; set; } = new Dictionary<Player, T>();
    public Player[] Players { get; init; } // REQUIREMENT #15 this line has an array and the above line has a dictionary
    public int currentPlayer { get; set; } = 0;
    public bool isOver { get; set; } = false;
    public Game(Player[] players, T? initial)
    {
        Players = players;
        if (initial != null)
        {
            foreach (Player x in Players)
            {
                Score.Add(x, initial);
            }
        }


    }
    public virtual void IsOver()
    {
        isOver = true;
        Players[currentPlayer].HasWon(1);
    }
    public void changePlayer()
    {
        if (currentPlayer == 0)
            currentPlayer = 1;
        else
            currentPlayer = 0;
    }
}