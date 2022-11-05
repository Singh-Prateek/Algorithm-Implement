using System;
namespace LeetCodeProblems;

public class RotatedSortedArray
{
    public static void Run()
    {
        RotatedSortedArray obj = new RotatedSortedArray();

        RunWithMessages(obj, "3,4,5,6,1,2");
        RunWithMessages(obj, "1,2,4,5,6,7,0");
        RunWithMessages(obj, "11,12,32,43");
        RunWithMessages(obj, "222222,111111");
    }

    private static void RunWithMessages(RotatedSortedArray runner, string s)
    {
        Console.WriteLine("1 - source : {0}\tmin :{1}", s, runner.FindMin(GetIntArray(s)));
        Console.WriteLine("2 - source : {0}\tmin :{1}", s, runner.FindMin2(GetIntArray(s)));
    }

    private static int[] GetIntArray(string nums) => nums.Split(',').Select(Int32.Parse).ToArray();

    public int FindMin(int[] nums)
    {
        int idx = Search(nums, 0, nums.Length - 1);

        return nums[idx];
    }

    /// <summary>
    /// original soultion
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    private int Search(int[] nums, int start, int end)
    {

        int lIdx = 0;
        int rIdx = 0;

        int middle = (start + end + 1) / 2;

        if (middle > start && nums[middle] < nums[start])
        {
            if (middle - start == 1)
            {
                return middle;
            }
            lIdx = Search(nums, start, middle);
        }

        if (end > middle && nums[middle] > nums[end])
        {
            if (end - middle == 1)
            {
                return end;
            }
            rIdx = Search(nums, middle, end);
        }

        return Math.Max(lIdx, rIdx);

    }

    /// <summary>
    /// optimized code.
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    private int FindMin2(int[] nums)
    {
        int start = 0;
        int end = nums.Length - 1;

        while (start < end)
        {
            if (nums[start] < nums[end]) return nums[start];

            int middle = (start + end) / 2;

            if (nums[middle] >= nums[start])
            {
                start = middle + 1;
            }
            else
            {
                end = middle;
            }
        }

        return nums[start];
    }

}

