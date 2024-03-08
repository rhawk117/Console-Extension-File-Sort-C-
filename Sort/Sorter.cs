using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static System.Console;

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
        /// <summary>
        /// MoveAll:
        /// 
        /// Using the data gathered, this method will attempt to move all the files
        /// and will keep a count of how many files were moved.
        /// </summary>
        /// <param name="aSort"></param>
        public void MoveAll()
        {
            int filesMoved = 0;
            foreach (FileInfo file in DirectoryFiles)
            {
                string newDir = file.Extension.Substring(1) + "_files";
                WriteLine($"[i] Attempting to move {file.Name} to => {newDir}");
                SorterManager.SafeMove(file, newDir, ref filesMoved);
            }
            SorterManager.DisplayStats(filesMoved, DirectoryFiles.Count);
        }
        public void ReduceData(string fileName)
        {
            if (DirectoryFiles.Count <= 1)
            {
                WriteLine("[!] ERROR: Cannot remove the only item, if you want to exit please select exit in the menu [!]");
                return;
            }
            var FileDeleted = DirectoryFiles.Find(f => f.Name.Equals(fileName));
            if (FileDeleted == null)
            {
                WriteLine("[!] ERROR: Could not find the file you selected to remove [!]");
                return;
            }
            DirectoryFiles.Remove(FileDeleted);
            // file removed was the last file in list with the unique extension
            if (IsLastExtension(FileDeleted))
            {
                UniqueExtensions.Remove(FileDeleted.Extension);
            }
        }

        /// <summary>
        /// After we remove the file from the list, we need to check if the file
        /// was the last unique extension in the list of files.
        /// 
        /// If so we need to adjust the UniqueExtensions list accordingly
        /// </summary>
        /// <param name="FileDeleted"></param>
        /// <returns></returns>
        private bool IsLastExtension(FileInfo FileDeleted)
        {
            return !(DirectoryFiles
                .Any(file => string
                .Equals(file.Extension, FileDeleted.Extension, StringComparison.OrdinalIgnoreCase))
           );
        }








    }
}
