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
                    stack.Push(c);
                }
            }
        }

        return stack.Count == 0;
    }
}

