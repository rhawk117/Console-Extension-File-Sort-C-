using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;


namespace Sort
{
    public static class SorterManager
    {
        public static Sorter CollectSortData(DirectoryInfo dir)
        {

            List<FileInfo> DirFiles = dir.EnumerateFiles().ToList();
            List<string> uniqueExtensions = DirFiles
                .Select(files => files.Extension)
                .Distinct()
                .ToList();
            return new Sorter(DirFiles, uniqueExtensions, dir.FullName);
        }

        public static void DisplayAllFiles(Sorter sortData)
        {
            foreach (FileInfo file in sortData.DirectoryFiles)
                WriteLine($" >> {file.Name} => {file.Extension.Substring(1)}_files");
        }

        public static void MoveAll(Sorter aSort)
        {
            foreach (FileInfo file in aSort.DirectoryFiles)
            {
                string newDir = file.Extension.Substring(1) + "_files";
                WriteLine($"Attempting to move {file.Name} to => {newDir}");
                SafeMove(file, newDir);
            }

        }
        private static void SafeMove(FileInfo file, string Destination)
        {
            try
            {
                Move(file, Destination);
            }
            catch (IOException ex)
            {
                WriteLine($"[!] Error moving file: {file.Name} [!]");
                WriteLine($"[!] {ex.Message} [!]\n\n");
            }
            catch (Exception e)
            {
                WriteLine($"[!] Generic exception occured while moving file: {file.Name} [!]");
                WriteLine($"[!] {e.Message} [!]\n\n");
            }
        }
        private static void Move(FileInfo file, string Destination)
        {
            string newPath = Path.Combine(file.DirectoryName, Destination);
            if (Directory.Exists(newPath) == false)
                Directory.CreateDirectory(newPath);

            string newFilePath = Path.Combine(newPath, file.Name);
            file.MoveTo(newFilePath);
        }







    }
}
