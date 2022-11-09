using System;
namespace LeetCodeProblems;

public class LongestSubString
{

    public static int LengthOfLongestSubstring(string s)
    {

        int n = s.Length;

        if (n == 0) return 0;

        Dictionary<char, int> map = new Dictionary<char, int>(n);
        int max = 0;

        for (int i = 0, j = 0; i < n; i++)
        {

            if (map.ContainsKey(s[i]))
            {
                j = Math.Max(j, map[s[i]] + 1);
                map[s[i]] = i;
            }
            else
            {
                map.Add(s[i], i);
            }

            max = Math.Max(max, i - j + 1);

        }

        return max;
    }
}

