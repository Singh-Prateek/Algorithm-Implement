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
                Console.WriteLine($"edge {parent[v]}-{v}  in tree.");
                weight += dist;
            }

            var edges = g.EdgeNodes[v];

            foreach(var p in edges)
            {
                int w = p.Y;
                
                if ((distance[w] > p.Weight) && !inTree[w])
                {
                    distance[w] = p.Weight;
                    parent[w] = v;
                }

            }
            dist = int.MaxValue;

            for (int i = 1 ; i <= g.VerticesCount; i++)
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
        for(int i= 1; i <= verticesCount; i++)
        {
            inTree[i] = false;
            distance[i] = int.MaxValue;
            parent[i] = -1;
        }

    }
}


