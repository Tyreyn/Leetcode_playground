using leetcode_playground.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_playground
{
    public class Arrays
    {
        /// <summary>
        /// 33. Search in Rotated Sorted Array.
        /// </summary>
        public static int Search(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;

            while (low <= high)
            {
                var mid = (low + high) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[low] <= nums[mid])
                {
                    if (target > nums[mid] || target < nums[low])
                        low = mid + 1;
                    else high = mid - 1;
                }
                else
                {
                    if (target < nums[mid] || target > nums[high])
                        high = mid - 1;
                    else low = mid + 1;
                }
            }


            return -1;
        }

        /// <summary>
        /// 36. Valid Sudoku.
        /// </summary>
        public static bool IsValidSudoku(char[][] board)
        {
            var rows = new Dictionary<int, HashSet<char>>();
            var cols = new Dictionary<int, HashSet<char>>();
            var squares = new Dictionary<(int, int), HashSet<char>>();

            for (var r = 0; r < 9; r++)
            {
                rows[r] = new HashSet<char>();
                for (var c = 0; c < 9; c++)
                {
                    if (!cols.ContainsKey(c)) cols[c] = new HashSet<char>();
                    if (!squares.ContainsKey((r / 3, c / 3))) squares[(r / 3, c / 3)] = new HashSet<char>();

                    if (board[r][c] != 0
                        && (!rows[r].Add(board[r][c])
                        || !cols[c].Add(board[r][c])
                        || !squares[(r / 3, c / 3)].Add(board[r][c])))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 42. Trapping Rain Water.
        /// </summary>
        public static int Trap(int[] height)
        {
            if (height is null || height.Length == 0) return 0;

            int left = 0, right = height.Length - 1;
            int leftMax = height[left], rightMax = height[right];
            var result = 0;

            while (left < right)
            {
                if (leftMax < rightMax)
                {
                    left++;
                    leftMax = Math.Max(leftMax, height[left]);
                    result += leftMax - height[left];
                }
                else
                {
                    right--;
                    rightMax = Math.Max(rightMax, height[right]);
                    result += rightMax - height[right];
                }
            }

            return result;
        }

        /// <summary>
        /// 74. Search a 2D Matrix.
        /// </summary>
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            int x = 0;
            while (x <= matrix.Length - 1)
            {
                Console.WriteLine(matrix[x][matrix[x].Length - 1]);
                if (matrix[x][matrix[x].Length - 1] > target
                    && matrix[x][0] < target)
                {
                    int L = 0, R = matrix[x].Length - 1;
                    while (L <= R)
                    {
                        int M = L + ((R - L) / 2);
                        if (matrix[x][M] < target)
                        {
                            L = M + 1;
                        }
                        else if (matrix[x][M] > target)
                        {
                            R = M - 1;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else if ((matrix[x][matrix[x].Length - 1] == target
                    || matrix[x][0] == target))
                {
                    return true;
                }
                x++;
            }
            return false;
        }

        /// <summary>
        /// 84. Largest Rectangle in Histogram.
        /// </summary>
        public static int LargestRectangleArea(int[] heights)
        {
            Stack<(int pos, int height)> rect = new Stack<(int pos, int height)>();
            int result = 0;

            for (int i = 0; i <= heights.Length; i++)
            {
                var height = i < heights.Length ? heights[i] : 0;
                while (rect.Count > 0 && rect.Peek().height > height)
                {
                    var curr = rect.Pop();
                    var prevIndex = rect.Count == 0 ? -1 : rect.Peek().pos;
                    int tempResult = curr.height * (i - prevIndex - 1);
                    result = Math.Max(result, tempResult);
                }

                if (i < heights.Length)
                    rect.Push((i, heights[i]));
            }
            return result;
        }

        /// <summary>
        /// 128. Longest Consecutive Sequence
        /// </summary>
        public static int LongestConsecutive(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;

            var set = new HashSet<int>(nums);
            var longest = 0;
            foreach (var n in set)
            {
                if (!set.Contains(n - 1))
                {
                    var length = 0;
                    while (set.Contains(n + length))
                    {
                        length++;
                        longest = Math.Max(longest, length);
                    }
                }
            }

            return longest;
        }

        /// <summary>
        /// 15. 3Sum.
        /// </summary>
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();

            int left, right;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                left = i + 1;
                right = nums.Length - 1;
                while (left < right)
                {
                    if (nums[i] + nums[left] + nums[right] > 0)
                    {
                        right--;
                    }
                    else if (nums[i] + nums[left] + nums[right] < 0)
                    {
                        left++;
                    }
                    else
                    {
                        res.Add(new List<int> { nums[i], nums[left], nums[right] });
                        left++;
                        while (nums[left] == nums[left - 1] && left < right)
                        {
                            left++;
                        }
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 11. Container With Most Water.
        /// </summary>
        public static int MaxArea(int[] height)
        {
            int maxHeight = 0, result = 0;
            int left = 0, right = height.Length - 1;

            while (left < right)
            {
                maxHeight = height[left] > height[right] ? height[right] : height[left];
                if (result < (right - left) * maxHeight)
                {
                    result = (right - left) * maxHeight;
                }

                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return result;
        }

        /// <summary>
        /// 167. Two Sum II - Input Array Is Sorted.
        /// </summary>
        public static int[] TwoSum2(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target) return new int[] { ++i, ++j };
                }
            }
            return null;
        }

        /// <summary>
        /// 169. Majority Element.
        /// </summary>
        public static int MajorityElement(int[] nums)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int result = 0;
            foreach (int num in nums)
            {
                if (!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 1);
                }
                else
                {
                    numbers[num]++;
                }
                if (numbers[num] > (nums.Length / 2)) result = num;
            }
            return result;
        }

        /// <summary>
        /// 150. Evaluate Reverse Polish Notation.
        /// </summary>
        public static int EvalRPN(string[] tokens)
        {
            Stack<int> input = new Stack<int>();

            foreach (string token in tokens)
            {
                int number = 0;
                var isNumber = int.TryParse(token, out number);
                if (isNumber)
                {
                    input.Push(number);
                }
                else
                {
                    int a = input.Pop();
                    int b = input.Pop();
                    switch (token)
                    {

                        case "*":
                            input.Push(b * a);
                            break;
                        case "-":
                            input.Push(b - a);
                            break;
                        case "+":
                            input.Push(b + a);
                            break;
                        case "/":
                            input.Push(b / a);
                            break;
                    }
                }
            }
            return input.Pop();
        }

        /// <summary>
        /// 153. Find Minimum in Rotated Sorted Array.
        /// </summary>
        public static int FindMin(int[] nums)
        {
            int L = 0, R = nums.Length - 1;
            int result = nums[L];

            while (L <= R)
            {
                if (nums[L] <= nums[R])
                {
                    return nums[L];
                }

                int M = (R + L) / 2;
                if (nums[M] >= nums[L])
                {
                    L = M + 1;
                }
                else
                {
                    R = M;
                }
            }

            return 0;
        }

        /// <summary>
        /// 136. Single Number.
        /// </summary>
        public static int SingleNumber(int[] nums)
        {
            var n = 0;
            foreach (var i in nums) n ^= i;
            return n;
        }

        /// <summary>
        /// 121. Best Time to Buy and Sell Stock
        /// </summary>
        public static int MaxProfit(int[] prices)
        {
            int buy = 0, profit = 0, maxProfit = 0, sell = 1;

            while (sell < prices.Length)
            {
                profit = prices[sell] - prices[buy];
                if (profit <= 0)
                {
                    buy = sell;
                }
                else
                {
                    if (profit > maxProfit) maxProfit = profit;
                }
                sell++;
            }
            return maxProfit;
        }

        /// <summary>
        /// 122. Best Time to Buy and Sell Stock II
        /// </summary>
        public static int MaxProfit2(int[] prices)
        {
            int max = 0;
            int start = prices[0];
            int len = prices.Length;
            for (int i = 1; i < len; i++)
            {
                if (start < prices[i])
                {
                    max += prices[i] - start;
                }
                start = prices[i];
            }
            return max;
        }

        /// <summary>
        /// 55. Jump Game
        /// </summary>
        public static bool CanJump(int[] nums)
        {
            int nearestJump = nums.Length - 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (i + nums[i] >= nearestJump)
                {
                    nearestJump = i;
                }
            }
            return nearestJump == 0;
        }

        /// <summary>
        /// 45. Jump Game II
        /// </summary>
        public static int Jump(int[] nums)
        {
            int jumps = 0, farthest = 0, end = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                farthest = Math.Max(farthest, i + nums[i]);
                if (i == end)
                {
                    jumps++;
                    end = farthest;
                }
            }

            return jumps;
        }

        /// <summary>
        /// 274. H-Index
        /// </summary>
        public static int HIndex(int[] citations)
        {

            int n = citations.Length;
            int[] buckets = new int[n + 1];
            foreach (int c in citations)
            {
                if (c >= n)
                {
                    buckets[n]++;
                }
                else
                {
                    buckets[c]++;
                }
            }
            int count = 0;
            for (int i = n; i >= 0; i--)
            {
                count += buckets[i];
                if (count >= i) return i;
            }
            return 0;

            //int hIndex = 0;
            //if(citations.Length == 1) {
            //    return citations[0] > 0 ? 1 : 0;
            //}

            //for(int i = 0; i < citations.Length;i++)
            //{
            //    int cnt = 0;
            //    for (int j = 0; j < citations.Length; j++)
            //    {
            //        if (citations[i] <= citations[j])
            //        {
            //            cnt++;
            //        }
            //    }
            //    if (cnt >= citations[i] && hIndex < citations[i])
            //    {
            //        hIndex = citations[i];
            //    }else if (cnt <= citations[i] && hIndex < cnt)
            //    {
            //        hIndex = cnt;
            //    }
            //}
            //return hIndex;
        }

        /// <summary>
        /// 35. Search Insert Position
        /// </summary>
        public static int SearchInsert(int[] nums, int target)
        {
            int index = 0;
            foreach (int num in nums)
            {
                if (num >= target)
                    return index;
                index++;
            }
            return index;
        }

        /// <summary>
        /// 13. Roman to Integer
        /// </summary>
        public static int RomanToInt(string s)
        {
            int result = 0, sLength = s.Length;
            for (int i = 1; i <= sLength; i++)
            {
                int firstNumber = RomanNumerals.RomanToNumerals[s[i - 1]];
                int secondNumber = i < sLength ? RomanNumerals.RomanToNumerals[s[i]] : 0;
                if (firstNumber < secondNumber)
                {
                    result += secondNumber - firstNumber;
                    i++;
                }
                else
                {
                    result += firstNumber;
                }
            }
            return result;
        }

        /// <summary>
        /// 12. Integer to Roman
        /// </summary>
        public static string IntToRoman(int num)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (num > 0)
            {
                foreach (KeyValuePair<string, int> keyValuePair in RomanNumerals.NumeralsToRoman)
                {
                    if (num >= keyValuePair.Value)
                    {
                        num -= keyValuePair.Value;
                        stringBuilder.Append(keyValuePair.Key);
                        break;
                    }
                }
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 58. Length of Last Word
        /// </summary>
        public static int LengthOfLastWord(string s)
        {
            string[] words = s.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            int length = words.Length;
            int result = 0;
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            foreach (char c in words[length - 1])
            {
                result++;
            }
            return result;
        }

        /// <summary>
        /// 134. Gas Station
        /// </summary>
        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            if (gas.Sum() < cost.Sum()) return -1;

            int total = 0;
            int startIndex = 0;
            for (int index = 0; index < gas.Length; index++)
            {
                total += (gas[index] - cost[index]);

                if (total < 0)
                {
                    total = 0;
                    startIndex = index + 1;
                }
            }

            return startIndex;
        }

        /// <summary>
        /// 151. Reverse Words in a String
        /// </summary>
        public static string ReverseWords(string s)
        {
            string[] words = s.Split(' ')
                .Where(word => !string.IsNullOrEmpty(word))
                .ToArray();
            Array.Reverse(words);
            return string.Join(' ', words);
        }

        /// <summary>
        /// 6. Zigzag Conversion
        /// </summary>
        public static string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;
            bool back = false;
            int i = 0;
            string[] arr = new string[numRows];
            foreach (char c in s)
            {
                if (back)
                {
                    i--;
                    arr[i] += c;
                    if (i == 0)
                    {
                        i++;
                        back = false;
                    }
                }
                else
                {
                    arr[i] += c;
                    if (i == numRows - 1)
                    {
                        i--;
                        back = true;
                    }
                    i++;
                }
            }
            return string.Join(string.Empty, arr);
        }

        /// <summary>
        /// 68. Text Justification
        /// </summary>
        public static IList<string> FullJustify(string[] words, int maxWidth)
        {
            List<string> list = new List<string>();
            int wordsCount = 0, wordsLength = 0, i = 0, start = 0, inputLength = words.Length;
            bool foundRow = false;
            while(start < inputLength)
            {
                if (!foundRow)
                {
                    if (i < inputLength && words[i].Length + wordsLength + (wordsCount - 1) < maxWidth)
                    {
                        wordsCount++;
                        wordsLength += words[i].Length;
                        i++;
                    }
                    else
                    {
                        start = i - wordsCount;
                        foundRow = true;
                    }
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    int spaces = wordsCount - 1;
                    int freespace = maxWidth - wordsLength;
                    for (int j = 0; j < wordsCount; j++)
                    {
                        int padding = freespace;
                        if(i == inputLength)
                        {
                            padding = spaces != 0 ? 1 : freespace;
                        }
                        else
                        {
                            padding = spaces == 0 ? freespace : ((freespace - 1) / spaces) + 1;
                        }
                        string newWord = words[start + j];
                        stringBuilder.Append(newWord.PadRight(newWord.Length+padding));
                        spaces--;
                        freespace -= padding;
                    }
                    wordsCount = 0;
                    wordsLength = 0;
                    foundRow = false;
                    list.Add(stringBuilder.ToString());
                }
            }
            return list;
        }

        /// <summary>
        /// 27. Remove Element
        /// </summary>
        public static int RemoveElement(int[] nums, int val)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[result] = nums[i];
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// 1. Two Sum.
        /// </summary>
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < target)
                {
                    int tmp = target - nums[i];
                    if (result.ContainsKey(tmp)) return new int[] { result[tmp], i };
                    result[nums[i]] = i;
                }
            }

            return new int[] { };
        }

        /// <summary>
        /// 2917. Find the K-or of an Array
        /// </summary>
        public static int FindKOr(int[] nums, int k)
        {
            int ans = 0;
            int digit = 1;
            bool continueLooping = true;
            while (continueLooping)
            {
                continueLooping = false;
                int counter = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 1)
                        counter++;
                    nums[i] /= 2;
                    if (nums[i] > 0)
                        continueLooping = true;
                }
                if (counter >= k)
                    ans += digit;
                digit *= 2;
            }
            return ans;
        }

        /// <summary>
        /// 2909. Minimum Sum of Mountain Triplets II
        /// </summary>
        public static int MinimumSum(int[] nums)
        {
            int ans = Int32.MaxValue;

            int n = nums.Length;
            int[] minL = new int[n]; minL[0] = nums[0];
            for (int i = 1; i < n; i++)
                minL[i] = Math.Min(minL[i - 1], nums[i]);
            int[] minR = new int[n]; minR[n - 1] = nums[n - 1];
            for (int i = n - 2; i > -1; i--)
                minR[i] = Math.Min(minR[i + 1], nums[i]);

            for (int i = 1; i < n - 1; i++)
                if (nums[i] > minL[i - 1] && nums[i] > minR[i + 1])
                    ans = Math.Min(ans, nums[i] + minL[i - 1] + minR[i + 1]);

            if (ans == Int32.MaxValue) ans = -1;
            return ans;
        }

        /// <summary>
        /// 88. Merge Sorted Array
        /// </summary>
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            Array.Copy(nums2, 0, nums1, m, n);
            Array.Sort(nums1);
        }

        /// <summary>
        /// 26. Remove Duplicates from Sorted Array
        /// </summary>
        public static int RemoveDuplicates(int[] nums)
        {
            int i = 1;
            foreach (int n in nums)
            {
                if (nums[i - 1] != n) nums[i++] = n;
            }

            return i;
        }

        /// <summary>
        /// 189. Rotate Array
        /// </summary>
        public void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            if (nums.Length <= 1 || k == 0) return;
            Reverse(nums, 0, nums.Length - 1 - k);
            Reverse(nums, nums.Length - k, nums.Length - 1);
            Reverse(nums, 0, nums.Length - 1);
        }
        public void Reverse(int[] nums, int start, int end)
        {
            for (int i = 0; i <= (end - start) / 2; i++)
            {
                int tmp = nums[i + start];
                nums[i + start] = nums[end - i];
                nums[end - i] = tmp;
            }
        }

        /// <summary>
        /// 80. Remove Duplicates from Sorted Array II
        /// </summary>
        public static int RemoveDuplicatesTwo(int[] nums)
        {
            int biggestPair = int.MinValue;
            int j = 0;
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i - 1] == nums[i - 2]) biggestPair = nums[i - 1];
                while (j + i < nums.Length && nums[j + i] <= biggestPair)
                {
                    j++;
                }
                if (j + i < nums.Length && nums[j + i] > biggestPair)
                {
                    int temp = nums[i];
                    nums[i] = nums[j + i];
                    nums[j + i] = temp;
                }
                else
                {
                    return i;
                }
            }
            return nums.Length;
        }

        /// <summary>
        /// 392. Is Subsequence
        /// </summary>
        public static bool IsSubsequence(string s, string t)
        {
            if (s.Length > t.Length) return false;
            if (s.Length == 0) return true;
            int sCnt = 0;
            foreach (char c in t)
            {
                if ((sCnt >= s.Length))
                {
                    return true;
                }
                if (s[sCnt] == c) sCnt++;
            }
            return sCnt == s.Length ? true : false;
        }

        /// <summary>
        /// 135. Candy
        /// </summary>
        public static int Candy(int[] ratings)
        {
            int n = ratings.Length;
            int[] candies = new int[n];
            Array.Fill(candies, 1);

            for (int i = 1; i < n; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    candies[i] = candies[i - 1] + 1;
                }
            }

            for (int i = n - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                {
                    candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
                }
            }

            int ans = 0;
            foreach (int candy in candies)
            {
                ans += candy;
            }
            return ans;
        }   
    }
}
