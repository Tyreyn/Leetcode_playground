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

        [Theory]
        [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
        public void FindMaxProfit(int[] input1, int expectedResult)
        {
            Assert.Equal(Arrays.MaxProfit2(input1), expectedResult);
        }

        [Theory]
        [InlineData(new int[] { 2, 3, 1, 1, 4 }, true)]
        [InlineData(new int[] { 3, 2, 1, 0, 4 }, false)]
        public void CanJump(int[] input1, bool expectedResult)
        {
            Assert.Equal(Arrays.CanJump(input1), expectedResult);
        }

        [Theory]
        [InlineData(new int[] { 3, 0, 6, 1, 5 }, 3)]
        [InlineData(new int[] { 1, 3, 1 }, 1)]
        [InlineData(new int[] { 0 }, 0)]
        [InlineData(new int[] { 100 }, 1)]
        public void FindHIndex(int[] input1, int expectedResult)
        {
            Assert.Equal(Arrays.HIndex(input1), expectedResult);
        }
    }
}