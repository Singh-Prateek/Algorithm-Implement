using System;
using System.Linq;

namespace skiena.book.combinationsearch;

public class Backtracking
{
    internal record Data(char[] Options, int MaxSetSize);


    public void AlgoRun()
    {
        var input = new Data(new char[] { 'a', 'b', 'c' }, 3);
        var a = new int[input.MaxSetSize + 1];
        Array.Fill(a, 0);
        Backtrack(input, 0, a);

    }

    /// <summary>
    /// this is for all subsets- 
    /// </summary>
    /// <param name="k">possible items of a which form solution</param>
    /// <param name="inputData">extra parameter condtion.</param>
    /// <param name="a">items of this list form a complete solution</param>
    private void Backtrack(Data inputData, int k, int[] a)
    {
        int nc; // solution candidate count.
        int[] c; //solution candidates

        if (IsSolution(a, k, inputData))
        {
            ProcessSolution(a, k, inputData);
        }
        else
        {
            k += 1;

            c = ConstructCandidates(a, k, inputData);
            nc = c.Length;

            for (int i = 0; i < nc; i++)
            {
                a[k] = c[i];

                MakeMove(a, k);
                Backtrack(inputData, k, a);
                UnMakeMove(a, k);

            }
        }

    }


    private void UnMakeMove(int[] a, int k)
    {
        //a[k] = 0;
        //throw new NotImplementedException();
    }

    private void MakeMove(int[] a, int k)
    {
        //throw new NotImplementedException();
    }

    /// <summary>
    /// all subsets, so any given element either we choose or ignore
    /// </summary>
    /// <param name="a"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    private int[] ConstructCandidates(int[] a, int k, Data input)
    {
        return new int[] { 1, 0 };
    }

    private void ProcessSolution(int[] a, int k, Data input)
    {
        Console.Write("{");

        for (int i = 1; i <= k; i++)
        {
            if (a[i] == 1)
            {
                Console.Write(input.Options[i - 1]);
            }

        }

        Console.Write("} ");
    }

    private bool IsSolution(int[] a, int k, Data n)
    {
        return k == n.MaxSetSize;
    }
}

