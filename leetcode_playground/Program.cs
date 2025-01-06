using leetcode_playground;
using leetcode_playground.HelperClasses;

namespace Solution
{

    public static class Solution
    {
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

        public static int SingleNumber(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                    dict.Remove(nums[i]);
                else
                    dict.Add(nums[i], nums[i]);
            }
            foreach (var i in dict.Keys) return i;
            return int.MaxValue;
        }

        public static void ReverseString(char[] s)
        {
            int length = s.Length - 1;
            for (int i = 0; i < length / 2; i++)
            {
                char tmpa = s[length - i];
                s[length - i] = s[i];
                s[i] = tmpa;
            }
        }

        public static string ReverseVowels(string s)
        {
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            char[] word = s.ToCharArray();
            int length = s.Length - 1;
            int m = length / 2;
            int left = 0, right = 0;

            while (length - right >= left)
            {
                if (vowels.Contains(word[length - right]))
                {
                    if (vowels.Contains(word[left]))
                    {
                        char tmp = word[length - right];
                        word[length - right] = word[left];
                        word[left] = tmp;
                        right++;
                        left++;
                    }
                    else
                    {
                        left++;
                    }
                }
                else
                {
                    right++;
                }
            }

            return new string(word);
        }



        public static bool IsPalindrome(string s)
        {
            char[] charArr = s.ToCharArray();
            int l = 0, r = charArr.Length - 1;
            while (l < r)
            {
                if (!char.IsLetterOrDigit(charArr[l]))
                {
                    l++;
                }
                else if (!char.IsLetterOrDigit(charArr[r]))
                {
                    r--;
                }
                else if (char.ToLower(charArr[l]) != char.ToLower(charArr[r]))
                {
                    return false;
                }
                else
                {
                    l++;
                    r--;
                }

                Console.WriteLine(string.Format("Compare l {0} r {1}", charArr[l], charArr[r]));
            }

            return true;
        }

        /// <summary>
        /// 3. Longest Substring Without Repeating Characters
        /// </summary>
        public static int LengthOfLongestSubstring(string s)
        {
            Dictionary<int, char> substring = new Dictionary<int, char>();
            if (s.Length == 0) return 0;
            int result = 1;

            for (int i = 0; i < s.Length; i++)
            {
                if (substring.ContainsValue(s[i]))
                {
                    result = result > substring.Count ? result : substring.Count;
                    i = substring.FirstOrDefault(x => x.Value == s[i]).Key;
                    substring.Clear();
                }
                else
                {
                    substring[i] = s[i];
                }
            }

            return result;
        }

        public static IList<string> GenerateParenthesis(int n)
        {
            throw new NotImplementedException();
        }

        public static int[] DailyTemperatures(int[] temperatures)
        {
            int[] result = new int[temperatures.Length];
            Stack<(int temperature, int day)> stackValue = new Stack<(int, int)>();

            stackValue.Push((temperatures[temperatures.Length - 1], temperatures.Length));

            for (int curr = temperatures.Length - 2; curr >= 0; curr--)
            {
                int days = 1;

                while (stackValue.Count > 0 && temperatures[curr] >= stackValue.Peek().temperature)
                {
                    var prev = stackValue.Pop();
                    days += prev.day;
                }

                if (stackValue.Count > 0)
                {
                    result[curr] = days;
                }

                stackValue.Push((temperatures[curr], days));
            }

            return result;
        }
        public static int CarFleet(int target, int[] position, int[] speed)
        {
            int fleet = 1;
            Array.Sort(position, speed, Comparer<int>.Create((b, a) => a - b));
            for (int i = 0; i < position.Length - 1; i++)
            {
                if (speed[i] == 0) continue;
                if (speed[i + 1] == 0)
                {
                    fleet++;
                    continue;
                }
                double x = (double)(target - position[i]) / speed[i];
                double y = (double)(target - position[i + 1]) / speed[i + 1];

                if (x < y)
                {
                    fleet++;
                }
                else
                {
                    position[i + 1] = position[i];
                    speed[i + 1] = speed[i];
                }
            }
            return fleet;
        }

        public static int MinEatingSpeed(int[] piles, int h)
        {
            int result = piles.Max();
            int L = 1, R = piles.Max();
            while (L <= R)
            {
                long eatTime = 0;
                int M = L + ((R - L) / 2);
                foreach (int pile in piles)
                {
                    eatTime += (int)Math.Ceiling(pile / (double)M);
                }

                if (eatTime <= h)
                {
                    result = Math.Min(result, M);
                    R = M - 1;
                }
                else
                {
                    L = M + 1;
                }
            }
            return result;
        }

        public static void ReorderList(ListNode head)
        {
            int length = 0;
            ListNode curr = head;
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();

            while (curr != null)
            {
                stack.Push(curr.val);
                queue.Enqueue(curr.val);
                curr = curr.next;
                length++;
            }

            curr = head;
            int counter = 0;
            curr.val = queue.Dequeue();
            curr = curr.next;
            while (counter + 1 < length)
            {
                if (counter % 2 != 0)
                {
                    curr.val = queue.Dequeue();
                }
                else
                {
                    curr.val = stack.Pop();
                }
                curr = curr.next;
                counter++;
            }

        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode curr = head;
            ListNode start = head;
            int length = 1, counter = 1;
            while (curr.next != null)
            {
                length++;
                curr = curr.next;
            }
            if (length <= n)
            {
                start.val = start.next.val;
                start = start.next;
            }
            curr = start;

            while (curr != null)
            {
                if (length - n == counter)
                {
                    curr.next = curr.next.next != null ? curr.next.next : null;
                }
                curr = curr.next;
                counter++;
            }

            return length == 1 ? null : start;
        }
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode sumList = new ListNode();
            ListNode current = sumList;
            int carry = 0, sum = 0;
            while (l1 != null || l2 != null || carry == 1)
            {
                int v1 = l1 == null ? 0 : l1.val;
                int v2 = l2 == null ? 0 : l2.val;

                sum = v1 + v2 + carry;
                carry = sum > 9 ? 1 : 0;
                sum = sum % 10;
                current.next = new ListNode(sum);
                current = current.next;
                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;
            }
            return sumList.next;
        }

        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode current = null;
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                current = queue.Dequeue();
                TreeNode tmp = current.left;

                current.left = current.right;
                current.right = tmp;

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }
                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }
            }
            return root;
        }

        public static int LastStoneWeight(int[] stones)
        {
            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
            foreach (int stone in stones)
            {
                priorityQueue.Enqueue(stone, 0 - stone);
            }

            while (priorityQueue.Count > 1)
            {
                int newStone = priorityQueue.Dequeue() - priorityQueue.Dequeue();

                if (newStone > 0)
                {
                    priorityQueue.Enqueue(newStone, 0 - newStone);
                }
            }

            return priorityQueue.Count > 0 ? priorityQueue.Dequeue() : 0;
        }

        public static int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();

            foreach (int num in nums)
            {
                priorityQueue.Enqueue(num, 0 - num);
            }
            int counter = 1;
            while (counter < k)
            {
                priorityQueue.Dequeue();
                counter++;
            }
            return priorityQueue.Dequeue();
        }


        public static int MinCostClimbingStairs(int[] cost)
        {
            for (var i = 2; i < cost.Length; i++)
            {
                cost[i] += Math.Min(cost[i - 1], cost[i - 2]);
            }
            return Math.Min(cost[cost.Length - 1], cost[cost.Length - 2]);
        }

        public static int[] CountBits(int n)
        {
            int[] bits = new int[n];
            uint bit = 0b_0;
            for (int i = 0; i < n; i++)
            {
                bits[i] = Convert.ToString(bit, toBase: 2).Count(x => x == '1');
                bit++;
            }
            return bits;
        }

        public static void Main()
        {

            int[][] testNumbers1 = new int[][]
            {
                new int[] { 4, 3, 2, -1 },
                new int[] { 3, 2, 1, -1 },
                new int[] { 1,1,-1,-2},
                new int[] { -1, -1, -2, -3 }
            };
            int[][] testNumbers2 = new int[][]
            {
                new int[] { 3,2 },
                new int[] { 1,0 }
            };
            int[][] testNumbers3 = new int[][]
            {
                new int[] { 3,-1,-3,-3,-3 },
                new int[] { 2,-2,-3,-3,-3 },
                new int[] { 1,-2,-3,-3,-3},
                new int[] { 0, -3, -3, -3, -3 }
            };
            Console.WriteLine(Arrays.RemoveDuplicatesTwo(new int[] { 1, 1, 1, 1, 2, 2, 3 }));
        }
    }
}