using System;
using System.Collections.Generic;
using System.Linq;

internal class TwoSums
{

    // O(n) time as only one loop and lookup us O(1)
    //space complexity O(n)
    internal static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (map.ContainsKey(nums[i]))
            {
                return new int[] { map[nums[i]], i };
            }
            else
            {
                if (!map.ContainsKey(target - nums[i]))
                    map.Add(target - nums[i], i);
            }
        }

        return Array.Empty<int>();
    }

    //space complexity will be O(2) and
    //time complexity will O(nLogn) + O(n) = nlogn 
    internal static int[] TwoSumMakingNumber(int[] nums, int target)
    {
        int[] sorted = nums.OrderBy(o => o).ToArray();

        int[] result = new int[] { 0, nums.Length - 1 };

        int temp = 0;

        for (int i = 0; i < sorted.Length; i++)
        {
            temp = sorted[result[0]] + sorted[result[1]];

            if (temp < target)
            {
                result[0] += 1;
            }
            else if (temp > target)
            {
                result[1] -= 1;
            }
            else
            {
                break;
            }

        }

        return new int[] { sorted[result[0]], sorted[result[1]] };
    }
}