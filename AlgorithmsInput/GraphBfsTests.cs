using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlgorithmsInput;

public class GraphBfsTests
{
    [Theory]
    [MemberData(nameof(BfsInputs))]
    public void Bfs(int n, int m, List<List<int>> edges, int s, List<int> expected)
    {
        var actual = (new Hackerrank.Bfs.Result()).bfs(n, m, edges, s);

        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> BfsInputs => new List<object[]>()
    {
        new object[] { 4 ,2, ConvertToEdge("1 2,1 3"),1, ConvertToList( "6 6 -1")},
        new object[] { 3 ,1, ConvertToEdge("2 3"),2, ConvertToList("-1 6") }

    };

    public static List<List<int>> ConvertToEdge(string input)
    {
        return input.Split(",").Select(s => s.Split(" ").Select(int.Parse).ToList()).ToList();

    }

    public static List<int> ConvertToList(string input)
    {
        return input.Split(" ").Select(int.Parse).ToList();

    }

}
