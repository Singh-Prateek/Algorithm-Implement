using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeProblems;

public class ThreeSumProblem
{
    public static IList<IList<int>> ThreeSum2(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();

        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i - 1] == nums[i]) continue;

            var remains = TwoSum(nums, -nums[i], i + 1);

            foreach (var triplet in remains)
            {
                if (triplet.Length == 0) continue;

                Array.Sort(triplet);

                if (!result.Any(a =>
                {
                    return (new int[] { 0, 1, 2 }).All(i => a[i] == triplet[i]);
                }))
                {
                    result.Add(triplet.ToList());
                }
            }
        }

        return result;
    }

    public static IEnumerable<int[]> TwoSum(int[] nums, int target, int startIndex)
    {
        Dictionary<int, int> lookup = new Dictionary<int, int>();

        for (int i = startIndex; i < nums.Length; i++)
        {
            if (lookup.ContainsKey(nums[i]))
            {
                yield return new int[] { -target, nums[i], lookup[nums[i]] };
            }
            else
            {
                if (!lookup.ContainsKey(target - nums[i]))
                {
                    lookup.Add(target - nums[i], nums[i]);
                }
            }
        }

        yield return Array.Empty<int>();
    }


    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(nums);

        int target = 0;

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i - 1] == nums[i]) continue;

            int left = i + 1;
            int right = nums.Length - 1;

            target = -nums[i];

            while (left < right)
            {
                int sum = nums[left] + nums[right];

                if (sum > target)
                {
                    right -= 1;
                }
                else if (sum < target)
                {
                    left += 1;
                }
                else
                {
                    result.Add(new List<int>() { nums[i], nums[left], nums[right] });

                    do
                    {
                        left += 1;
                    }
                    while (nums[left] == nums[left - 1] && left < right);

                }
            }

        }

        return result;
    }

}



