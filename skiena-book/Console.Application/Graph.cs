namespace skiena.book.graph;

public class Graph
{
    private readonly List<EdgeNode>[] _edgeNodes;
    private IReadOnlyList<List<EdgeNode>>? edgeNodes;
    private readonly int[] _degree = Array.Empty<int>();
    private int _edgeCount = 0;
    public IReadOnlyList<List<EdgeNode>> EdgeNodes => this.GetEdgeNode();
    public IReadOnlyList<int> Degree => _degree.ToList().AsReadOnly();
    public int VerticesCount { get; init; }
    public int EdgesCount => _edgeCount;
    public bool Directed { get; init; }

    public Graph(int verticesCount, bool directed)
    {
        VerticesCount = verticesCount;
        Directed = directed;
        _degree = new int[verticesCount + 1];
        _edgeNodes = new List<EdgeNode>[verticesCount + 1];
    }


    public void AddEdge(int x, int y, int weight, bool directed = false)
    {
        if (_edgeNodes[x] == null)
        {
            _edgeNodes[x] = new List<EdgeNode>();
        }

        if (!_edgeNodes[x].Any(n => n.Y == y))
        {
            _edgeNodes[x].Add(new EdgeNode() { Y = y, Weight = weight });
        }

        _degree[x]++;

        if (!directed)
        {
            AddEdge(y, x, weight, true);
        }
        else
        {
            this._edgeCount++;
        }

        edgeNodes = null;
    }

    private IReadOnlyList<List<EdgeNode>> GetEdgeNode()
    {
        if (edgeNodes == null)
        {
            edgeNodes = _edgeNodes.ToList().AsReadOnly();
        }

        return edgeNodes;
    }

}


