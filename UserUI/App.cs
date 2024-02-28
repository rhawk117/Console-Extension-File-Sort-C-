using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sort;



namespace UserUI
{
    public class App
    {

        public static void Run()
        {
            string userSelect = MainMenu.Start();

        }
        // can make the handlers for everything except core logic
        // for the sort option

        private static void appHandler(string choice)
        {
            if (choice == "Start")
            {
                // do everything
            }
            else if (choice == "Help")
            {
                helpHndler();
            }
            else
                exitHndler();
        }


        private static void exitHndler()
        {
            Console.WriteLine("[ Exiting program... ]");
            Environment.Exit(0);
        }


        private static void helpHndler()
        {
            throw new NotImplementedException();
        }

        private static void hndleSort()
        {
            DirectoryInfo dirChoice = GetFolderSelection();
            Sorter userSort = SorterManager.GetData(dirChoice);
            if ()

        }


        private static Sorter GetFolderSelection()
        {
            string prompt = "[?] Enter the directory you would like to sort [?]";
            DirectoryInfo dirChoice = InputCollector.GetDirectoryInput(prompt);
            Sorter userSort = SorterManager.GetData(dirChoice);
            bool invalidData = SorterManager.CheckData(userSort.DirectoryFiles, userSort.UniqueExtensions);


        }


        private static void hndleDataError(bool flag)
        {
            if (flag == false) return;
            else
            {
                ConfirmationMenu.Start(
            }
        }


    }
}
