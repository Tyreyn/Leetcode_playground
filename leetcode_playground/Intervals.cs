namespace leetcode_playground
{
    public static class Intervals
    {
        public static IList<string> SummaryRanges(int[] nums)
        {
            List<string> ranges = new List<string>();
            if (nums.Count() < 1) return ranges;
            const string rangeSymbol = "->";
            int startNum = nums[0], endNum = -1;
            foreach (int num in nums)
            {
                if (startNum == num)
                {
                    endNum = num;
                }
                else if (endNum + 1 == num)
                {
                    endNum = num;
                }
                else
                {
                    ranges.Add(startNum == endNum ? string.Format($"{startNum}") : string.Format($"{startNum}->{endNum}"));
                    startNum = num;
                    endNum = num;
                }
            }
            ranges.Add(startNum == endNum ? string.Format($"{startNum}") : string.Format($"{startNum}->{endNum}"));
            return ranges;
        }
    }
}
