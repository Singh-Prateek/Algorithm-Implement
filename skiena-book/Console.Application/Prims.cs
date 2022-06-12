using skiena.book.graph;

namespace skiena.book.prim;

public class Prims
{

    int[] distance = Array.Empty<int>();
    int[] parent = Array.Empty<int>();
    bool[] inTree = Array.Empty<bool>();

    public Prims(int verticesCount)
    {
        inTree = new bool[verticesCount + 1];
        distance = new int[verticesCount + 1];
        parent = new int[verticesCount + 1];

        this.Initilize(verticesCount);
    }


    public int PrimsAlgo(Graph g, int start)
    {
        int weight = 0;
        int dist = int.MaxValue;
        distance[start] = 0;
        int v = start;


        while (!inTree[v])
        {
            inTree[v] = true;

            if (v != start)
            {
                //Console.WriteLine($"edge {parent[v]}-{v} in tree.");
                weight += dist;
            }

            var edges = g.EdgeNodes[v];

            foreach (var p in edges)
            {
                int w = p.Y;

                if ((distance[w] > p.Weight) && !inTree[w])
                {
                    distance[w] = p.Weight;
                    parent[w] = v;
                }

            }

            dist = int.MaxValue;

            for (int i = 1; i <= g.VerticesCount; i++)
            {
                if (dist > distance[i] && !inTree[i])
                {
                    dist = distance[i];
                    v = i;
                }
            }
        }

        return weight;
    }


    public void Initilize(int verticesCount)
    {
        for (int i = 1; i <= verticesCount; i++)
        {
            inTree[i] = false;
            distance[i] = int.MaxValue;
            parent[i] = -1;
        }

    }
}

public class PrimsRunner
{
    public static int Run()
    {
        Graph g = GraphCommand.Create(new string[]
            {
                "1 3 12",
                "3 5 7",
                "5 6 2",
                "6 7 5",
                "7 2 7",
                "2 1 5",
                "1 4 7",
                "4 5 3",
                "4 7 4",
                "5 7 2",
                "2 4 9",
                "4 3 4"
            }, 7);

        Prims p = new(7);

        return p.PrimsAlgo(g, 7);
    }
}


