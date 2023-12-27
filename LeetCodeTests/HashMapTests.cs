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
    }
}
