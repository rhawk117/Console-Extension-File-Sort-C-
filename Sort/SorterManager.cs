using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;


namespace Sort
{
    /// <summary>
    /// SorterManager:
    /// 
    /// Helper class that manages the sorting of files in a directory.
    /// 
    /// Methods
    /// + GetData: Retrieves the data from the directory and returns a Sorter object.
    /// 
    /// - CheckData: Checks if the data is suitable for sorting and returns a boolean.
    ///     - badDataPrompts: Helper method to inform the user on why the data is not suitable.
    /// 
    /// Moving Logic
    /// ============
    /// 
    /// -> Files of the same extension are moved to a new directory titled fileExtension_files
    /// 
    /// -GetDestination: Checks if the directory destination exists in the directory being sorted
    ///  returns the path so the file can be moved to it.
    /// 
    /// -Move: Moves a single File to a new directory and is guarded by GetDestination 
    ///  to ensure the directory exists before moving the file.
    /// 
    /// + SafeMove: Combines the moving logic in the Move method into a try-catch block
    /// 
    /// </summary>
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
        public static bool CheckData(Sorter aSorter)
        {
            string postfix = "\n[!] Cannot proceed with sorting action [!]\n\n";
            if (aSorter.IsSortable) return true;

            badDataPrompts(aSorter, postfix);
            return false;
        }
        /// <summary>
        /// badDataPrompts:
        /// 
        /// Whenever the data is not suitable for sorting, this method will
        /// be called to inform the user on why the data is not suitable.
        /// </summary>
        /// <param name="aSorter"></param>
        /// <param name="trailer"></param>
        private static void badDataPrompts(Sorter aSorter, string trailer)
        {
            if (aSorter.DirectoryFiles.Count == 0)
            {
                WriteLine("[!] No files were found in directory [!]" + trailer);
            }
            if (aSorter.UniqueExtensions.Count == 0)
            {
                WriteLine("[!] No unique file extensions found [!]" + trailer);
            }
        }
        /// <summary>
        /// SafeMove:
        /// 
        /// Combines the moving logic in the Move method into a try-catch block
        /// to ensure we handle any exceptions that may occur when moving files.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="Destination"></param>
        /// <param name="countMoves"></param>
        public static void SafeMove(FileInfo file, string Destination, ref int countMoves)
        {
            try
            {
                Move(file, Destination);
                WriteLine($"[i] Sucessfully moved => {file.Name}[i]");
                countMoves++;
            }
            catch (IOException ex)
            {
                WriteLine($"[!] Error moving file: {file.Name} [!]");
                WriteLine($"[!] {ex.Message} [!]\n\n");
            }
            catch (Exception e)
            {
                WriteLine($"[!] An Exception occured while moving file: {file.Name} [!]");
                WriteLine($"[!] {e.Message} [!]\n\n");
            }
        }

        /// <summary>
        /// Move:
        /// 
        /// Moves a single File to a new directory and is guarded by 
        /// GetDestination to ensure the directory exists before moving the file.
        /// 
        /// Is called by SafeMove to ensure the file is moved safely & all exceptions are caught.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="Destination"></param>
        private static void Move(FileInfo file, string Destination)
        {
            string newPath = GetDestination(file.DirectoryName, Destination);
            string newFilePath = Path.Combine(newPath, file.Name);
            file.MoveTo(newFilePath);
        }

        /// <summary>
        /// GetDestination:
        /// 
        /// Checks if the directory destination exists in the directory being sorted
        /// if not it creates it and returns the path so the file can be moved to it.
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="Destination"></param>
        /// <returns></returns>
        private static string GetDestination(string dirName, string Destination)
        {
            string newPath = Path.Combine(dirName, Destination);
            if (Directory.Exists(newPath) == false)
                Directory.CreateDirectory(newPath);
            return newPath;
        }
        public static void DisplayStats(int filesMoved, int totalFiles)
        {
            WriteLine($"[i] Sorting Complete & Succesfully moved {filesMoved} files out of {totalFiles} total files [i]");
            WriteLine("[ *** Press Enter To Continue *** ]");
            ReadKey();
        }






    }
}
