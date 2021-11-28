// See https://aka.ms/new-console-template for more information
string name = "ps";
Console.WriteLine($"Hello, World! {name}");

HeapSort m = new(HeapType.MinHeap);
const int length = 7;
int[] src = new int[length] { 48, 24, 12, 10, 23, 21, 101 };

Console.WriteLine(string.Join(", ", m.createHeap(src, length)[1..]));

Console.WriteLine("\nsorted");

Console.WriteLine(string.Join(", ", m.Sort(src)));
