using Sort;
using System;
using System.IO;
using System.Net;
using System.Threading;

namespace UserUI
{
    public static class EventHandler
    {
        public static void StartHelpUI()
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
        }
        private static void delayPrompt(string Prompt)
        {
            Console.WriteLine(Prompt + "\n");
            Thread.Sleep(4000);
        }
        public static void AppExit(UserPathData Info)
        {
            Console.WriteLine("[ Exiting program... ]");
            PathManager.SaveChanges(Info);
            Environment.Exit(0);
        }
        public static void SortUI(Action<UserPathData> MainMenu, UserPathData Info)
        {
            Sorter userSort = SortEvents.GetFolderSelection(MainMenu, Info);
            if (SorterManager.CheckData(userSort) == false)
            {
                SortEvents.BadDataOccured(Info, MainMenu, AppExit);
                return;
            }
            SortEvents.MenuAdjustments(userSort);
            int filesMoved = userSort.DirectoryFiles.Count;
            bool Continue = SortEvents.ConfirmMove(filesMoved, userSort.DirectoryPath);
            if (Continue == false)
            {
                MainMenu(Info);
                return;
            }
            userSort.MoveAll();
            Console.WriteLine("[i] Sorting Complete returning to the Main Menu... [i]");
            Thread.Sleep(5000);
        }


    }
}
