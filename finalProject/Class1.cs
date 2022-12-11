namespace finalProject;
public static class Sort
{
    public static long benchmark(Action method)
    {
        var start = DateTime.Now.Ticks;
        method();
        var end = DateTime.Now.Ticks;
        return end - start;
    }

    public static List<int> BubbleSort(Func<int, int, bool> sort, List<int> list)
    {

        bool notSorted = true;
        var returnList = new List<int> { };
        foreach (int x in list)
        {
            returnList.Add(x);
        }
        while (notSorted)
        {
            notSorted = false;
            for (int x = 0; x < returnList.Count; x++)
            {
                if (x != 0)
                {
                    if (sort(returnList[x - 1], returnList[x]))
                    {
                        var tempX = returnList[x - 1];
                        var tempY = returnList[x];
                        returnList[x - 1] = tempY;
                        returnList[x] = tempX;
                        notSorted = true;
                    }
                }
            }
        }
        return returnList;
    }
    public static bool isSorted(Func<int, int, bool> func, List<int> list)
    {
        bool wee = true;
        for (int x = 0; x < list.Count(); x++)
        {
            if (x != 0 && func(list[x - 1], list[x]))
                wee = false;
        }
        return wee;
    }
    public static List<int> recursiveMerge(Func<int, int, bool> func, List<int> list)
    {
        var list1 = new List<int> { };
        var list2 = new List<int> { };
        var newList = new List<int> { };
        for (int x = 0; x < list.Count(); x++)
        {
            if (x < list.Count() / 2)
                list1.Add(list[x]);
            else
                list2.Add(list[x]);
        }
        newList = merge(func, list1, list2);
        if (!(isSorted(func, newList)))
        {
            for (int x = 0; x < list.Count(); x++)
            {
                if (x < list.Count() / 2)
                    list1.Add(list[x]);
                else
                    list2.Add(list[x]);
            }
            newList = merge(func, recursiveMerge(func, list1), recursiveMerge(func, list2));

        }

        return newList;
    }
    public static List<int> merge(Func<int, int, bool> sort, List<int> list1, List<int> list2)
    {
        var finishedList = new List<int> { };
        while (!(list1.Count() == 0 && list2.Count() == 0))
        {
            if (list1.Count() == 0)
            {
                finishedList.Add(list2[0]);
                list2.RemoveAt(0);
            }
            else if (list2.Count() == 0)
            {
                finishedList.Add(list1[0]);
                list1.RemoveAt(0);
            }
            else if (sort(list2[0], list1[0]))
            {
                finishedList.Add(list1[0]);
                list1.RemoveAt(0);
            }
            else if (sort(list1[0], list2[0]))
            {
                finishedList.Add(list2[0]);
                list2.RemoveAt(0);
            }
        }
        return finishedList;
    }
}
