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
        /// <summary>
        /// Generate:
        /// 
        /// Returns a list of files found from the Sorter obj
        /// and adds two additional options to the list of files
        /// </summary>
        /// <param name="aSorter"></param>
        /// <returns></returns>
        private static Menu Generate(Sorter aSorter)
        {
            List<string> fileNames = aSorter.DirectoryFiles
                .Select(Files => Files.Name)
                .ToList();

            fileNames.Add("[ Continue ]");
            fileNames.Add("[ Exit ]");
            Menu FileMenu = new Menu(fileNames, "Listed below are the files being moved");
            InfoBlock();
            return FileMenu;
        }
        /// <summary>
        /// Start:
        /// 
        /// Public abstracted method of all previous methods 
        /// </summary>
        /// <param name="aSorter"></param>
        public static void Start(Sorter aSorter)
        {
            Menu fileMenu = Generate(aSorter);
            string selectedFile = fileMenu.Run();
            handleSelection(selectedFile, aSorter);
        }

        /// <summary>
        /// handleSelection:
        /// 
        /// Using the menu of files when the user selects a file
        /// in our menu we want to remove the file from the list of files
        /// in the sorter object unless only one file remains 
        /// 
        /// </summary>
        /// <param name="selectedFile"></param>
        /// <param name="aSorter"></param>

        private static void handleSelection(string selectedFile, Sorter aSorter)
        {
            if (selectedFile == "[ Continue ]")
            {
                WriteLine("[i] Saving list of files to sort. Please confirm this action [i]");
                return;
            }
            else if (selectedFile == "[ Exit ]")
            {
                WriteLine("[i] Exiting program... [i]");
                Environment.Exit(0);
            }
            else if (aSorter.DirectoryFiles.Count <= 1)
            {
                invalidRemove(aSorter);
            }
            else
            {
                // user selected a file to delete and count > 1
                aSorter.ReduceData(selectedFile);
                RemoveMessage(selectedFile, aSorter.DirectoryFiles.Count);
                Start(aSorter);
            }
        }

        /// <summary>
        /// RemoveMessage: console dialogue after user removes a file 
        /// </summary>
        /// <param name="removedItem"></param>
        /// <param name="itemsLeft"></param>
        private static void RemoveMessage(string removedItem, int itemsLeft)
        {
            WriteLine($"[*] Removing => {removedItem} from the list of files to process [*]");
            WriteLine($"[i] {itemsLeft} files remain press enter to continue program [i]");
            ReadKey();
        }

        /// <summary>
        /// InfoBlock:
        /// 
        /// console dialogue to let the user know what is going on
        /// (idk maybe it's confusing for the first time)
        /// </summary>
        private static void InfoBlock()
        {
            Clear();
            WriteLine("[*] Sorting Data was succesfully collected [*]");
            WriteLine("[i] The following files listed below will be sorted [i]");
            WriteLine("[i] If you wish to remove a file from being sorted, press enter [i]");
            WriteLine("[i] If you wish to proceed sort the files, select at the bottom >> Continue [i]");
            WriteLine("\n\t\t[ PRESS ENTER TO CONTINUE ]\n");
            ReadKey();
        }
        private static void invalidRemove(Sorter aSorter)
        {
            WriteLine("[!] ERROR: Cannot remove the only file from the data set, please select another action [!]");
            Start(aSorter);
        }







    }
}
