namespace finalProject;
public class Dice
{
    public int value {get; set;}
    Random rand = new Random();

    public Dice()
    {
        value = rand.Next(1, 7);
    }
    public void reroll()
    {
        value = rand.Next(1, 7);
    }
    

}
