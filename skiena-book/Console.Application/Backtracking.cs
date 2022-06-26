using System;
using System.Linq;

namespace skiena.book.combinationsearch;

public class Backtracking
{
    public void AlgoRun()
    {
        Backtrack(new int[] { 0, 0, 0, 0 }, 0, 3);

    }

    private void Backtrack(int[] a, int k, int n)
    {
        int nc;
        int[] c;

        if (IsASolution(a, k, n))
        {
            ProcessSolution(a, k, n);
        }
        else
        {
            k += 1;
            c = ConstructCandidates(a, k);
            nc = c.Length;

            for (int i = 0; i < nc; i++)
            {
                a[k] = c[i];
                MakeMove(a, k);
                Backtrack(a, k, n);
                UnMakeMove(a, k);

            }
        }

    }

    private void UnMakeMove(int[] a, int k)
    {
        //throw new NotImplementedException();
    }

    private void MakeMove(int[] a, int k)
    {
        //throw new NotImplementedException();
    }

    private int[] ConstructCandidates(int[] a, int k)
    {
        return new int[]
        {
            1,
            0
        };

    }

    private void ProcessSolution(int[] a, int k, int input)
    {
        Console.Write("{");
        for (int i = 1; i <= k; i++)
        {
            if (a[i] == 1)
            {
                Console.Write(i);
            }

        }

        Console.Write("} ");
    }

    private bool IsASolution(int[] a, int k, int n)
    {
        return k == n;
    }
}

