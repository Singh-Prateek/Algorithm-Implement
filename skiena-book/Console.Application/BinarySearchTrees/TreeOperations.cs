using System;
namespace skiena.book.BinarySearchTrees;

public static class TreeOperations
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

        var x = tree.Root();

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
            tree.SetRoot(value);
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
            Console.Write(" {0}{1}", t.Key, GetPosition(t));
            t.Right.Traversal();

        }

        static string GetPosition(TreeNode t)
        {
            return t.Parent?.Left?.Key == t.Key ? "L" : (t.Parent == null ? "root" : "R");
        }
    }

    public static TreeNode TreeMinimum(this TreeNode t)
    {
        var x = t;

        while (x.Left != null)
        {
            x = x.Left;
        }

        return x;
    }

    public static TreeNode TreeMaximum(this TreeNode t)
    {
        var x = t;

        while (x.Right != null)
        {
            x = x.Right;
        }

        return x;
    }

    public static TreeNode? Search(this TreeNode t, int searcKey)
    {
        if (t == null || t.Key == searcKey) return t;

        if (t.Key < searcKey && t.Right != null) return t.Right.Search(searcKey);

        if (t.Key > searcKey && t.Left != null) return t.Left.Search(searcKey);

        return null;
    }


    public static void DeleteNode(this TreeNode t, TreeNode z)
    {
        if (z.Left == null) Transplant(t, z, z.Right);

        else if (z.Right == null) Transplant(t, z, z.Left);

        else
        {
            var y = z.Right.TreeMinimum();

            if (y != z.Right)
            {
                Transplant(t, y, y.Right);
                y.Right = z.Right;
                y.Right.Parent = y;
            }

            Transplant(t, z, y);
            y.Left = z.Left;
            y.Left.Parent = y;

        }

    }

    private static void Transplant(TreeNode t, TreeNode u, TreeNode? v)
    {
        if (u.Parent == null)
        {
            if (v != null)
            {
                t.SetRoot(v.Key);
            }
        }
        else if (u == u.Parent.Left)
        {
            u.Parent.Left = v;
        }
        else
        {
            u.Parent.Right = v;
        }

        if (v != null)
        {
            v.Parent = u.Parent;
        }
    }

    public static TreeNode Root(this TreeNode t)
    {
        if (t.Parent != null) return t.Parent.Root();

        return t;

    }
}

