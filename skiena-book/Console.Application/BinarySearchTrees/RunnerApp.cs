using System;
namespace skiena.book.BinarySearchTrees;

public static class RunnerApp
{
    public static TreeNode CreateSampleTree()
    {
        TreeNode t = new(6)
        {
            Parent = new TreeNode(15)
            {
                Right = new TreeNode(18)
            }
        };

        t.Parent.Left = t;
        t.Parent.Right.Parent = t.Parent;


        var inputs = new int[] { 7, 3, 2, 4, 17, 20, 19, 31 };

        foreach (var e in inputs)
        {
            t.AddNode(e);
        }

        return t.Parent;
    }

    public static void Delete(TreeNode node, int keyValue)
    {
        var z = node.Search(keyValue);

        if (z != null)
            node.DeleteNode(z);
    }
}

