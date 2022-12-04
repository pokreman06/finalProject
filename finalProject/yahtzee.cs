namespace finalProject;

public class Yahtzee
{
    public Dice[] Dice{get; set;} =new  Dice[]{new Dice(), new Dice(), new Dice(), new Dice(), new Dice()};
    public Player[] Players;
    public int[] scores{get; set;} = new int[14];
    public void DiceReroll(int[] rerolled)
    {
        foreach(int x in rerolled)
        {
            Dice[x].reroll();
        }
    }
    

}