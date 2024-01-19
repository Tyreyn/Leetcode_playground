using leetcode_playground;

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

        [Theory]
        [InlineData("anagram", "nagaram", true)]
        [InlineData("rat", "car", false)]
        [InlineData("raat", "car", false)]
        [InlineData("anal", "lana", true)]
        public void isAnagram(string pattern, string s, bool expectedResult)
        {
            string message = string.Format($"InputData: {string.Join(", ", pattern)}, Target: {s}, ExpectedResult: {expectedResult}");
            Assert.Equal(HashMaps.IsAnagram(pattern, s), expectedResult);
        }

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
        [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
        public void twoSum(int[] nums, int target, int[] expectedResult)
        {
            string message = string.Format($"InputData: {string.Join(", ", nums)}, Target: {target}, ExpectedResult: {string.Join(",", expectedResult)}");
            Assert.Equal(HashMaps.TwoSum(nums, target), expectedResult);
        }

        [Theory]
        [MemberData(nameof(HashMapTestData.TD_GroupAnagrams), MemberType = typeof(HashMapTestData))]
        public void groupAnagrams(string[] nums, List<List<string>> expectedResult)
        {
            string message = string.Format($"InputData: {string.Join(", ", nums)}, ExpectedResult: {string.Join(",", expectedResult)}");
            Assert.Equal(expectedResult, HashMaps.GroupAnagrams(nums));
        }

    }
}
