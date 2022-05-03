namespace skiena.book;

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
    public List<EdgeNode>[] Edges => _edges;
    public int[] Degree => _degree;


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

            Console.WriteLine(string.Empty);
        }
    }

}

public class BreathFirstSearch
{
    int[] parent = Array.Empty<int>();
    int start = 0;

    public void Bfs(Graph g, int s)
    {
        int n = g.nVertices;
        start = s;

        bool[] processed = new bool[n + 1];
        bool[] discovered = new bool[n + 1];

        parent = new int[n + 1];
        Array.Fill(parent, -1);

        var q = new Queue<int>();
        q.Enqueue(s);
        discovered[s] = true;

        while (q.Count != 0)
        {
            var v = q.Dequeue();

            ProcessVertexEarly(v);

            var adjacentEdges = g.Edges[v];

            if (adjacentEdges != null)
            {
                foreach (var edge in adjacentEdges)
                {
                    var y = edge.y;

                    if (!processed[y] || g.directed)
                    {
                        ProcessEdge(v, y);
                    }

                    if (!discovered[y])
                    {
                        discovered[y] = true;
                        parent[y] = v;
                        q.Enqueue(y);
                    }
                }

                processed[v] = true;
                ProcessVertexLate(v);
            }

        }

        Logging(parent);

    }

    private static void Logging(int[] parent)
    {
        log("vertex", parent.Select((e, i) => i));
        log("parent", parent);

        static void log(string message, IEnumerable<int> args)
        {
            Console.WriteLine("{0}\t\t{1}", message, string.Join("\t", args.Skip(1)));
        }
    }

    private static void ProcessVertexLate(int v)
    {
        Console.WriteLine("late processed vertex: {0}", v);
    }

    private static void ProcessVertexEarly(int v)
    {
        Console.WriteLine("early processing vertex: {0}", v);
    }


    public void ProcessEdge(int x, int y)
    {
        Console.WriteLine($"\t\tprocess edge {x},{y}");
    }


    public void FindPath(int end)
    {
        if (start == end || end == -1)
        {
            Console.Write("\n{0}", start);
        }
        else
        {
            FindPath(parent[end]);
            Console.Write(" {0}", end);
        }
    }



}

public class DepthFirstSearch
{
    private bool[] discovered = Array.Empty<bool>();
    private bool[] processed = Array.Empty<bool>();
    private int[] parent = Array.Empty<int>();
    private int[] entryTime = Array.Empty<int>();
    private int[] exitTime = Array.Empty<int>();

    int time = 0;

    private void Initialize(int n)
    {
        discovered = new bool[n + 1];
        processed = new bool[n + 1];
        parent = new int[n + 1];
        entryTime = new int[n + 1];
        exitTime = new int[n + 1];
        Array.Fill(parent, -1);
        time = 0;

    }

    public void Dfs(Graph g, int s)
    {
        Initialize(g.nVertices);

        DfsRec(g, s);

        log("items", this.parent.Select((s, idx) => idx));
        log("parent", this.parent);
        log("timein", this.entryTime);
        log("timeout", this.exitTime);
        log("childs", this.entryTime.Zip(this.exitTime).Select(e => (e.Second - e.First) / 2));

        static void log(string message, IEnumerable<int> args)
        {
            Console.WriteLine("{0}\t\t{1}", message, string.Join("\t", args.Skip(1)));
        }
    }



    private void DfsRec(Graph g, int v)
    {
        discovered[v] = true;
        time++;
        entryTime[v] = time;
        ProcessVertexEarly(v);

        var edges = g.Edges[v];

        if (edges != null)
        {
            //edges.Sort((x, y) => x.y < y.y ? -1 : 1);

            foreach (var edge in edges)
            {
                int y = edge.y;
                if (!discovered[y])
                {
                    this.parent[y] = v;
                    ProcessEdge(v, y);
                    DfsRec(g, y);
                }
                else if ((!processed[y] && parent[v] != y) || g.directed)
                {
                    ProcessEdge(v, y);
                }
            }
        }

        //ProcessVertexLate(v);
        processed[v] = true;
        exitTime[v] = time;
        time++;

    }

    private static void ProcessVertexEarly(int v)
    {
        Console.WriteLine("\tearly vertex: {0}", v);
    }

    private static void ProcessVertexLate(int v)
    {
        Console.WriteLine("\t\t\tlate vertex: {0}", v);

    }

    private void ProcessEdge(int v, int y)
    {
        //Console.WriteLine("\tedge: {0},{1}", v, y);

        if (parent[y] == v)
        {
            //if(parent[v])
            Console.WriteLine("\t\tgraph edge {0},{1}", v, y);
        }

        if (!processed[y] && discovered[y])
        {
            Console.WriteLine("\t\tback edge {0},{1}", v, y);
        }

        if (processed[y] && entryTime[v] < entryTime[y])
        {
            Console.WriteLine("\t\tforward edge {0},{1}", v, y);
        }

        if (processed[y] && entryTime[v] > entryTime[y])
        {
            Console.WriteLine("\t\tcross edge {0},{1}", v, y);
        }

    }
}

