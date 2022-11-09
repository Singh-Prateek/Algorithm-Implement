using System;
namespace LeetCodeProblems;

public class ReverseIntegerOrder
{
    public static void Run()
    {
        Console.WriteLine("source :{0}\top: {1} ", 298, Reverse(298));
    }

    static int Reverse(int x)
    {

        int result = 0;

        int max = int.MaxValue / 10;
        int min = int.MinValue / 10;

        while (x != 0)
        {
            int num = x % 10;

            if (result > max || result < min) return 0;

            result = result * 10 + num;

            x /= 10;
        }

        return result;

    }
}

