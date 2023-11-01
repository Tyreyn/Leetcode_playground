using leetcode_playground;

namespace Solution
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
    public class KthLargest
    {
        PriorityQueue<int, int> data = new PriorityQueue<int, int>();
        int k;

        public KthLargest(int k, int[] nums)
        {
            this.k = k;
            foreach (var num in nums)
                Add(num);
        }

        public int Add(int val)
        {
            data.Enqueue(val, val);

            if (data.Count > k)
                data.Dequeue();

            return data.Peek();
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class MinStack
    {
        private Stack<int> stack = new Stack<int>();
        private Stack<int> minStack = new Stack<int>();
        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int val)
        {
            stack.Push(val);
            int min = Math.Min(val, minStack.Count != 0 ? minStack.Peek() : val);
            minStack.Push(min);
        }

        public void Pop()
        {
            minStack.Pop();
            stack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }


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

        public static int[] TwoSum(int[] numbers, int target)
        {
            int[] result;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target) return new int[] { ++i, ++j };
                }
            }
            return null;
        }

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
        //public static int Search(int[] nums, int target)
        //{
        //    int L = 0, R = nums.Length - 1;
        //    while (L <= R)
        //    {
        //        int M = L + ((R - L) / 2);
        //        if (nums[M] < target)
        //        {
        //            L = M;
        //        }
        //        else if (nums[M] > target)
        //        {
        //            R = M;
        //        }
        //        else
        //        {
        //            return M;
        //        }
        //    }
        //    return L;
        //}

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

        public static int Search(int[] nums, int target)
        {
            int L = 0, R = nums.Length - 1;
            int result = -1;
            while (L <= R)
            {
                if (nums[L] == target)
                {
                    return L;
                }

                int M = (R + L) / 2;
                if (nums[M] >= nums[L])
                {
                    if (nums[M] > target)
                    {
                        L = M + 1;
                    }
                    else
                    {
                        R = M;
                    }
                }
            }
            return -1;
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
            /*
            char[][] board = new char[][]
            {new  char[]{ '5', '3', '.', '.', '7', '.', '.', '.', '.' }
            ,new  char[]{'6', '.', '.', '1', '9', '5', '.', '.', '.'}
            ,new  char[]{'.', '9', '8', '.', '.', '.', '.', '6', '.'}
            ,new  char[]{'8', '.', '.', '.', '6', '.', '.', '.', '3'}
            ,new  char[]{'4', '.', '.', '8', '.', '3', '.', '.', '1'}
            ,new  char[]{'7', '.', '.', '.', '2', '.', '.', '.', '6'}
            ,new  char[]{'.', '6', '.', '.', '.', '.', '2', '8', '.'}
            ,new  char[]{'.', '.', '.', '4', '1', '9', '.', '.', '5'}
            ,new  char[]{'.', '.', '.', '.', '8', '.', '.', '7', '9'} };

            int[][] matrix = new int[][]
            {
                new int[] {1,3,5,7,},
                new int[] {10,11,16,20},
                new int[] {23,30,34,60}
            };

            ListNode l1 = new ListNode(1, null);
            l1.next = new ListNode(2, null);
            l1.next.next = new ListNode(3, null);
            l1.next.next.next = new ListNode(4, null);
            l1.next.next.next.next = new ListNode(5, null);
            ListNode l2 = new ListNode(1, null);
            l2.next = new ListNode(2, null);
            l2.next.next = new ListNode(3, null);
            l2.next.next.next = new ListNode(4, null);
            l2.next.next.next.next = new ListNode(5, null);

            TreeNode root = new TreeNode(
                3,
                new TreeNode(9),
                new TreeNode(20, new TreeNode(15), new TreeNode(7)));

            KthLargest kthLargest = new KthLargest(3, new int[] { 4, 5, 8, 2 });
            kthLargest.Add(3);   // return 4
            kthLargest.Add(5);   // return 5
            kthLargest.Add(10);  // return 5
            kthLargest.Add(9);   // return 8
            kthLargest.Add(4);   // return 8

            var result = CountBits(4);
            foreach (var res in result)
            {
                Console.WriteLine(res);
            }
            */

            Console.WriteLine(Sliding_Window.FindMaxAverage(new int[] { 1, 12, -5, -6, 50, 3 }, 4));
        }
    }
}