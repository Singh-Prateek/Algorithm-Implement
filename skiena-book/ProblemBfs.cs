using System;
namespace hackerrank
{

    public class Graph
    {

        public int vertices;
        public List<int>[] edges;

        public Graph(int n, List<List<int>> edges)
        {

            this.vertices = n;
            this.edges = new List<int>[n + 1];

            foreach (var edge in edges)
            {
                InsertEdge(edge[0], edge[1]);
            }
        }

        private void InsertEdge(int u, int v, bool directed = false)
        {

            if (edges[u] == null)
            {
                edges[u] = new List<int>() { v };
            }
            else
            {

                if (!edges[u].Exists(y => y == v))
                {
                    edges[u].Add(v);
                }
            }

            if (!directed)
            {
                InsertEdge(v, u, true);
            }
        }
    }

    public class Result
    {

        bool[] discovered = Array.Empty<bool>();
        bool[] processed = Array.Empty<bool>();
        
        int[] parent = Array.Empty<int>();
        int[] distance = Array.Empty<int>();
        Queue<int> q = new Queue<int>();

        const int EDGE_WEIGHT = 6;

        public List<int> bfs(int n, int m, List<List<int>> edges, int s)
        {

            discovered = new bool[n + 1];
            processed = new bool[n + 1];

            parent = new int[n + 1];
            Array.Fill(parent, -1);
            distance = new int[n + 1];
            Array.Fill(distance, -1);

            var graph = new Graph(n, edges);

            this.q = new Queue<int>();
            q.Enqueue(s);
            distance[s] = 0;
            bfs_internal(graph, s);

            var output = new List<int>();

            for (int i = 1; i <= n; i++)
            {

                if (i == s) continue;

                output.Add(distance[i]);
            }

            return output;

        }

        private void bfs_internal(Graph g, int start)
        {

            while (q.Count != 0)
            {

                var x = q.Dequeue();
                //discovered[x] = true;

                var adjacentEdges = g.edges[x];

                if (adjacentEdges != null)
                {

                    foreach (var y in adjacentEdges)
                    {

                        if (!discovered[y])
                        {

                            discovered[y] = true;
                            parent[y] = x;
                            q.Enqueue(y);
                            if (y != start)
                            {
                                process_edge(x, y);
                            }
                        }

                    }
                }

                processed[x] = true;

            }
        }

        private void process_edge(int x, int y)
        {
            distance[y] = distance[x] + EDGE_WEIGHT;
        }
    }
}

