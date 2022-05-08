using System;
using System.Linq;
namespace Hackerrank.BfsShortestPair;

class Graph
{
    public int vertices;
    public List<int>[] edges;
    public long[] colors;

    public Graph(int n, int[] froms, int[] tos, long[] colorsNodes)
    {
        this.vertices = n;
        this.edges = new List<int>[n + 1];
        this.colors = new long[n + 1];

        for (int i = 1; i <= n; i++)
        {
            this.colors[i] = colorsNodes[i - 1];
        }

        if (edges == null)
        {
            throw new ArgumentNullException($"{nameof(edges)} could not be null");
        }

        for (int i = 0; i < froms.Length; i++)
        {
            int x = froms[i];
            int y = tos[i];
            this.AddEdge(x, y);
            this.AddEdge(y, x);
        }
    }

    private void AddEdge(int x, int y)
    {
        if (this.edges[x] == null)
        {
            this.edges[x] = new List<int>() { y };
        }
        else
        {
            this.edges[x].Add(y);
        }
    }
}

public class ShortestColorNode
{
    public int FindShortestPair(int n, int[] froms, int[] tos, long[] colors, int start)
    {
        var g = new Graph(n, froms, tos, colors);

        IntializeSearch(n);

        long colorCode = g.colors[start];

        var q = new Queue<int>();
        q.Enqueue(start);

        Bfs(g, q, colorCode);

        return shortDistance;

    }

    private void Bfs(Graph g, Queue<int> q, long colorCode)
    {
        while (q.Count != 0 && shortDistance == -1)
        {
            var x = q.Dequeue();
            var adjacentEdges = g.edges[x];

            if (adjacentEdges != null)
            {
                foreach (var y in adjacentEdges)
                {

                    if (!discovered[y])
                    {
                        q.Enqueue(y);
                        discovered[y] = true;
                        parent[y] = x;
                        distance[y] = distance[x] + 1;
                    }

                    if (!processed[y] && colorCode == g.colors[y] )
                    {
                        shortDistance = distance[y];
                    }
                }
            }

            processed[x] = true;
        }
    }

    int shortDistance;

    bool[] processed = Array.Empty<bool>();
    bool[] discovered = Array.Empty<bool>();

    int[] distance = Array.Empty<int>();

    int[] parent = Array.Empty<int>();

    private void IntializeSearch(int n)
    {
        processed = new bool[n + 1];
        discovered = new bool[n + 1];
        parent = new int[n + 1];
        distance = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {

            parent[i] = -1;
            distance[i] = 0;
        }

        shortDistance = -1;
    }

}
