using System;
namespace LeetCodeProblems;

public class AllPathStartToEnd
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {

        return Path(0, graph.Length - 1, graph).ToList();


    }

    public IEnumerable<IList<int>> Path(int start, int end, int[][] graph)
    {
        for (int node = 0; node < graph[start].Length; node++)
        {

            if (graph[start][node] == end)
            {

                yield return new List<int>() { start, end };
            }
            else
            {
                var interResult = Path(graph[start][node], end, graph);
                if (interResult.Any())
                {
                    foreach (var el in interResult)
                    {
                        var temp = new List<int>() { start };
                        temp.AddRange(el);
                        yield return temp;
                    }
                    
                }
            }
        }
    }
}

