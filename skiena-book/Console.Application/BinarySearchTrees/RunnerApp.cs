using System;
namespace skiena.book.BinarySearchTrees;

public static class RunnerApp
{
    public static TreeNode CreateTree(int[] inputs)
    {
        TreeNode t = new TreeNode(inputs[0]);

        for (int i = 1; i < inputs.Length; i++)
        {
            t.AddNode(inputs[i]);
        }

        return t;
    }

    public static TreeNode CreateTreeFromSortedArray(int[] inputs)
    {
        int m = inputs.Length / 2;

        TreeNode t = new TreeNode(inputs[m]);

        if (m > 0)
        {
            t.Left = CreateTreeFromSortedArray(inputs[0..m]);
            t.Left.Parent = t;
        }

        if (m + 1 < inputs.Length)
        {
            t.Right = CreateTreeFromSortedArray(inputs[(m + 1)..^0]);
            t.Right.Parent = t;
        }


        return t;
    }

    public static void Delete(TreeNode node, int keyValue)
    {
        var z = node.Search(keyValue);

        if (z != null)
            node.DeleteNode(z);
    }

    public static TreeNode CreateSampleTree() => CreateTree(new int[] { 15, 6, 7, 3, 2, 4, 18, 17, 20, 19, 31 });
}

