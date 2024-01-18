using leetcode_playground;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests
{
    public class HashMapsTests
    {
        [Theory]
        [InlineData("a", "b", false)]
        [InlineData("aa", "ab", false)]
        [InlineData("aa", "aab", true)]
        public void canConstruct(string ransomNote, string magazine, bool expectedResult)
        {
            string message = string.Format($"InputData: {string.Join(", ", ransomNote)}, Target: {magazine}, ExpectedResult: {expectedResult}");
            Assert.Equal(HashMaps.CanConstruct(ransomNote, magazine), expectedResult);
        }

        [Theory]
        [InlineData("egg", "add", true)]
        [InlineData("foo", "bar", false)]
        [InlineData("paper", "title", true)]
        [InlineData("badc", "baba", false)]
        public void isIsomorphic(string s, string t, bool expectedResult)
        {
            string message = string.Format($"InputData: {string.Join(", ", s)}, Target: {t}, ExpectedResult: {expectedResult}");
            Assert.Equal(HashMaps.IsIsomorphic(s, t), expectedResult);
        }


        [Theory]
        [InlineData("abba", "dog cat cat dog", true)]
        [InlineData("abba", "dog dog dog dog", false)]
        [InlineData("abba", "dog cat cat fish", false)]
        [InlineData("aaaa", "dog cat cat dog", false)]
        [InlineData("aaaa", "dog cat cat dog dog", false)]
        [InlineData("aaaa", "dog cat cat", false)]
        public void wordPattern(string pattern, string s, bool expectedResult)
        {
            string message = string.Format($"InputData: {string.Join(", ", pattern)}, Target: {s}, ExpectedResult: {expectedResult}");
            Assert.Equal(HashMaps.WordPattern(pattern, s), expectedResult);
        }
    }
}
