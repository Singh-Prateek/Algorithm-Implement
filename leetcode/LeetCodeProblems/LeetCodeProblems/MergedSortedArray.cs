using System;
namespace LeetCodeProblems
{
    public class MergedSortedArray
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;
            int l1 = 0;
            int l2 = 0;
            int r1 = n;
            int r2 = m;
            int[] merged = new int[m + n];

            if (nums1.Length == 0)
            {
                merged = nums2;
            }
            else if (nums2.Length == 0)
            {
                merged = nums1;
            }
            else
            {

                while (l1 < r1 && l2 < r2)
                {
                    if (nums1[l1] <= nums2[l2])
                    {
                        merged[l1 + l2] = nums1[l1];
                        l1++;
                    }
                    else
                    {
                        merged[l1 + l2] = nums2[l2];
                        l2++;
                    }

                    if (nums1[r1 - 1] >= nums2[r2 - 1])
                    {
                        merged[r1 + r2 - 1] = nums1[r1 - 1];
                        r1--;
                    }
                    else
                    {
                        merged[r1 + r2 - 1] = nums2[r2 - 1];
                        r2--;
                    }
                }

                while (l1 < r1 && l2 >= r2)
                {
                    merged[l1 + l2] = nums1[l1];
                    l1++;
                    merged[r1 + r2 - 1] = nums1[r1 - 1];
                    r1--;
                }

                while (l1 >= r1 && l2 < r2)
                {
                    merged[l1 + l2] = nums2[l2];
                    l2++;
                        
                    merged[r1 + r2 - 1] = nums2[r2 - 1];
                    r2--;
                }
            }

            double result;
            if ((m + n - 1) % 2 == 0)
            {
                int mid = (m + n - 1) / 2;
                result = merged[mid];
            }
            else
            {
                int mid = (m + n) / 2;
                result = (merged[mid] + merged[mid - 1]) / 2.0;
            }

            return result;
        }
    }
}

