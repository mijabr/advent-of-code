using AdventOfCode.Util;

namespace AdventOfCodeTests.Year2022
{
    public class FileSystem
    {
        public Dir Root { get; set; } = new Dir("/");

        private Dir Current { get; set; }

        public FileSystem(string input)
        {
            Current = Root;
            var lines = input.Split("\r\n");

            foreach (var line in lines)
            {
                if (line.StartsWith("$ cd "))
                {
                    ChangeDir(line[5..]);
                }
                else if (line.StartsWith("$ ls"))
                {
                }
                else if (line.StartsWith("dir"))
                {
                    Current.Children.Add(new Dir(line[4..], Current));
                }
                else
                {
                    Current.Children.Add(new File(line[(line.IndexOf(' ') + 1)..], Current, line.Parse<int>()));
                }
            }
        }

        private void ChangeDir(string dir)
        {
            if (dir == "/")
            {
                Current = Root;
            }
            else if (dir == "..")
            {
                Current = Current.Parent ?? Root;
            }
            else
            {
                Current = (Dir?)Current.Children.First(i => i is Dir && i.Name == dir) ?? Root;
            }
        }

        public int FindSumOfAtMost(int max)
        {
            var items = new List<Item>();
            Root.GetItems(items, i => i is Dir && i.Size <= max);
            return items.Sum(i => i.Size);
        }

        public int FindDirToDelete()
        {
            var maxSize = 70000000;
            var needed = 30000000;
            var used = Root.Size;
            var free = maxSize - used;
            var toFree = needed - free;
            var items = new List<Item>();
            Root.GetItems(items, i => i is Dir && i.Size >= toFree);
            return items.Min(i => i.Size);
        }
    }

    public class File : Item
    {
        public File(string name, Dir? parent, int size) : base(name, parent, size)
        {
        }
    }

    public class Dir : Item
    {
        public Dir(string name, Dir? parent = null) : base(name, parent)
        {
        }

        public override int Size => Children.Sum(c => c.Size);
    }

    public abstract class Item
    {
        public Item(string name, Dir? parent = null, int size = 0)
        {
            Name = name;
            Parent = parent;
            Size = size;
        }

        public string Name { get; set; }
        public virtual int Size { get; set; }
        public Dir? Parent { get; set; }
        public List<Item> Children { get; set; } = new();
        public void GetItems(List<Item> items, Func<Item, bool> selector)
        {
            if (selector(this))
            {
                items.Add(this);
            }

            Children.ForEach(c => c.GetItems(items, selector));
        }

        public override string ToString() => $"{Name} ({(this is Dir ? "dir" : "file")}, size={Size})";
    }
}
