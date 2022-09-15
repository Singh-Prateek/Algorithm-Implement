using System;
namespace LeetCodeProblems;

internal class ValidParentheses
{
    internal static bool IsValid(string s)
    {
        var stack = new Stack<char>();

        Dictionary<char, int> start = new() { { '(', 1 }, { '{', 2 }, { '[', 3 } };
        Dictionary<char, int> end = new() { { ')', 1 }, { '}', 2 }, { ']', 3 } };

        int peekCheck = 0;

        foreach (char c in s)
        {

            if (start.ContainsKey(c))
            {
                stack.Push(c);
            }

            if (end.ContainsKey(c))
            {
                if (stack.Any())
                {
                    start.TryGetValue(stack.Peek(), out peekCheck);
                }
                else
                {
                    peekCheck = 0;
                }

                if (peekCheck == end[c])
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

    internal static int LongestValidParentheses(string s)
    {

        Stack<int> stack = new Stack<int>();

        stack.Push(-1);

        int maxLen = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (c == '(')
            {
                stack.Push(i);
            }
            else
            {
                stack.Pop();

                if (!stack.Any())
                {
                    stack.Push(i);
                }

                maxLen = Math.Max(maxLen, i - stack.Peek());
            }
        }

        return maxLen;

    }
}

