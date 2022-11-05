using System;
namespace LeetCodeProblems;

public class MaxSubArrayKadane
{
    public static (int, int[]) MaxSubarray(int[] nums)
    {
        int maxSum = int.MinValue;
        int rSum = 0;
        int startPtr = 0;
        int startIdx = 0;
        int endIdx = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            rSum += nums[i];

            if (maxSum < rSum)
            {
                maxSum = rSum;
                startIdx = startPtr;
                endIdx = i;
            }

            if (rSum < 0)
            {
                rSum = 0;
                startPtr = i + 1;
            }
        }


        return (maxSum, new int[] { startIdx, endIdx });
    }
}

