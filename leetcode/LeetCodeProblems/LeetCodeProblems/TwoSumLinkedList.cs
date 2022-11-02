using System;
namespace LeetCodeProblems.TwoSumLinkedList;

/**
 * Definition for singly-linked list.*/
public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode? result = null;
        int carryOver = 0;

        ListNode? ptrl = l1;
        ListNode? ptrr = l2;

        List<ListNode> items = new List<ListNode>();

        while (ptrl != null || ptrr != null || carryOver > 0)
        {
            int val = carryOver;

            if (ptrl != null)
            {
                val += ptrl.val;
                ptrl = ptrl.next;
            }

            if (ptrr != null)
            {
                val += ptrr.val;
                ptrr = ptrr.next;
            }

            carryOver = val % 10;

            items.Add(new ListNode(val / 10, null));

        }

        for (int i = items.Count - 1; i >= 0; i--)
        {
            ListNode? temp = result;
            result = items[i];
            result.next = temp;
        }

        return result is ListNode ? result : new ListNode(0, null);

    }
}

