using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sort
{
    public class Entry
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsValid => Directory.Exists(Path);
    }
    public class UserPathData
    {
        public List<Entry> Entries { get; set; } = new List<Entry>();

        public bool IsEmtpy() => Entries.Count == 0;

        public int Items() => Entries.Count;

        public void AddEntry(string dirName, string dirPath)
        {
            Entry Item = Entries.Find(e => e.Name == dirName);
            if (Item != null)
            {
                Console.WriteLine($"[*] Path Already exists, updating previous data [*]");
                Item.Name = dirPath;
            }
            else
            {
                Entries.Add(new Entry { Name = dirName, Path = dirPath }); // Add new entry
            }
        }
        public void RemoveInvalidEntries() => Entries.RemoveAll(Items => Items.IsValid == false);

        public string GetPath(string baseName)
        {
            Entry Selection = Entries.Find(Entries => Entries.Name == baseName);
            if (Selection == null) return null;
            return Selection.Path;
        }
        public List<string> FetchBaseNames() => Entries.Select(Entries => Entries.Name).ToList();
    }
}
