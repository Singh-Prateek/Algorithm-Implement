using System;
namespace Hackerrank.machine.MST;

public class UnionFind
{
    public int[] p;
    public int[] size;
    public int n;

    public bool[] hasMachineInSet;

    public UnionFind(int verticesCount)
    {
        n = verticesCount;
        p = new int[n];
        size = new int[n];
        hasMachineInSet = new bool[n];

        for (int i = 0; i < n; i++)
        {
            //make a node as single node subtree
            p[i] = i;
            size[i] = 1;
        }
    }

}
public class MachineNode
{

    public static IEnumerable<List<int>> ReadInput(string[] input)
    {
        foreach (var row in input)
        {

            string tempRow = row.TrimEnd();

            if (tempRow.StartsWith('a')) continue;

            yield return tempRow
                    .Split(' ')
                    .ToList()
                    .Select(roadsTemp => Convert.ToInt32(roadsTemp)).ToList();
        }
    }

    public static int minTime(List<List<int>> roads, List<int> machines, int n)
    {
        UnionFind s = new UnionFind(n);

        bool[] machineCity = new bool[n];

        int timeToBreakCity = 0;
        int w = 0;

        for (int i = 0; i < machines.Count; i++)
        {
            s.hasMachineInSet[machines[i]] = true;
        }

        //as we want to remove smallest edge from machine city.
        foreach (var e in roads.OrderByDescending(r => r[2]))
        {
            w += e[2];

            if (!SameComponent(s, e[0], e[1]))
            {

                if (!JoinSets(s, e[0], e[1]))
                {
                    timeToBreakCity += e[2];
                }
            }
        }

        return timeToBreakCity;
    }

    public static bool SameComponent(UnionFind s, int s1, int s2)
    {
        return Find(s, s1) == Find(s, s2);
    }

    public static int Find(UnionFind s, int x)
    {

        if (s.p[x] == x) return x;

        return Find(s, s.p[x]);
    }

    public static bool JoinSets(UnionFind s, int s1, int s2)
    {

        int r1 = Find(s, s1);
        int r2 = Find(s, s2);

        if (s.hasMachineInSet[r1] && s.hasMachineInSet[r2]) return false;

        if (r2 == r1) return true;

        if (s.size[r1] >= s.size[r2])
        {
            s.size[r1] += s.size[r2];
            s.p[r2] = r1;
            s.hasMachineInSet[r1] = s.hasMachineInSet[r1] || s.hasMachineInSet[r2];
        }
        else
        {
            s.size[r2] += s.size[r1];
            s.p[r1] = r2;
            s.hasMachineInSet[r2] = s.hasMachineInSet[r1] || s.hasMachineInSet[r2];
        }

        return true;

    }

}

