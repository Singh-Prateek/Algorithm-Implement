namespace skiena_book
{

    public class EdgeNode
    {
        public int y;
        public int weight;

        public EdgeNode(int v, int edgeWeigth)
        {
            this.y = v;
            this.weight = edgeWeigth;
        }

    }

    public class Graph
    {
        readonly List<EdgeNode>[] _edges;
        readonly int[] _degree;
        //public int[] _distance;
        public int nEdges;
        public int nVertices;
        public bool directed;
        //public int[] distance => _distance;
        public List<EdgeNode>[] edges => _edges;
        public int[] degree => _degree;


        public Graph(int n, List<List<int>> edges, bool directed)
        {
            nEdges = 0;
            nVertices = n;
            this.directed = directed;
            //this._distance = new int[n+1];
            _degree = new int[n + 1];
            _edges = new List<EdgeNode>[n + 1];

            foreach (var vtx in edges)
            {
                InsertEdge(vtx[0], vtx[1], directed);
            }

        }

        private void InsertEdge(int x, int y, bool directed)
        {
            List<EdgeNode> edges = _edges[x] ?? new List<EdgeNode>();

            EdgeNode node = new(y, 6);

            if (edges.Count == 0)
            {
                _edges[x] = new List<EdgeNode>() { node };
            }
            else
            {
                if (!_edges[x].Exists(n => n.y == node.y))
                {
                    _edges[x].Insert(0, node);
                }
            }

            _degree[x]++;


            if (!directed)
            {
                InsertEdge(y, x, true);
            }
            else
            {
                this.nEdges++;
            }

        }

        public void Print()
        {
            for (int i = 1; i <= nVertices; i++)
            {
                Console.Write($"{i}:");

                var p = _edges[i];

                if (p != null)
                {
                    foreach (var nxt in p)
                    {
                        Console.Write(nxt.y);
                    }
                }

                Console.WriteLine("");
            }
        }

    }

    public class BreathFirstSearch
    {
        int[] parent = new int[0];

        public int[] Parents => this.parent;

        public void Bfs(Graph g, int s)
        {
            int n = g.nVertices;

            bool[] processed = new bool[n + 1];
            bool[] discovered = new bool[n + 1];
            Array.Fill(parent, -1);
            //int[] distanceFromStart = new int[n + 1];
            parent = new int[n + 1];
            var q = new Queue<int>();
            q.Enqueue(s);
            discovered[s] = true;
            //distanceFromStart[s] = 0;

            while (q.Count != 0)
            {
                var v = q.Dequeue();

                ProcessVertexEarly(v);

                var p = g.edges[v];

                if (p != null)
                {
                    foreach (var nxt in p)
                    {
                        var y = nxt.y;

                        if (!processed[y] || g.directed)
                        {
                            ProcessEdge(v, y);
                        }

                        if (!discovered[y])
                        {
                            discovered[y] = true;
                            parent[y] = v;
                            q.Enqueue(y);
                            //if (y != s)
                            //{
                            //    distanceFromStart[y] = nxt.weight + distanceFromStart[v];
                            //}
                        }
                    }

                    processed[v] = true;
                    ProcessVertexLate(v);
                }

            }

            Logging(parent);

        }

        private void Logging(int[] parent)
        {
            Console.WriteLine("vertex\t\t {0}", string.Join("\t", parent.Select((e, i) => i.ToString()).Skip(1)));
            Console.WriteLine("parent\t\t {0}", string.Join("\t", parent.Skip(1)));
        }

        private void ProcessVertexLate(int v)
        {
            Console.WriteLine("processed vertex: {0}", v);
        }

        private void ProcessVertexEarly(int v)
        {
            Console.WriteLine("start processing vertex: {0}", v);
        }


        public void ProcessEdge(int x, int y)
        {
            Console.WriteLine($"process edge {x},{y}");
        }

        public void FindPath(int start, int end, int[] parent)
        {
            if(start == end || end == -1)
            {
                Console.Write("\n{0}",start);
            }
            else
            {
                FindPath(start, parent[end], parent);
                Console.Write(" {0}",end);
            }
        }



    }

    public class DepthFirstSearch
    {

        public void Dfs(int n, Graph g, int s)
        {

        }
    }

}
