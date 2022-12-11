namespace finalProject;
public class PickUpSticks : Game<int>
{
    public int sticks;
    public PickUpSticks(Player[] players, int startingSticks = 10) : base(players, 0)
    {
        sticks = startingSticks;
    }
    public bool Iterate(int sticksRemoved)
    {
        if (sticksRemoved > 0 && sticksRemoved <= 3 && sticksRemoved <= sticks)
        {
            sticks -= sticksRemoved;
            Score[Players[currentPlayer]] += sticksRemoved;
            
            if (sticks <= 0)
            {
                IsOver();
            }
            changePlayer();
            return true;
        }
        return false;
    }
    public override void IsOver()
    {
        Players[currentPlayer].HasWon(Score.GetValueOrDefault(Players[currentPlayer]));
        isOver = true;
    }
}