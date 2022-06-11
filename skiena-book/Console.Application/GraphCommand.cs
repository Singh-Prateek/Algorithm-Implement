namespace skiena.book.graph;

public static class GraphCommand
{
    public static Graph Create(string[] inputs, int verticsCount, bool isDirected = false)
    {
        var graph = new Graph(verticsCount, isDirected);
        

        foreach (string input in inputs)
        {
            int[] inputArray = input.Split(" ").Select(Int32.Parse).ToArray();

            graph.AddEdge(inputArray[0], inputArray[1], inputArray[2]);

        }

        return graph;
    }
}


