namespace skiena.book.combinationsearch;

internal class BinomialCoefficent
{

    internal static long Coeffiecent(int n, int k)
    {
        long[,] b = new long[n + 1, n + 1];

        for (int i = 0; i <= n; i++)
        {
            b[i, 0] = 1;
            b[i, i] = 1;
        }

        for (int i = 2; i <= n; i++)
        {
            for (int j = 1; j < i; j++)
            {
                b[i, j] = b[i - 1, j - 1] + b[i - 1, j];
            }
        }

        return b[n, k];

    }
}