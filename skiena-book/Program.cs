// See https://aka.ms/new-console-template for more information
//HeapSort m = new(HeapType.MinHeap);
//const int length = 8;
//int[] src = new int[length] { 48, 24, 12, 10, 23, 21, 101, 32 };

//Console.WriteLine("heap");

//Console.WriteLine(string.Join(", ", m.CreateHeap(src, length)[1..]));

//Console.WriteLine("\nsorted");

//Console.WriteLine(string.Join(", ", m.Sort(src)));

using skiena_book;



//var edges = new List<List<int>>() { new List<int>() { 1, 2 }, new List<int>() { 1, 3 }, new List<int>() { 3, 4 }, new List<int>() { 3, 4 } };

//var edges1 = new List<List<int>>() {
//    new List<int>() { 1, 2 },
//    new List<int>() { 1, 3 },
//    new List<int>() { 3, 4 },
//    new List<int>() { 3, 4 }
//};

//Graph g = new(10, edges1, false);
//g.Print();

var edges = new List<List<int>>() {
    new List<int>() { 1, 2 },
    new List<int>() { 1, 7 },
    new List<int>() { 1, 8 },
    new List<int>() { 2, 3 },
    new List<int>() { 2, 5 },
    new List<int>() { 2, 7 },
    new List<int>() { 3, 4 },
    new List<int>() { 3, 5 },
    new List<int>() { 4, 5 },
    new List<int>() { 5, 6 },
};

Graph g = new(8, edges, false);
g.Print();

int start = 1;
//BreathFirstSearch ga = new();

//ga.Bfs(g, start);

//ga.FindPath(6);

//ga.FindPath(4);

var crossEdge = new List<List<int>>() {
    new List<int>() { 1, 5 },
    new List<int>() { 1, 2 },
    new List<int>() { 2, 3 },
    new List<int>() { 2, 4 },
    //new List<int>() { 4, 5 },
    new List<int>() { 5, 2 },
};

//Console.WriteLine("another graph");
Graph cg = new(5, crossEdge, true);
cg.Print();

DepthFirstSearch df = new();

df.Dfs(g, start);

df.Dfs(cg, start);
