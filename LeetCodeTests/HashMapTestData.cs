using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests
{
    public static class HashMapTestData
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
    }
}
