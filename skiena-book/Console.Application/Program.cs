// See https://aka.ms/new-console-template for more information
using skiena.book.graph;
using skiena.book.prim;


Graph g = GraphCommand.Create(new string[]
{
    "1 3 12",
    "3 5 7",
    "5 6 2",
    "6 7 5",
    "7 2 7",
    "2 1 5",
    "1 4 7",
    "4 5 3",
    "4 7 4",
    "5 7 2",
    "2 4 9",
    "4 3 4"
}, 7);

Prims p = new(7);
Console.WriteLine(p.PrimsAlgo(g,2)); 