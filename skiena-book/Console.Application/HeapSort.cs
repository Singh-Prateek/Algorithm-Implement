﻿internal class HeapSort
{
    private Func<int[], int, int, bool> _heapType;

    public HeapSort(Func<int[], int, int, bool> heapType)
    {
        this._heapType = heapType;
    }
    public int[] Sort(int[] unsorted)
    {
        int n = unsorted.Length;
        int[] heap = CreateHeap(unsorted, n);

        int[] sorted = new int[n];

        int heapLength = n;

        for (int i = 0; i < n && heapLength > 0; i++)
        {
            sorted[i] = heap[1];
            heap[1] = heap[heapLength];
            --heapLength;
            BubbleDown(heap, 1, heapLength);
        }

        return sorted;
    }

    public int[] CreateHeap(int[] source, int length)
    {
        //heap starts at 1
        int[] heap = new int[length + 1];

        for (int i = 0; i < length; i++)
        {
            heap[i + 1] = source[i];
            BubbleUp(heap, i + 1);
        }

        return heap;
    }

      private void BubbleUp(int[] heap, int idx)
    {
        int pIdx = ParentNode(idx);

        if (pIdx == -1) return;

        if (_heapType(heap, idx, pIdx))
        {
            SwapNodes(heap, idx, pIdx);
            BubbleUp(heap, pIdx);
        }
    }

    private void BubbleDown(int[] heap, int idx, int n)
    {
        //if (idx <= 0) return;

        int cIdx = ChildLeftNode(idx);

        int min_idx = idx;
        for (int i = 0; i < 2; i++)
        {
            if (cIdx + i <= n)
            {
                if (_heapType(heap, cIdx + i, min_idx))
                {
                    min_idx = cIdx + i;
                }
            }
        }

        if (min_idx != idx)
        {
            SwapNodes(heap, idx, min_idx);
            BubbleDown(heap, min_idx, n);
        }
    }
    private static void SwapNodes(int[] heap, int src, int dest)
    {
        int temp = heap[dest];
        heap[dest] = heap[src];
        heap[src] = temp;
    }

    private int ParentNode(int idx)
    {
        if (idx == 1) return -1;
        return idx / 2;
    }
    private int ChildLeftNode(int idx)
    {
        return idx * 2;
    }
}
internal class HeapType
{
    public static bool MinHeap(int[] heap, int idx, int pIdx)
    {
        return heap[pIdx] > heap[idx];
    }

    public static bool MaxHeap(int[] heap, int idx, int pIdx)
    {
        return heap[pIdx] < heap[idx];
    }
}