using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests
{
    public static class TestsData
    {
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
