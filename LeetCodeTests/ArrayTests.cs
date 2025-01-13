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

        [Theory]
        [InlineData("III", 3)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void RomanToNumerals(string input1, int expectedResult)
        {
            Assert.Equal(Arrays.RomanToInt(input1), expectedResult);
        }

        [Theory]
        [InlineData(3, "III")]
        [InlineData(58, "LVIII")]
        [InlineData(1994, "MCMXCIV")]
        [InlineData(3749, "MMMDCCXLIX")]
        public void NumeralsToRoman(int input1, string expectedResult)
        {
            Assert.Equal(Arrays.IntToRoman(input1), expectedResult);
        }

        [Theory]
        [InlineData("Hello World", 5)]
        [InlineData("   fly me   to   the moon  ", 4)]
        [InlineData("luffy is still joyboy", 6)]
        public void LengthOfLastWord(string input1, int expectedResult)
        {
            Assert.Equal(Arrays.LengthOfLastWord(input1), expectedResult);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5, 1, 2 }, 3)]
        [InlineData(new int[] { 2, 3, 4 }, new int[] { 3, 4, 3 }, -1)]
        [InlineData(new int[] { 5, 1, 2, 3, 4 }, new int[] { 4, 4, 1, 5, 1 }, 4)]
        [InlineData(new int[] { 3, 1, 1 }, new int[] { 1, 2, 2 }, 0)]

        public void CanCompleteCircuit(int[] input1, int[] input2, int expectedResult)
        {
            Assert.Equal(Arrays.CanCompleteCircuit(input1, input2), expectedResult);
        }

        [Theory]
        [InlineData("the sky is blue", "blue is sky the")]
        [InlineData("  hello world  ", "world hello")]
        [InlineData("a good   example", "example good a")]

        public void ReverseWords(string input1, string expectedResult)
        {
            Assert.Equal(Arrays.ReverseWords(input1), expectedResult);
        }

        [Theory]
        [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
        [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
        [InlineData("A", 1, "A")]
        [InlineData("AB", 1, "AB")]

        public void Convert(string input1, int input2, string expectedResult)
        {
            Assert.Equal(Arrays.Convert(input1, input2), expectedResult);
        }

        [Theory]
        [InlineData(new int[] { 1, 0, 2 }, 5)]
        [InlineData(new int[] {1,2,2}, 4)]
        public void Candy(int[] input1, int expectedResult)
        {
            Assert.Equal(Arrays.Candy(input1), expectedResult);
        }

        [Theory]
        [InlineData(new string[] { "This", "is", "an", "example", "of", "text", "justification." },
            16,
            new string[] { "This    is    an", "example  of text", "justification.  " })]
        [InlineData(new string[] { "What", "must", "be", "acknowledgment", "shall", "be" },
            16,
            new string[] { "What   must   be", "acknowledgment  ", "shall be        " })]
        [InlineData(new string[] { "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do" },
            20,
            new string[] { "Science  is  what we","understand      well","enough to explain to","a  computer.  Art is","everything  else  we","do                  " })]
        public void FullJustify(string[] input1, int input2, string[] expectedResult)
        {
            Assert.Equal(expectedResult, Arrays.FullJustify(input1, input2));
        }
    }
}