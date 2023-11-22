using leetcode_playground;
namespace LeetCodeTests
{
    public class UnitTest1
    {
        [Fact]
        public void SearchInRotatedArrayTest()
        {
            (int[] inputData, int target, int expectedResult)[] testScenarios =
            {
                (new int[] { 4, 5, 6, 7, 0, 1, 1 }, 0, 4),
                (new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1),
                (new int[] { 1 }, 0, -1)
            };

            foreach (var (inputData, target, expectedResult) in testScenarios)
            {
                string message = string.Format($"InputData: {string.Join(", ", inputData)}, Target: {target}, ExpectedResult: {expectedResult}");
                Assert.Equal(Arrays.Search(inputData, target), expectedResult);
            }
        }
    }
}