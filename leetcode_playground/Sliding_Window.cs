using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_playground
{
    public class Sliding_Window
    {
        /// <summary>
        /// 643. Maximum Average Subarray I
        /// </summary>
        public static double FindMaxAverage(int[] nums, int k)
        {
            if (nums.Length == 1) return nums[0];
            double result = 0;
            int leftCursor = 0, rightCursor = 0, sum = 0;
            while (leftCursor + k <= nums.Length)
            {
                sum += nums[rightCursor++];
                if (rightCursor >= leftCursor + k)
                {
                    result = result < ((double)sum / (double)k) ? ((double)sum / (double)k) : result;
                    sum -= nums[leftCursor++];
                }
            }

            return result;
        }

        /// <summary>
        /// 219. Contains Duplicate II.
        /// </summary>
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            int leftCursor = 0, rightCursor = 1;
            int lenght = int.MaxValue;

            while (leftCursor < nums.Length - 1)
            {
                if (nums[leftCursor] == nums[rightCursor])
                {
                    lenght = lenght > rightCursor - leftCursor
                        ? rightCursor - leftCursor
                        : lenght;
                    leftCursor++;
                    rightCursor = leftCursor + 1;
                }
                else
                {
                    rightCursor++;
                    if (rightCursor >= nums.Length)
                    {
                        leftCursor++;
                        rightCursor = leftCursor + 1;
                    }
                }
            }
            return lenght <= k ? true : false;
        }

        /// <summary>
        /// 76. Minimum Window Substring
        /// </summary>
        public static string MinWindow(string s, string t)
        {
            if (t.Length == 1 && s.Contains(t)) return t;
            if (t == s) return t;
            if (t.Length > s.Length) return string.Empty;
            string result = string.Empty;
            string toCheck;
            int min = s.Length;
            Dictionary<int, string> dict = new Dictionary<int, string>();
            bool found;
            for (int left = 0; left < s.Length; left++)
            {
                toCheck = t;
                found = false;
                List<char> list = new List<char>();
                int right = left;
                while (!found && right <= s.Length && (s.Length - left) > t.Length)
                {
                    if (toCheck == string.Empty)
                    {
                        dict[left] = string.Join("", list);
                        found = true;
                    }
                    else
                    {
                        if (toCheck.Contains(s[right]))
                        {
                            int index = toCheck.IndexOf(s[right]);
                            toCheck = toCheck.Remove(index, 1);
                        }
                        list.Add(s[right]);
                        right++;
                    }
                }
            }
            foreach (KeyValuePair<int, string> pair in dict)
            {
                Console.Write(string.Format("\n Grupa: {0}, substring: {1}", pair.Key, pair.Value));
                if (min > pair.Value.Length)
                {
                    result = pair.Value;
                    min = pair.Value.Length;
                }
            }
            return result;
        }

        /// <summary>
        /// 209. Minimum Size Subarray Sum.
        /// </summary>
        public static int MinSubArrayLen(int target, int[] nums)
        {
            int leftCursor = 0, rightCursor = 0;
            int sum = 0, lenght = nums.Length;
            bool found = false;
            while (rightCursor <= nums.Length)
            {
                if (sum >= target)
                {
                    lenght = lenght > rightCursor - leftCursor ? rightCursor - leftCursor : lenght;

                    sum -= nums[leftCursor++];
                    found = true;
                }
                else
                {

                    sum += rightCursor + 1 > nums.Length ? 0 : nums[rightCursor];
                    rightCursor++;
                }
            }

            return found ? lenght : 0;
        }

        /// <summary>
        /// 239. Sliding Window Maximum.
        /// </summary>
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            var output = new List<int>();
            LinkedList<int> queue = new();
            int left = 0, right = 0;

            while (right < nums.Length)
            {
                // pop smaller values from queue
                while (queue.Count > 0 && nums[queue.Last.Value] < nums[right])
                    queue.RemoveLast();
                queue.AddLast(right);

                // remove left val from the window
                if (left > queue.First.Value)
                    queue.RemoveFirst();

                if (right + 1 >= k)
                {
                    output.Add(nums[queue.First.Value]);
                    left++;
                }

                right++;
            }

            return output.ToArray();
        }

        /// <summary>
        /// 424. Longest Repeating Character Replacement.
        /// </summary>
        public static int CharacterReplacement(string s, int k)
        {
            int left = 0, maxLength = 0;
            int mostFrequentLetterCount = 0; // Count of most frequent letter in the window
            int[] charCounts = new int[26]; // Counts per letter

            for (int right = 0; right < s.Length; right++)
            {
                charCounts[s[right] - 'A']++;
                mostFrequentLetterCount = Math.Max(mostFrequentLetterCount, charCounts[s[right] - 'A']);

                int lettersToChange = (right - left + 1) - mostFrequentLetterCount;
                if (lettersToChange > k)
                { // Window is invalid, decrease char count and move left pointer
                    charCounts[s[left] - 'A']--;
                    left++;
                }

                maxLength = Math.Max(maxLength, (right - left + 1));
            }
            return maxLength;
        }

        /// <summary>
        /// 567. Permutation in String
        /// </summary>
        public static bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length) return false;

            var s1Count = Enumerable.Repeat(0, 26).ToArray();
            var s2Count = Enumerable.Repeat(0, 26).ToArray();

            for (var i = 0; i < s1.Length; i++)
            {
                s1Count[s1[i] - 'a']++;
                s2Count[s2[i] - 'a']++;
            }

            var matches = 0;
            for (var i = 0; i < 26; i++)
            {
                if (s1Count[i] == s2Count[i]) matches++;
            }

            var left = 0;
            for (var right = s1.Length; right < s2.Length; right++)
            {
                if (matches == 26) return true;

                var index = s2[right] - 'a';
                s2Count[index]++;
                if (s1Count[index] == s2Count[index])
                {
                    matches++;
                }
                else if (s1Count[index] + 1 == s2Count[index])
                {
                    matches--;
                }

                index = s2[left] - 'a';
                s2Count[index]--;
                if (s1Count[index] == s2Count[index])
                {
                    matches++;
                }
                else if (s1Count[index] - 1 == s2Count[index])
                {
                    matches--;
                }

                left++;
            }

            return matches == 26;
        }

        /// <summary>
        /// 2269. Find the K-Beauty of a Number.
        /// </summary>
        public static int DivisorSubstrings(int num, int k)
        {
            var n = num.ToString();
            var count = 0;

            for (var i = k - 1; i < n.Length; i++)
            {
                var number = int.Parse(n.Substring(i - k + 1, k));
                if (number != 0 && num % number == 0) count++;
            }

            return count;
        }
    }
}
