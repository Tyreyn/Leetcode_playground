using leetcode_playground;
using leetcode_playground.Helpers.Classes;
using LeetCodeTests.Data;

namespace LeetCodeTests
{
    public class LinkedListTests
    {
        [Theory]
        [MemberData(nameof(TestsData.TD_SwapPairs), MemberType = typeof(TestsData))]
        public void FindFirstOccurance(ListNode input1, int[] expectedResult)
        {
            string message = string.Format($"InputData: {string.Join(',', input1)}, ExpectedResult: {string.Join(',', expectedResult)}");
            ListNode head = LinkedList.SwapPairs(input1);
            ListNode tmp = head;
            foreach (int expected in expectedResult)
            {
                Assert.Equal(expected, tmp.val);
                tmp = tmp.next;
            }
        }

        [Theory]
        [MemberData(nameof(TestsData.TD_RemoveElements), MemberType = typeof(TestsData))]
        public void RemoveElements(ListNode input1, int input2, int[] expectedResult)
        {
            string message = string.Format($"InputData: {string.Join(',', input1)}, target: {input2} ExpectedResult: {string.Join(',', expectedResult)}");
            ListNode head = LinkedList.RemoveElements(input1, input2);
            ListNode tmp = head;
            foreach (int expected in expectedResult)
            {
                Assert.Equal(expected, tmp.val);
                tmp = tmp.next;
            }
        }

        [Theory]
        [MemberData(nameof(TestsData.TD_HasCycle), MemberType = typeof(TestsData))]
        public void HasCycle(ListNode input1, bool expectedResult)
        {
            string message = string.Format($"InputData: {string.Join(',', input1)}, ExpectedResult:  {expectedResult.ToString()}");
            Assert.Equal(expectedResult, LinkedList.HasCycle(input1));
        }
    }
}
