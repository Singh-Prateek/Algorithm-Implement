using System;
using Xunit;

namespace AlgorithmsInput
{
    /// <summary>
    /// find a node whch is shortest path and has same colour as start.
    /// </summary>
    public class BfsShortestPairTests
    {
        [Fact]
        public void CaseOneTests()
        {
            Hackerrank.BfsShortestPair.ShortestColorNode shortPath = new ();
            var actual = shortPath.FindShortestPair(4, new int[] { 1, 1, 4 }, new int[] { 2, 3, 2 }, new long[] { 1, 2, 1, 1 }, 1);

            Assert.Equal(1, actual);
        }

        [Fact]
        public void CaseTwoTests()
        {
            Hackerrank.BfsShortestPair.ShortestColorNode shortPath = new ();
            var actual = shortPath.FindShortestPair(4, new int[] { 1, 1, 4 }, new int[] { 2, 3, 2 }, new long[] { 1, 2, 1, 4 }, 2);

            Assert.Equal(-1, actual);
        }

    }
}

