namespace skiena.book.kruskal;

public struct UnionFind
{
    public int[] p { get; init; }//parent element count
    public int[] size { get; init; } //elements in a sub-tree
    public int n { get; init; } //number of element in a set

}
