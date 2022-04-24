// See https://aka.ms/new-console-template for more information
//HeapSort m = new(HeapType.MinHeap);
//const int length = 8;
//int[] src = new int[length] { 48, 24, 12, 10, 23, 21, 101, 32 };

//Console.WriteLine("heap");

//Console.WriteLine(string.Join(", ", m.CreateHeap(src, length)[1..]));

//Console.WriteLine("\nsorted");

//Console.WriteLine(string.Join(", ", m.Sort(src)));

using skiena_book;

var edges = new List<List<int>>() { new List<int>() { 1, 2 }, new List<int>() { 1, 3 }, new List<int>() { 3, 4 }, new List<int>() { 3, 4 } };

Graph g = new(5,edges,false);
g.Print();  

BreathFirstSearch ga = new();

ga.Bfs(5, g, 1);
