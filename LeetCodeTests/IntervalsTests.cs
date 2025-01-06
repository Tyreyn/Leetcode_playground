using leetcode_playground;
using LeetCodeTests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTests
{
    public class IntervalsTests
    {
        [Theory]
        [MemberData(nameof(TestsData.TD_SummaryRanges), MemberType = typeof(TestsData))]
        public void summaryRanges(int[] nums, IList<string> expectedResult)
        {
            string message = string.Format($"InputData: {string.Join(", ", nums)}, ExpectedResult: {string.Join(", ", expectedResult)}");
            Assert.Equal(expectedResult, Intervals.SummaryRanges(nums));
        }
    }
}
