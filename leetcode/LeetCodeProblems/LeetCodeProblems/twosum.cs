using System;
using System.Collections.Generic;

System.Console.WriteLine(TwoSum(new int[] { 2, 3, 4 }, 6));
System.Console.WriteLine(TwoSum(new int[] { -3, 3, 4 }, 0));

// O(n) time as only one loop and lookup us O(1)
//space complexity O(n)
int[] TwoSum(int[] nums, int target)
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

    return 0;
}

// int[] TwoSum2(int[] nums, int target)
// {
//     int sorted = nums.
// }