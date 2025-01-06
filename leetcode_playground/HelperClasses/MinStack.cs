namespace leetcode_playground.HelperClasses
{
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
}