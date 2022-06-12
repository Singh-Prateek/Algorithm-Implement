﻿using System.Collections.Generic;
using System.Linq;
using skiena.book.graph;
using skiena.book.prim;
using Xunit;
using static Hackerrank.matrix.dfs.Result;


namespace AlgorithmsInput
{
    public class PrimsTests
    {
        [Fact]
        public void Input_0_Test()
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

            var actual = p.PrimsAlgo(g, 7);

            Assert.Equal(23, actual);

        }

    }
}
