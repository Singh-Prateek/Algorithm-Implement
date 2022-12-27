﻿using System;
namespace skiena.book.BinarySearchTrees;

public class TreeNode
{
	public TreeNode? Left { get; set; }
	public TreeNode? Right { get; set; }
	public TreeNode? Parent { get; set; }
	public int Key { get; private set; }

	public TreeNode(int key)
	{
		this.Key = key;
	}

	public void SetRoot(int rootKey)
	{
		this.Key = rootKey;
	}
}


