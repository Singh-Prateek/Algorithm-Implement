// See https://aka.ms/new-console-template for more information
using skiena.book.combinationsearch;
using skiena.book.BinarySearchTrees;

Console.WriteLine("helllo");


var node = RunnerApp.CreateTreeFromSortedArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 12, 19 });
node.Traversal();
Console.WriteLine("");

//RunnerApp.Delete(node, 15);

//Console.WriteLine("after node delete ");
//node.Traversal();