using System;
namespace LeetCodeProblems;

public class MostWaterProblem
{
    public static void Run()
    {
        Console.WriteLine(MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
    }

    private static int MaxArea(int[] height)
    {
        int l = 0; int r = height.Length - 1;

        int maxVol = 0;

        int b = 0;
        int h = 0;
        do
        {

            b = r - l;

            h = Math.Min(height[l], height[r]);

            //Console.WriteLine("l: {0},r: {1};{2}*{3}\t{4}", l, r, b, h, b * h);

            maxVol = Math.Max(maxVol, b * h);

            if (height[l] < height[r])
            {
                l++;
            }
            else
            {
                r--;
            }

        } while (l < r);

        return maxVol;
    }
}

