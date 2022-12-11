namespace finalProject.test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void testPoint()
    {
        Point point = new Point(){X=2,Y=3};
        Assert.AreEqual("(2, 3)", point.ToString());
    }
    [Test]
    public void NewGame()
    {
        var player1 = new Player();
        var player2 = new Player();
        var game = new NewGame(new Player[] { player1, player2 });
        game.Move((3, 2));
        Assert.AreEqual(new Point() { X = 3, Y = 2 }, game.GetPlayerlocation(0));
        game.changePlayer();
        Assert.IsTrue(!game.Move((5, 1)));
        Assert.IsTrue(game.Move((3, 2)));
        game.fire(newlocation: (3, 2));
        Assert.AreEqual(3, game.Score[player2]);
        game.Move((2,3));
        game.fire(newlocation: (3, 4));
        Assert.AreEqual(4, game.Score[player1]);
    }
    [Test]
    public void testMovePoint()
    {
        Point xy = new Point();
        xy.move(3, 4);
        Assert.AreEqual((3, 4), (xy.X, xy.Y));
    }
    [Test]
    public void PickUpSticks()
    {
        var p1 = new Player();
        var p2 = new Player();
        var game = new PickUpSticks(new Player[] { p1, p2 });
        game.Iterate(3);
        Assert.AreEqual(7, game.sticks);
        Assert.AreEqual(p2, game.Players[game.currentPlayer]);
    }
    [Test]
    public void testnum()
    {
        var p1 = new Player();
        var p2 = new Player();
        var game = new Yahtzee(new Player[] { p1, p2 });
        game.numberValue(3, new int[] { 3, 3, 3, 2, 3 });
        Assert.AreEqual(12, game.Score[p1]["3"]);
    }
    [Test]
    public void testlargestraight()
    {
        var p1 = new Player();
        var p2 = new Player();
        var game = new Yahtzee(new Player[] { p1, p2 });
        game.LargeStraight(new int[] { 1, 3, 4, 5, 2 });
        Assert.AreEqual(40, game.Score[p1]["large"]);
    }
    [Test]
    public void testsmallstraight()
    {
        var p1 = new Player();
        var p2 = new Player();
        var game = new Yahtzee(new Player[] { p1, p2 });
        game.SmallStraight(new int[] { 2, 3, 4, 1, 6 });
        Assert.AreEqual(30, game.Score[p1]["small"]);
    }
    [Test]
    public void testfsmallstraight()
    {
        var p1 = new Player();
        var p2 = new Player();
        var game = new Yahtzee(new Player[] { p1, p2 });
        game.SmallStraight(new int[] { 2, 3, 4, 1, 3 });
        Assert.AreEqual(30, game.Score[p1]["small"]);
    }
    [Test]
    public void testfsmallstraight2()
    {
        var p1 = new Player();
        var p2 = new Player();
        var game = new Yahtzee(new Player[] { p1, p2 });
        game.SmallStraight(new int[] { 2, 3, 4, 5, 3 });
        Assert.AreEqual(30, game.Score[p1]["small"]);
    }
    [Test]
    public void testfullhouse()
    {
        var p1 = new Player();
        var p2 = new Player();
        var game = new Yahtzee(new Player[] { p1, p2 });
        game.fullHouse(new int[] { 2, 2, 3, 2, 3 });
        Assert.AreEqual(25, game.Score[p1]["full"]);
    }
    [Test]
    public void testYahtzie()
    {
        var p1 = new Player();
        var p2 = new Player();
        var game = new Yahtzee(new Player[] { p1, p2 });
        game.yahtzee(new int[] { 2, 2, 2, 2, 2 });
        Assert.AreEqual(50, game.Score[p1]["yahtzee"]);
    }
    [Test]
    public void testYahtzie2()
    {
        var p1 = new Player();
        var p2 = new Player();
        var game = new Yahtzee(new Player[] { p1, p2 });
        game.yahtzee(new int[] { 2, 2, 2, 2, 2 });
        game.yahtzee(new int[] { 2, 2, 2, 2, 2 }, location: "2");
        Assert.AreEqual(150, game.Score[p1]["yahtzee"]);
        Assert.AreEqual(10, game.Score[p1]["2"]);
    }
    [Test]
    public void test3of()
    {
        var p1 = new Player();
        var p2 = new Player();
        var game = new Yahtzee(new Player[] { p1, p2 });
        Assert.IsTrue(game.fourOf(3, new int[] { 2, 2, 4, 2, 1 }));
        System.Console.WriteLine(2);
    }

}