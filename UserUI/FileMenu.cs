using Sort;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
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

        private static string _infoBlock = @"
       *=====================================================================*
                                    << NOTE >>

          [i] The sorting data was successfully collected! For your convience &
              to avoid any unwanted sorting, you can specify exclusions 

          >> If you wish to exclude a file, press enter on a highlighted file 
          
          >> To proceed with sorting, select Continue at the bottom of the menu
          
          >> If you wish to exit the program, select Exit

                        [ *** press enter to continue *** ]

        *=====================================================================*
                 
        
        ";
        public static void MenuInfo()
        {
            WriteLine(_infoBlock);
            ReadKey();
        }
        private static Menu Generate(Sorter aSorter)
        {
            List<string> fileNames = aSorter.DirectoryFiles
                .Select(Files => Files.Name)
                .ToList();

            fileNames.Add("[ Continue ]");
            fileNames.Add("[ Exit ]");
            Menu FileMenu = new Menu(fileNames, "[ Listed Below are the Files That Will Be sorted ]");
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
            WriteLine($"[i] {itemsLeft} files remain, press enter to continue program [i]");
            ReadKey();
        }

        private static void invalidRemove(Sorter aSorter)
        {
            WriteLine("[!] ERROR: Cannot remove the only file from the data set, please select another action [!]");
            Start(aSorter);
        }







    }
}
