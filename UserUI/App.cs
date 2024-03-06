using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sort;
using System.Threading;



namespace UserUI
{
    public class App
    {

        public static void Run()
        {
            string userSelect = MainMenu.Start();
            appHandler(userSelect);
        }
        // can make the handlers for everything except core logic
        // for the sort option

        private static void appHandler(string UserSelect)
        {
            if (UserSelect == "Start")
            {
                hndleSort();
            }
            else if (UserSelect == "Help")
            {
                helpHndler();
            }
            else
            {
                exitHndler();
            }
        }


        private static void exitHndler()
        {
            Console.WriteLine("[ Exiting program... ]");
            Environment.Exit(0);
        }


        private static void helpHndler()
        {
            delayPrompt("[i] This program sorts a directory by file extension [i]");
            delayPrompt("[i] Upon selecting Start in the main menu you will be prompted to select a directory to sort [i]");
            delayPrompt("[i] The program will then sort the directory by file extension and move the files to a new directory [i]");
            delayPrompt("[i] The new directory will be created in the same location as the original directory as a sub-directory [i]");
            delayPrompt("[i] Directory names are in the format of [fileExtension]_files & all corresponding files with the extension are moved to it [i]");
            delayPrompt("[i] (Example: .txt files will be moved to a directory named txt_files) [i]");
            delayPrompt("[i] The new directory will be created in the same location as the original directory as a sub-directory [i]");
            delayPrompt("[i] Press any key to return to the main menu [i]");
            Console.ReadKey();
            Run();
        }
        private static void delayPrompt(string Prompt)
        {
            Console.WriteLine(Prompt + "\n");
            Thread.Sleep(4000);
        }
        private static void hndleSort()
        {
            Sorter userSort = GetFolderSelection();
            if (AlterDataAndConfirm(userSort) == false)
            {
                Run();
                return;
            }
            userSort.MoveAll();
            Console.WriteLine("[i] Sorting Complete returning to the Main Menu... [i]");
            Thread.Sleep(5000);
            Run();
        }
        private static Sorter GetFolderSelection()
        {
            string prompt = "[?] Enter the directory you would like to sort [?]";
            DirectoryInfo dirChoice = InputCollector.GetDirectoryInput(prompt);
            Sorter userSort = SorterManager.GetData(dirChoice);
            ValidateData(userSort);
            return userSort;
        }
        private static bool AlterDataAndConfirm(Sorter userSort)
        {
            FileMenu.MenuInfo();
            FileMenu.Start(userSort);
            int fileCount = userSort.DirectoryFiles.Count;
            string path = userSort.DirectoryPath;
            return ConfirmMove(fileCount, path);
        }
        private static void ValidateData(Sorter aSort)
        {
            if (SorterManager.CheckData(aSort)) return;

            string Prompt = "[!] There was an error with the data [!]\n[?] Retry sorting process [?]";
            bool Retry = ConfirmationMenu.Start(Prompt);

            if (Retry) hndleSort();
            else exitHndler();

        }

        /// <summary>
        /// ConfirmMove
        /// 
        /// Prompts the user to confirm the sorting action
        /// and returns true if user confirms
        /// </summary>
        /// <param name="fileCount"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool ConfirmMove(int fileCount, string path)
        {
            string Prompt = $"[?] Sort {fileCount} in {path} [?]";
            return ConfirmationMenu.Start(Prompt); ;
        }



    }
}
