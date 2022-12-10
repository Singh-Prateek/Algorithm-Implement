// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using LeetCodeProblems;

Console.WriteLine($"Hello, World!\t{"prateek",-10} {10000,5:N2}");

Console.WriteLine(Fibonacci(5));
Console.WriteLine(Fibonacci(3));

int Fibonacci(int n)
{
    int result = 0;

    if (n <= 0) return 0;
    if (n == 1) return 1;
    if (n == 2) return 2;

    
    int prev1 = 2;
    int prev2 = 1;

    for (int i = 3; i <= n; i++)
    {
        result = prev1 + prev2;

        prev2 = prev1;
        prev1 = result;
    }

    return result;

}

//int Sum(int c1, int c2) => 1 * c1 + 2 * c2;



