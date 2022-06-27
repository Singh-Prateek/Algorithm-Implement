namespace skiena.book.combinationsearch;

internal struct Cell
{
    internal int Cost;
    internal Options Parent;
}

internal enum Options : int
{
    NoParent = -1,
    Match,
    Insert,
    Delete,
}

public class StringCompare
{
    int maxLen = 0;
    Cell[,] dpTable = new Cell[0, 0];

    public int AlgoRun(string s, string t)
    {

        var (pattern , cost) = Compare(" " + s, " " + t);

        Print(dpTable);
        Console.WriteLine(pattern);

        return cost;

    }

    public int AlgoRun()
    {
        return AlgoRun("thou shalt", "you should");

    }

    private (string, int) Compare(ReadOnlySpan<char> s, ReadOnlySpan<char> t)
    {
        this.maxLen = Math.Max(s.Length, t.Length);

        this.dpTable = new Cell[maxLen + 1, maxLen + 1];

        int[] opts = new int[3];

        for (int i = 0; i <= maxLen; i++)
        {
            RowInit(i, dpTable);
            ColumnInit(i, dpTable);
        }

        for (int i = 1; i < s.Length; i++)
        {
            for (int j = 1; j < t.Length; j++)
            {
                opts[(int)Options.Match] = dpTable[i - 1, j - 1].Cost + Match(s[i], t[j]);
                opts[(int)Options.Insert] = dpTable[i, j - 1].Cost + Indel(s[i]);
                opts[(int)Options.Delete] = dpTable[i - 1, j].Cost + Indel(t[j]);

                dpTable[i, j].Cost = opts[(int)Options.Match];
                dpTable[i, j].Parent = Options.Match;

                for (int k = (int)Options.Insert; k <= (int)Options.Delete; k++)
                {
                    if (opts[k] < dpTable[i, j].Cost)
                    {
                        dpTable[i, j].Cost = opts[k];
                        dpTable[i, j].Parent = k == 1 ? Options.Insert : Options.Delete;
                    }
                }

            }
        }

        var (x, y) = GoalCell(s, t);
        var pattern = ReconstructPath(s, t, x, y, dpTable);

        return (pattern, dpTable[x, y].Cost);
    }

    private (int, int) GoalCell(ReadOnlySpan<char> s, ReadOnlySpan<char> t)
    {
        return (s.Length - 1, t.Length - 1);
    }

    private void Print(Cell[,] m)
    {
        for (int i = 0; i <= maxLen; i++)
        {
            for (int j = 0; j <= maxLen; j++)
            {
                var val = m[i, j];
                Console.Write("{0},{1}  \t", val.Cost, val.Parent.ToString()[0]);
            }
            Console.WriteLine("\n");
        }
    }

    private static void RowInit(int i, Cell[,] m)
    {
        m[i, 0].Cost = i;

        m[i, 0].Parent = i > 0 ? Options.Insert : Options.NoParent;

    }

    private static void ColumnInit(int i, Cell[,] m)
    {
        m[0, i].Cost = i;

        m[0, i].Parent = i > 0 ? Options.Delete : Options.NoParent;
    }

    private static int Match(char c, char d) => c == d ? 0 : 1;

    private static int Indel(char c) => 1;

    private static string ReconstructPath(
        ReadOnlySpan<char> s,
        ReadOnlySpan<char> t,
        int i,
        int j,
        Cell[,] m
        )
    {
        string path;
        char options;
        string result = string.Empty;

        if (i < 0 || j < 0) return result;

        switch (m[i, j].Parent)
        {

            case Options.Match:

                path = ReconstructPath(s, t, i - 1, j - 1, m);

                options = MatchOut(s, t, i, j);

                result = path + options;

                break;

            case Options.Insert:

                path = ReconstructPath(s, t, i, j - 1, m);

                options = InsertOut(t, j);

                result = path + options;

                break;

            case Options.Delete:

                path = ReconstructPath(s, t, i - 1, j, m);

                options = DeleteOut(s, i);

                result = path + options;

                break;
        }

        return result;

    }

    private static char DeleteOut(ReadOnlySpan<char> s, int i)
    {
        return 'D';
    }

    private static char InsertOut(ReadOnlySpan<char> t, int j)
    {
        return 'I';
    }

    private static Char MatchOut(ReadOnlySpan<char> s, ReadOnlySpan<char> t, int i, int j)
    {
        return s[i] == t[j] ? 'M' : 'S';
    }
}