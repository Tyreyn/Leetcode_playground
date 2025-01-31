using leetcode_playground.Helpers.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_playground
{
    public static class LinkedList
    {
        /// <summary>
        /// 24. Swap Nodes in Pairs
        /// </summary>
        public static ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode dummy = new ListNode(0, head);

            ListNode previousFirst = dummy;
            ListNode previousSecond = head;

            while (previousFirst.next != null && previousSecond.next != null)
            {
                ListNode first = previousFirst.next;
                ListNode second = previousSecond.next;
                ListNode nextSecond = second.next;

                previousFirst.next = second;
                second.next = first;
                first.next = nextSecond;

                previousFirst = first;
                previousSecond = nextSecond;
            }

            return dummy.next;
        }

        /// <summary>
        /// 203. Remove Linked List Elements
        /// </summary>
        public static ListNode RemoveElements(ListNode head, int val)
        {
            ListNode dummy = new ListNode(0);
            ListNode curr = dummy;
            dummy.next = head;
            while (curr.next != null)
            {
                if (curr.next.val == val)
                {
                    curr.next = curr.next.next;
                }
                else
                {
                    curr = curr.next;
                }
            }
            return dummy.next;
        }

        /// <summary>
        /// 141. Linked List Cycle
        /// </summary>
        public static bool HasCycle(ListNode head)
        {
            HashSet<ListNode> cycle = new HashSet<ListNode>();
            ListNode curr = head;
            while (curr != null)
            {
                if (cycle.Contains(curr))
                {
                    return true;
                }
                else
                {
                    cycle.Add(curr);
                    curr = curr.next;
                }
            }
            return false;
        }
    }
}
