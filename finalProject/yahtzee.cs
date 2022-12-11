namespace finalProject;

public class Yahtzee : Game<Dictionary<string, int>>
{
    public Dice[] Dice { get; set; } = new Dice[] { new Dice(), new Dice(), new Dice(), new Dice(), new Dice() };
    public void DiceReroll(List<int> rerolled)
    {
        foreach (int x in rerolled)
        {
            Dice[x].reroll();
        }
    }
    public Yahtzee(Player[] players) : base(players, null)
    {
        foreach (Player x in players)
        {
            Score[x] = new Dictionary<string, int>();
        }
    }
    private int[] dice
    {
        get
        {

            var result = new int[5];
            for (int x = 0; x < 5; x++)
            {
                result[x] = Dice[x].value;
            }
            return result;
        }
    }
        public override string ToString()
        {
            string result = $@"Player1 {score(Players[0])}
";
            foreach(KeyValuePair<string, int> x in Score[Players[0]])
            {
                result += $@"{x.Key}: {x.Value}
";
            }
            result += $@"Player2 {score(Players[1])}
";
            foreach(KeyValuePair<string, int> x in Score[Players[1]])
            {
                result += $@"{x.Key}: {x.Value}
";
            }
            return result;
        }
    public bool Select(yatChoice input, yatChoice? secondary = null)
    {
        Func<bool>? dee = input switch
        {
            yatChoice.full => () => { return fullHouse(); }
            ,
            yatChoice.large => () => { return LargeStraight(); }
            ,
            yatChoice.small => () => { return SmallStraight(); }
            ,
            yatChoice.fourOf => () => { return fourOf(4); }
            ,
            yatChoice.threeof => () => { return fourOf(3); }
            ,
            yatChoice.one => () => { return numberValue(1); }
            ,
            yatChoice.two => () => { return numberValue(2); }
            ,
            yatChoice.three => () => { return numberValue(3); }
            ,
            yatChoice.four => () => { return numberValue(4); }
            ,
            yatChoice.five => () => { return numberValue(5); }
            ,
            yatChoice.six => () => { return numberValue(6); }
            ,
            yatChoice.chance => () => { return chance(); }
            ,
            _=>null,
            
        };
        bool isFull = input switch
        {
            yatChoice.full => Score[Players[currentPlayer]].ContainsKey("full"),
            yatChoice.large =>Score[Players[currentPlayer]].ContainsKey("large"),
            yatChoice.small => Score[Players[currentPlayer]].ContainsKey("small"),
            yatChoice.fourOf => Score[Players[currentPlayer]].ContainsKey("4of"),
            yatChoice.threeof => Score[Players[currentPlayer]].ContainsKey("3of"),
            yatChoice.one => Score[Players[currentPlayer]].ContainsKey("1"),
            yatChoice.two => Score[Players[currentPlayer]].ContainsKey("2"),
            yatChoice.three => Score[Players[currentPlayer]].ContainsKey("3"),
            yatChoice.four => Score[Players[currentPlayer]].ContainsKey("4"),
            yatChoice.five => Score[Players[currentPlayer]].ContainsKey("5"),
            yatChoice.six => Score[Players[currentPlayer]].ContainsKey("6"),
            yatChoice.chance => Score[Players[currentPlayer]].ContainsKey("chance"),
            yatChoice.yahtzee => Score[Players[currentPlayer]].ContainsKey("yahtzee"),
            _=>false
        };
        if (input == yatChoice.yahtzee)
            {
                (int? value, string? key) passthrough = secondary switch
                {
                    yatChoice.full => (25, "full")
            ,
            yatChoice.large => (40, "large")
            ,
            yatChoice.small => (30,"small")
            ,
            yatChoice.fourOf => (null, "4of")
            ,
            yatChoice.threeof => (null, "3of")
            ,
            yatChoice.one => (5, "1")
            ,
            yatChoice.two => (10, "2")
            ,
            yatChoice.three => (15, "3")
            ,
            yatChoice.four => (20, "4")
            ,
            yatChoice.five => (25, "5")
            ,
            yatChoice.six => (30, "6")
            ,
            yatChoice.chance => (null, "chance")
            ,
            _ => (null, null)
            
                };
                
            dee = () => {return yahtzee(maxValue: passthrough.value, location: passthrough.key);};
            }
            if(isFull)
            {
                throw new Exception("formerly used value invalid input");
            }
            else 
            {
                return dee();

            }
    }
    public static int countinlist<T>(T[] list,  T[] possible)
    {
        int gcount=0;

        foreach(T x in possible)
        {
            int count =0;
            foreach(T y in list)
            {
                if(x!.Equals(y))
                {
                    count++;
                }
            }
            if(count>=gcount)
            {
                gcount=count;
            }
        }
        return gcount;
    }
    public bool fourOf(int fot, int[]? testList = null)
    {
        if (testList == null)
            testList = dice;
        if(countinlist<int>((int[])testList, new int[]{1,2,3,4,5,6})>=fot)
        {
            Score[Players[currentPlayer]].Add(fot+" of", testList.Sum());
            return true;
        }
        else{
            Score[Players[currentPlayer]].Add(fot+" of", 0);
            return false;
        }
        

    }
    public bool LargeStraight(int[]? testList = null)
    {
        if (testList == null)
            testList = dice;
        var sortedlist = Sort.recursiveMerge((int x, int y) => x >= y, testList.ToList());
        bool test = true;
        for (int x = 1; x < 4; x++)
        {
            if (!((sortedlist[x] == sortedlist[x - 1] + 1) && (sortedlist[x] + 1 == sortedlist[x + 1])))
            {
                test = false;
            }
        }
        if (test)
            Score[Players[currentPlayer]].Add("large", 40);
        else
            Score[Players[currentPlayer]].Add("large", 0);
        return test;
    }
    public bool SmallStraight(int[]? testList = null)
    {
        if (testList == null)
            testList = dice;
        var sortedlist = Sort.recursiveMerge((int x, int y) => x >= y, testList.ToList());
        bool test1 = true;
        for(int x = 1; x<5; x++)
        {
            if(sortedlist[x]==sortedlist[x-1])
                sortedlist[x]=-1;
        }
        sortedlist = Sort.recursiveMerge((int x, int y) => x >= y, sortedlist);
        for (int x = 1; x < 3; x++)
        {
            if (!((sortedlist[x] == sortedlist[x - 1] + 1) && (sortedlist[x] + 1 == sortedlist[x + 1])))
            {
                test1 = false;
            }
        }
        bool test2 = true;
        for (int x = 2; x < 4; x++)
        {
            if (!((sortedlist[x] == sortedlist[x - 1] + 1) && (sortedlist[x] + 1 == sortedlist[x + 1])))
            {
                test2 = false;
            }
        }
        if (test1 || test2)
            Score[Players[currentPlayer]].Add("small", 30);
        else
            Score[Players[currentPlayer]].Add("small", 0);
        return (test1 || test2);
    }
    public bool numberValue(int number, int[]? testList = null)
    {
        var pscore = Score[Players[currentPlayer]];
        if (testList == null)
            testList = dice;

        if (number <= 6 && number > 0)
        {
            int result = 0;
            foreach (int value in testList)
            {
                if (value == number)
                {
                    result += number;
                }
            }
            if (!pscore.TryGetValue(number + "", out int x))
            {
                pscore.Add(number + "", result);
                return true;
            }
        }
        return false;
    }
    public bool fullHouse(int[]? testList = null)
    {
        var pscore = Score[Players[currentPlayer]];
        if (testList == null)
            testList = dice;
        int value1 = 0;
        int count1 = 0;
        int value2 = 0;
        int count2 = 0;
        foreach (int x in testList)
        {
            if (value1 == 0)
                value1 = x;
            else if ((value2 == 0) && (x != value1))
                value2 = x;
            if (x == value1)
            {
                count1++;
            }
            else if (x == value2)
            {
                count2++;
            }
        }
        if ((count1 == 2 && count2 == 3) || (count2 == 2 && count1 == 3))
        {
            Score[Players[currentPlayer]].Add("full", 25);
            return true;
        }
        else
        {
            Score[Players[currentPlayer]].Add("full", 0);
            return false;
        }
    }
    public bool yahtzee(int[]? testList = null, int? maxValue = null, string? location = null)
    {
        var pscore = Score[Players[currentPlayer]];
        if (testList == null)
            testList = dice;
        if (maxValue == null)
            maxValue = testList.Sum();

        var yat = (testList[0] == testList[1] && testList[1] == testList[2] && testList[2] == testList[3] && testList[3] == testList[4]);


        if (Score[Players[currentPlayer]].ContainsKey("yahtzee") && yat)
        {
            if (location == null)
            {
                throw new Exception("must include a passthrough value or yahtzee contains a value");
            }
            if (Score[Players[currentPlayer]]["yahtzee"] > 0)
            {
                Score[Players[currentPlayer]]["yahtzee"] += 100;
                if (!Score[Players[currentPlayer]].ContainsKey(location))
                    Score[Players[currentPlayer]].Add(location, (int)maxValue);
                else
                {
                    throw new Exception("This spot has already been used");
                }
            }
        }
        else if (yat)
        {
            Score[Players[currentPlayer]].Add("yahtzee", 50);
        }
        else
        {
            Score[Players[currentPlayer]].Add("yahtzee", 0);
        }

        return false;
    }
    public bool chance(int[]? testList = null)
    {
        if (testList == null)
            testList = dice;
        Score[Players[currentPlayer]].Add("chance", testList.Sum());
        return true;
    }

    public int score(Player selectedPlayer)
        {
            int total = 0;
            int bonus = 0;
            foreach (KeyValuePair<string, int> curr in Score[selectedPlayer])
            {
                if (int.TryParse(curr.Key, out int x))
                {
                    bonus += curr.Value;
                }
                if (bonus > 62)
                {
                    total += 35;
                }
                total += curr.Value;
            }
            return total;
        }
}