using System;
namespace skiena.book.Graphs;

public static class TreeHelper
{
    /// <summary>
    /// do not adjust tree, if tree is sorted all elelment will be insrted in right.
    /// </summary>
    /// <param name="tree"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TreeNode AddNode(this TreeNode tree, int value)
    {
        var z = new TreeNode(value);

        var x = tree.Parent;

        TreeNode? y = null;

        while (x != null)
        {
            y = x;
            if (z.Key < x.Key)
            {
                x = x.Left;
            }
            else
            {
                x = x.Right;
            }
        }

        z.Parent = y;

        if (y == null)
        {
            tree.Parent = z;
        }
        else if (z.Key < y.Key)
        {
            y.Left = z;
        }
        else
        {
            y.Right = z;
        }

        return tree;

    }

    public static void Traversal(this TreeNode? t)
    {
        if (t != null)
        {
            t.Left.Traversal();
            Console.Write(" {0}",t.Key);
            t.Right.Traversal();

        }
    }
}

