using leetcode_playground.Helpers.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests.Data
{
    public static class TestsData
    {

        public static IEnumerable<object[]> TD_HasCycle()
        {
            ListNode tmp1 = new ListNode(2);
            ListNode tmp2 = new ListNode(1);
            yield return new object[]
            {
                new ListNode(3, tmp1.next = new ListNode(0, new ListNode(-4, tmp1))),
                true,
            };
            yield return new object[]
            {
                tmp2.next = new ListNode(2, tmp2),
                true,
            };
            yield return new object[]
            {
                new ListNode(1),
                false,
            };
        }

        public static IEnumerable<object[]> TD_SwapPairs()
        {
            yield return new object[]
            {
                new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))),
                new int[] {2,1,4,3},
            };
            yield return new object[]
            {
                new ListNode(),
                new int[] {},
            };
            yield return new object[]
            {
                new ListNode(1),
                new int[] {1},
            };
            yield return new object[]
            {
                new ListNode(1, new ListNode(2, new ListNode(3))),
                new int[] {2,1,3},
            };
        }

        public static IEnumerable<object[]> TD_RemoveElements()
        {
            yield return new object[]
            {
                new ListNode(1, new ListNode(2, new ListNode(6, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6))))))),
                6,
                new int[] {1,2,3,4,5},
            };
            yield return new object[]
            {
                new ListNode(),
                1,
                new int[] {},
            };
            yield return new object[]
            {
                new ListNode(7, new ListNode(7, new ListNode(7, new ListNode(7, new ListNode(7))))),
                7,
                new int[] {},
            };
        }

        public static IEnumerable<object[]> TD_GroupAnagrams()
        {
            yield return new object[]
            {
                new string[] { "eat", "tea", "tan", "ate", "nat", "bat" },
                new List<List<string>>
                {
                    new List<string> {"bat"},
                    new List<string> {"nat","tan"},
                    new List<string> {"ate","eat","tea"}
                },
            };
            yield return new object[]
            {
                new string[] { "" },
                new List<List<string>>
                {
                    new List<string> {{""}}
                },
            };
            yield return new object[]
            {
                new string[] { "a" },
                new List<List<string>>
                {
                    new List<string> { { "a" } }
                },
            };
            yield return new object[]
            {
                null,
                null,
            };
        }

        public static IEnumerable<object[]> TD_SummaryRanges()
        {
            yield return new object[]
            {
                new int[] { 0,1,2,4,5,7 },
                new List<string>
                {
                    "0->2",
                    "4->5",
                    "7"
                },
            };
            yield return new object[]
            {
                new int[] { 0,2,3,4,6,8,9 },
                new List<string>
                {
                    "0",
                    "2->4",
                    "6",
                    "8->9"
                },
            };
            yield return new object[]
            {
                new int[] {},
                new List<string>
                {
                },
            };
            yield return new object[]
            {
                new int[] {-2147483648,-2147483647,2147483647},
                new List<string>
                {
                    "-2147483648->-2147483647",
                    "2147483647"
                },
            };
        }
    }
}
