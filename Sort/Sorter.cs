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
        public string[] UniqueExtensions { get; set; }
        public bool IsSortable => (UniqueExtensions.Length > 0 && DirectoryFiles.Count > 0);

        public Sorter(List<FileInfo> dirFiles, string[] uniqueExtensions)
        {
            DirectoryFiles = dirFiles;
            UniqueExtensions = uniqueExtensions;
        }








    }
}
