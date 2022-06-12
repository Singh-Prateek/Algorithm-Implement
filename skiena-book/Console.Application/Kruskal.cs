using skiena.book.graph;

namespace skiena.book.kruskal;

public struct EdgePair
{
    public int X;
    public int Y;
    public int Weight;
}

public class Kruskals
{
    public int AlgoRun(Graph g)
    {

        int i = 0;

        int weight = 0;

        UnionFind s = UnionFindInit(g.VerticesCount);

        List<EdgePair> e = g.EdgeNodes.Skip(1)
                                .SelectMany((s, idx) => s.Select(e => MapToEdgePair(idx, e)))
                                .OrderBy(e => e.Weight)
                                .ToList();
        e.Insert(0 , new EdgePair());

        for (i = 1; i <= g.VerticesCount; i++)
        {
            if (!SameComponent(s, e[i].X, e[i].Y))
            {
                System.Console.WriteLine($"edge {e[i].X}-{e[i].Y} in MST");
                weight += e[i].Weight;
                UnionSets(s, e[i].X, e[i].Y);
            }
        }

        return weight;
    }

    private static EdgePair MapToEdgePair(int idx, EdgeNode e) =>
    new EdgePair() { X = idx, Y = e.Y, Weight = e.Weight };

    private UnionFind UnionFindInit(int verticesCount)
    {
        UnionFind result = new UnionFind()
        {
            n = verticesCount,
            p = new int[verticesCount + 1],
            size = new int[verticesCount + 1]
        };

        for (int i = 1; i <= verticesCount; i++)
        {
            result.p[i] = i;
            result.size[i] = 1;
        }

        return result;
    }

    private int Find(UnionFind s, int node)
    {
        if (s.p[node] == node)
        {
            return node;
        }
        return Find(s, s.p[node]);
    }

    private void UnionSets(UnionFind s, int s1, int s2)
    {
        int root1 = this.Find(s, s1);
        int root2 = this.Find(s, s2);

        if (root1 == root2) return;

        if (s.size[root1] >= s.size[root2])
        {
            s.size[root1] += s.size[root2];
            s.p[root2] = root1;
        }
        else
        {
            s.size[root2] += s.size[root1];
            s.p[root1] = root2;
        }
    }

    public bool SameComponent(UnionFind s, int s1, int s2) => Find(s, s1) == Find(s, s2);
}