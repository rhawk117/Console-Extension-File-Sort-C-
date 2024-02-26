using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sort
{
    public static class SorterManager
    {
        public static Sorter CollectSortData(DirectoryInfo dir)
        {

            List<FileInfo> DirFiles = dir.EnumerateFiles().ToList();
            string[] uniqueExtensions = DirFiles
                .Select(f => f.Extension)
                .Distinct()
                .ToArray();
            return new Sorter(DirFiles, uniqueExtensions);
        }

        public static void DisplayAllFiles(Sorter sortData)
        {
            foreach (FileInfo file in sortData.DirectoryFiles)
            {
                Console.WriteLine($" >> {file.Name}will be moved to => " + file.Extension.Substring(1) + "_files");
            }
        }






    }
}
