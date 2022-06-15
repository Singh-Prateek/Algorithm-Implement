namespace Hackerrank.ConnectedCities;
public class UnionFind
{
    public int[] p;
    public int[] size;
    public int n;
    public int libraryCost;
    public int roadCost;

    public UnionFind(int verticesCount, int libCost, int rCost)
    {
        n = verticesCount;
        p = new int[n + 1];
        size = new int[n + 1];
        libraryCost = libCost;
        roadCost = rCost;

        for (int i = 1; i <= n; i++)
        {
            //make a node as single node subtree
            p[i] = i;
            size[i] = 1;
        }
    }

}

class Result
{

    /*
     * Complete the 'roadsAndLibraries' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER c_lib
     *  3. INTEGER c_road
     *  4. 2D_INTEGER_ARRAY cities
     */

    public static long roadsAndLibraries(int n, int c_lib, int c_road, List<List<int>> cities)
    {
        UnionFind s = new UnionFind(n, c_lib, c_road);

        Console.WriteLine("new value {0}, l:{1}-r:{2}", n, s.libraryCost, s.roadCost);

        long result = Convert.ToInt64(n) * Convert.ToInt64(c_lib); //disjoin set, so all cities has library

        foreach (var e in cities)
        {
            if (JoinSets(s, e[0], e[1]))
            {
                Console.WriteLine($"{e[0]}-{e[1]}");
                result = result + (c_road - c_lib);
            }
        }

        return result;
    }

    private static bool SameComponent(UnionFind s, int s1, int s2)
    {
        return Find(s, s1) == Find(s, s2);
    }

    private static int Find(UnionFind s, int x)
    {

        if (s.p[x] == x) return x;

        return Find(s, s.p[x]);
    }

    private static bool JoinSets(UnionFind s, int s1, int s2)
    {
        if (s.roadCost >= s.libraryCost) return false;

        int r1 = Find(s, s1);
        int r2 = Find(s, s2);

        if (r2 == r1) return false;

        if (s.size[r1] >= s.size[r2])
        {
            s.size[r1] += s.size[r2];
            s.p[r2] = r1;
        }
        else
        {
            s.size[r2] += s.size[r1];
            s.p[r1] = r2;
        }

        return true;

    }

}
