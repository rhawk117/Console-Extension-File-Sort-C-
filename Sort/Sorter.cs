using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sort
{
    public class Sorter
    {
        public List<FileInfo> DirectoryFiles { get; set; }
        public List<string> UniqueExtensions { get; set; }
        public bool IsSortable => (UniqueExtensions.Count > 0 && DirectoryFiles.Count > 0);

        public string DirectoryPath { get; private set; }
        public Sorter(List<FileInfo> dirFiles, List<string> uniqueExtensions, string dirPath)
        {
            DirectoryFiles = dirFiles;
            UniqueExtensions = uniqueExtensions;
            DirectoryPath = dirPath;
        }

        public void ReduceData(string fileName)
        {
            if (DirectoryFiles.Count - 1 < 0)
            {
                Console.WriteLine("Cannot remove the only item");
                return;
            }
            var FileDeleted = DirectoryFiles.Find(f => f.Name == fileName);
            if (FileDeleted == null)
            {
                Console.WriteLine("cannot remove a file that doesn't exist");
                return;
            }
            DirectoryFiles.Remove(FileDeleted);
            bool lastFileWithExtension = DirectoryFiles.Any(file =>
                string.Equals(file.Extension, FileDeleted.Extension, StringComparison.OrdinalIgnoreCase));

            // file removed was the last file in list with the unique extension
            if (lastFileWithExtension == false)
            {
                UniqueExtensions.Remove(FileDeleted.Extension);
            }
        }








    }
}
