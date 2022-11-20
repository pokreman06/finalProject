namespace finalProject;
public class PickUpSticks
{
    Player[] Players;
    int sticks;
    int currentPlayer=0;
    public PickUpSticks(Player[] players, int startingSticks)
    {
        Players = players;
        sticks = startingSticks;
    }
    public (bool valid, bool HasWon) Iterate(int sticksRemoved)
    {
        var hasWon = false;
        if(sticksRemoved>0&&sticksRemoved<=3&&sticksRemoved<=sticks)
        {
            sticks -= sticksRemoved;
            if(sticks == 0)
            {
                hasWon=true;
            }
            if(currentPlayer==0)
                currentPlayer=1;
            else
                currentPlayer=0;

            return (true, hasWon);
        }
        return (false, false);
    }
}