using System;
namespace LeetCodeProblems;

public class RotatedSortedArray
{
    public static void Run()
    {
        RotatedSortedArray obj = new RotatedSortedArray();

        RunWithMessages(obj, "5,1,3", 0);
        RunWithMessages(obj, "4,5,6,7,0,1,2", 3);
        RunWithMessages(obj, "5,1,2,3,4", 4);
        RunWithMessages(obj, "3,4,5,1,2");
        RunWithMessages(obj, "1,2,3,4,5");
        RunWithMessages(obj, "2,3,4,5,1", 1);
        RunWithMessages(obj, "1", 1);
        RunWithMessages(obj, "6,1,2,3,4,5");
        RunWithMessages(obj, "1,2,4,5,6,7");
        RunWithMessages(obj, "11,12,43");
        RunWithMessages(obj, "11,12");
        RunWithMessages(obj, "222222,111111");
    }

    private static void RunWithMessages(RotatedSortedArray runner, string s, int target = 1)
    {
        int index = 0;
        Console.WriteLine("{0} - source :{1}\tmin :{2}", ++index, s, FindMinInArray(GetIntArray(s)));
        Console.WriteLine("{0} - source :{1}\tmin :{2}", ++index, s, runner.FindMinRecursion(GetIntArray(s)));
        Console.WriteLine("{0} - source :{1}\tmax :{2}", ++index, s, FindMaxInArray(GetIntArray(s)));
        Console.WriteLine("{0} - source :{1}\ttarget :{2}\tidx :{3}", ++index, s, target, FindInArray(GetIntArray(s), target));
        Console.WriteLine("");
    }

    private static int[] GetIntArray(string nums) => nums.Split(',').Select(Int32.Parse).ToArray();

    public int FindMinRecursion(int[] nums)
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
        if (end <= start) return start;

        int middle = (start + end) / 2;

        if (nums[middle] > nums[end])
        {
            return Search(nums, middle + 1, end);
        }
        else
        {
            return Search(nums, start, middle);
        }

    }

    /// <summary>
    /// iteration loop.
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    private static int FindMaxInArray(int[] nums)
    {
        int start = 0;
        int end = nums.Length - 1;
        int middle;

        while (start < end)
        {
            middle = (start + end + 1) / 2;

            if (nums[start] > nums[middle])
            {
                end = middle - 1;
            }
            else
            {
                start = middle;
            }
        }

        //Console.WriteLine("min idx:{0}", (start + 1) % nums.Length);

        return nums[start];
    }

    private static int FindMinInArray(int[] nums)
    {
        int l = 0;
        int r = nums.Length - 1;
        int m = 0;

        while (l < r)
        {
            m = (l + r) / 2;

            if (nums[m] > nums[r])
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }

        //Console.WriteLine("max idx:{0}", (l + nums.Length - 1) % nums.Length);
        return nums[l];
    }

    private static int FindInArray(int[] nums, int target)
    {
        int l = 0;
        int m = 0;
        int r = nums.Length - 1;

        while (l <= r)
        {
            m = (l + r) / 2;

            if (nums[m] == target) return m;

            //left sorted
            if (nums[l] <= nums[m])
            {
                if (target < nums[l] || target > nums[m])
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }

            }
            else
            {
                //right sorted
                if (target < nums[m] || target > nums[r])
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }

            }

        }

        return -1;
    }

}