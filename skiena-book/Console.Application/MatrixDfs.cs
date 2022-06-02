using System;
namespace Hackerrank.matrix.dfs
{
    public class Result
    {

        /*
         * Complete the 'maxRegion' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY grid as parameter.
         */

        public static int maxRegion(List<List<int>> grid)
        {
            int n = grid.Count;
            rows = n;
            cols = grid[0].Count;
            region = 0;
            discovered = new bool[rows,cols];
            
            for(int u=0; u < rows; u++)
            {
                for(int v =0; v < cols; v++)
                {
                   region = Math.Max(region,  CountRegion(grid, u, v));
                }
            }

            return region;
        }

        private static int region;

        private static int rows;

        private static int cols;

        private static bool[,] discovered = new bool[0,0];

        private static int CountRegion(List<List<int>> grid,int x ,int y)
        {

            if (!CheckCell(grid, x, y)) return 0;

            if (discovered[x, y]) return 0;

            int aboveRow = x - 1;
            int beforeCol = y - 1;
            int belowRow = x + 1;
            int afterCol = y + 1;

            discovered[x,y] = true;

            int regionCount = 1 +
            CountRegion(grid, aboveRow, beforeCol) +
            CountRegion(grid, aboveRow, y) +
            CountRegion(grid, aboveRow, afterCol) +
            CountRegion(grid, x, beforeCol) +
            CountRegion(grid, x, afterCol) +
            CountRegion(grid, belowRow, beforeCol) +
            CountRegion(grid, belowRow, y) +
            CountRegion(grid, belowRow, afterCol);

            return regionCount;
        }


        
        private static bool CheckCell(List<List<int>> grid, int x, int y)
        {
            return x >= 0 && y >= 0 && x < rows && y < cols && grid[x][y] == 1;
        }

    }

}

