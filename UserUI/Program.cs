using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sort;
using System.IO;

namespace UserUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = InputCollector.GetDirectoryInput("Enter a directory path: ");
            Sorter sortData = SorterManager.CollectSortData(dir);
            foreach (var ext in sortData.UniqueExtensions)
            {
                Console.WriteLine(">>" + ext.Substring(1));
            }

        }
    }
}
