using System;

namespace GenerateTree;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    private readonly Dictionary<int, IList<TreeNode>> memo = new Dictionary<int, IList<TreeNode>>();

    public Solution()
    {
        memo.Add(0, new List<TreeNode>());
        memo.Add(1, new List<TreeNode>() { new TreeNode(0) });
    }

    public IList<TreeNode> AllPossibleFBT(int n)
    {

        if (n % 2 == 0) return memo[0];

        if (!memo.ContainsKey(n))
        {

            memo[n] = new List<TreeNode>();

            for (int i = 1; i < n; i+=2)
            {
                foreach (var left in AllPossibleFBT(i))
                {

                    foreach (var right in AllPossibleFBT(n - 1 - i))
                    {

                        var root = new TreeNode(0,left,right);
                        //Console.WriteLine("current n {0}", n);
                        memo[n].Add(root);
                    }

                }

            }
        }

        return memo[n];
    }
}