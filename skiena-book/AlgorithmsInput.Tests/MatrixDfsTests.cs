using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Hackerrank.matrix.dfs.Result;


namespace AlgorithmsInput
{
	public class MatrixDfsTests
	{
        [Fact]
		public void Input_0_Test()
        {
            List<List<int>> grid = new()
            {
                AddRow("1 1 0 0"),
                AddRow("0 1 1 0"),
                AddRow("0 0 1 0"),
                AddRow("1 0 0 0")
            };

            var actual = maxRegion(grid);

            Assert.Equal(5, actual);
        }

        [Fact]
        public void Input_1_Test()
        {
            List<List<int>> grid = new()
            {
                AddRow("0 0 1 1"),
                AddRow("0 0 1 0"),
                AddRow("0 1 1 0"),
                AddRow("0 1 0 0"),
                AddRow("1 1 0 0")
            };

            var actual = maxRegion(grid);

            Assert.Equal(8, actual);
        }

        [Fact]
        public void Input_2_Test()
        {
            List<List<int>> grid = new()
            {
                AddRow("1 0 1 1 0"),
                AddRow("1 1 0 0 1"),
                AddRow("0 1 1 1 0"),
                AddRow("0 0 0 0 1"),
                AddRow("1 1 1 0 0")
            };

            var actual = maxRegion(grid);

            Assert.Equal(10, actual);
        }

        static List<int> AddRow(string row)
        {
            return row.Split(" ").Select(g => int.Parse(g)).ToList();
        }
    }
}

