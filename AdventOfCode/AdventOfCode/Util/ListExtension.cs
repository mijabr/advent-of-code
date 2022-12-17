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

        public static List<List<T>> OrderedCombinations<T>(this List<T> items)
        {
            var orderedItems = new List<List<T>>() { new List<T>() };

            orderedItems = AddItem(orderedItems, items.ToArray());

            return orderedItems;
        }

        private static List<List<T>> AddItem<T>(List<List<T>> combos, T[] items)
        {
            var nextCombos = new List<List<T>>();

            foreach (var combo in combos)
            {
                var remainingItems = items.Except(combo);
                foreach (var item in remainingItems)
                {
                    var next = combo.ToList();
                    next.Add(item);
                    nextCombos.Add(next);
                }
            }

            if (nextCombos[0].Count < items.Length)
            {
                nextCombos = AddItem(nextCombos, items);
            }

            return nextCombos;
        }
    }
}
