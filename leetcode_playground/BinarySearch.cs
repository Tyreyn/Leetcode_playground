using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_playground
{
    public class BinarySearch
    {

        /// <summary>
        /// 1351. Count Negative Numbers in a Sorted Matrix
        /// </summary>
        public static int CountNegatives(int[][] grid)
        {
            int cnt = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] < 0)
                    {
                        cnt = cnt + grid[i].Length - j;
                        break;
                    }
                }
            }
            return cnt;
        }

        /// <summary>
        /// 2089. Find Target Indices After Sorting Array.
        /// </summary>
        public static IList<int> TargetIndices(int[] nums, int target)
        {
            List<int> result = new List<int>();
            Array.Sort(nums);
            int left = 0, middle = 0, right = nums.Length - 1;
            while (left <= right)
            {
                middle = left + (right - left) / 2;
                if (nums[middle] < target)
                {
                    left = middle + 1;
                }
                else if (nums[middle] > target)
                {
                    right = middle - 1;
                }
                else
                {
                    int k = middle;
                    while (k > -1 && nums[k] == target)
                    {
                        result.Add(k);
                        k -= 1;
                    }
                    middle += 1;

                    while (middle < nums.Length && nums[middle] == target)
                    {
                        result.Add(middle);
                        middle++;
                    }
                    result.Sort();
                    return result;

                }
            }
            result.Sort();
            return result;
        }

        /// <summary>
        /// 1385. Find the Distance Value Between Two Arrays
        /// </summary>
        public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            int result = 0;
            Array.Sort(arr2);
            for (int i = 0; i < arr1.Length; i++)
            {
                int left = 0;
                int right = arr2.Length - 1;
                bool flag = true;

                while (left <= right)
                {
                    int mid = (left + right) / 2;

                    if (Math.Abs(arr1[i] - arr2[mid]) <= d)
                    {
                        flag = false;
                        break;
                    }
                    else if (arr1[i] > arr2[mid])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                if (flag)
                    result++;
            }
            return result;
        }

        /// <summary>
        /// 1268. Search Suggestions System
        /// </summary>
        public static IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            return null;
        }

        /// <summary>
        /// 2389. Longest Subsequence With Limited Sum
        /// </summary>
        public static int[] AnswerQueries(int[] nums, int[] queries)
        {
            int k = nums.Length;
            int l = queries.Length;
            int[] ans = new int[l];
            Array.Sort(nums);
            int sum = 0;
            foreach (var n in nums)
                sum += n;
            for (int i = 0; i < l; i++)
            {
                int j = k - 1;
                int currentSum = sum;
                while (j >= 0 && currentSum > queries[i])
                {
                    currentSum -= nums[j];
                    j--;
                }
                ans[i] = j + 1;
            }
            return ans;
        }

    }
}
