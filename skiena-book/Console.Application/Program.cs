// See https://aka.ms/new-console-template for more information
using skiena.book.combinationsearch;
using skiena.book.BinarySearchTrees;

Console.WriteLine("helllo");


var node = RunnerApp.CreateSampleTree();
node.Traversal();
Console.WriteLine("");

RunnerApp.Delete(node, 6);

Console.WriteLine("after node delete ");
node.Traversal();