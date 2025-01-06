using leetcode_playground;
using LeetCodeTests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests
{
    public class TwoPointersTests
    {
        [Theory]
        [InlineData("sadbutsad", "sad", 0)]
        [InlineData("leetcode", "leeto", -1)]
        [InlineData("hello", "ll", 2)]
        [InlineData("mississippi", "issip", 4)]
        public void FindFirstOccurance(string haystack, string needle, int expectedResult)
        {
            string message = string.Format($"InputData: {haystack}, Target: {needle}, ExpectedResult: {expectedResult}");
            Assert.Equal(TwoPointers.StrStr(haystack, needle), expectedResult);
        }

        [Theory]
        [InlineData("barfoothefoobarman", new string[] { "foo", "bar" }, new int[] {0,9})]
        [InlineData("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "word" }, new int[] {})]
        [InlineData("barfoofoobarthefoobarman", new string[] { "bar", "foo", "the" }, new int[] { 6,9,12 })]
        public void FindFindSubstring(string s, string[] words, int[] expectedResult)
        {
            string message = string.Format($"InputData: {s}, Target: {string.Join(',', words)}, ExpectedResult: {expectedResult}");
            Assert.Equal(TwoPointers.FindSubstring(s, words), expectedResult);
        }
    }
}
