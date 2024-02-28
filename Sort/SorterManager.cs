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
        public static Sorter GetData(DirectoryInfo dir)
        {

            List<FileInfo> DirFiles = dir.EnumerateFiles().ToList();
            List<string> uniqueExtensions = DirFiles
                .Select(files => files.Extension)
                .Distinct()
                .ToList();

            return new Sorter(DirFiles, uniqueExtensions, dir.FullName);
        }
        public static bool CheckData(List<FileInfo> files, List<string> extensions)
        {
            string postfix = "\n[!] Cannot proceed with sorting action [!]\n\n";

            if (files.Count == 0)
            {
                WriteLine("[!] No files in the directory inputted were found or all were removed... [!]" + postfix);
                return false;
            }

            if (extensions.Count == 0)
            {
                WriteLine("[!] No unique extensions in the directory were found [!]" + postfix);
                return false;
            }
            return true;
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
                WriteLine($"[i] Attempting to move {file.Name} to => {newDir}");
                SafeMove(file, newDir);
            }

        }
        private static void SafeMove(FileInfo file, string Destination)
        {
            try
            {
                Move(file, Destination);
                WriteLine("[i] Move was successful [i]");
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
