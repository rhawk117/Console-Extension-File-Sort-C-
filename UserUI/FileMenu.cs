using Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserUI.ConsoleMenus;
using static System.Console;

namespace UserUI
{
    public static class FileMenu
    {
        private static void InfoBlock()
        {
            Clear();
            WriteLine("[*] Sorting Data was succesfully collected [*]");
            WriteLine("[i] The following files listed below will be sorted [i]");
            WriteLine("[i] If you wish to remove a file from being sorted, press enter [i]");
            WriteLine("[i] If you wish to proceed sort the files, select at the bottom >> Continue [i]");
            WriteLine("\n\t\t[ PRESS ENTER TO CONTINUE ]\n");
            ReadLine();
        }
        private static Menu Generate(Sorter aSorter)
        {
            List<string> fileNames = aSorter.DirectoryFiles
                .Select(Files => Files.Name)
                .ToList();

            fileNames.Add("[ Continue ]");
            var menu = new Menu(fileNames, "Listed below are the files being moved");
            return menu;
        }
        public static void Start(Sorter aSorter)
        {
            Menu fileMenu = Generate(aSorter);
            string selectedFile = fileMenu.Run();
            handleSelection(selectedFile, aSorter);


        }
        private static void handleSelection(string selectedFile, Sorter aSorter)
        {
            if (selectedFile != "[ Continue ]")
            {
                aSorter.ReduceData(selectedFile);
                WriteLine($"Removing => {selectedFile} from the list of files to process");
                Start(aSorter);
            }
            else if (selectedFile != "[ Continue ]" && aSorter.DirectoryFiles.Count == 1)
            {
                WriteLine("Cannot remove the only file from the data set");
                Start(aSorter);
            }
            else
            {
                return;
            }

        }









    }
}
