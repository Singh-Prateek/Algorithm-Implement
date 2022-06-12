using System.Collections.Generic;
using System.Linq;
using Hackerrank.machine.MST;
using skiena.book.graph;
using skiena.book.kruskal;
using Xunit;
using static Hackerrank.matrix.dfs.Result;


namespace AlgorithmsInput
{
    public class MachineNodesTests
    {
        [Fact]
        public void Input_0_Test()
        {

            var edges = MachineNode.ReadInput(new string[]{
                                                "1 0 5",
                                                "2 1 8",
                                                "2 4 5",
                                                "1 3 4"
                                                }).ToList();

            var actual = MachineNode.minTime(edges, new List<int>() { 2, 4, 0 }, 5);

            Assert.Equal(10, actual);

        }

        [Fact]
        public void Input_1_Test()
        {

            var edges = MachineNode.ReadInput(new string[]{
                                                "0 1 4",
                                                "1 2 3",
                                                "1 3 7",
                                                "0 4 2"
                                                }).ToList();

            var actual = MachineNode.minTime(edges, new List<int>() { 2, 3, 4 }, 5);

            Assert.Equal(5, actual);

        }

    }
}

