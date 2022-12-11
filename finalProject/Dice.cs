namespace finalProject;
public class Dice // REQUIREMENT #1 a class
{
    public int value { get; set; }
    Random rand { get; set; } = new Random();

    public Dice()
    {
        value = rand.Next(1, 7);
    }
    public void reroll()
    {
        value = rand.Next(1, 7);
    }


}
