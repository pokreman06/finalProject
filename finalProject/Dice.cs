namespace finalProject;
public class Dice
{
    int value;
    Random rand = new Random();

    public Dice()
    {
        value = rand.Next(1, 6);
    }
    public void reroll()
    {
        value = rand.Next(1, 6);
    }
    

}
