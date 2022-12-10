namespace AdventOfCode.Util
{
    public static class ListExtension
    {
        public static Stack<T> ToStack<T>(this IEnumerable<T> list)
        {
            var stack = new Stack<T>();
            foreach (var item in list)
            {
                stack.Push(item);
            }

            return stack;
        }
    }
}
