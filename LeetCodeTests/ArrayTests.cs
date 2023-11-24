using leetcode_playground;
namespace LeetCodeTests
{
    public class ArraysTest
    {
        [Theory]
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
        [InlineData(new int[] { 1 }, 0, -1)]
        public void SearchInRotatedArrayTest(int[] inputData, int target, int expectedResult)
        {
            string message = string.Format($"InputData: {string.Join(", ", inputData)}, Target: {target}, ExpectedResult: {expectedResult}");
            Assert.Equal(Arrays.Search(inputData, target), expectedResult);
        }

        [Theory]
        [InlineData("abc", "ahbgdc", true)]
        [InlineData("acb", "ahbgdc", false)]
        [InlineData("axc", "ahbgdc", false)]
        [InlineData("b", "abc", true)]
        public void IsSubsequenceTest(string input1, string input2, bool expectedResult)
        {
            Assert.Equal(Arrays.IsSubsequence(input1, input2), expectedResult);
        }
    }
}