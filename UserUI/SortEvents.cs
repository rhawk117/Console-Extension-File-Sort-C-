﻿using Sort;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UserUI
{
    public static class SortEvents
    {

        public static Sorter GetFolderSelection(Action<UserPathData> MainMenu, UserPathData userPath)
        {
            DirectoryInfo dirChoice;
            string prompt = "[?] Enter the directory you would like to sort [?]";
            bool canUseMenu = userPath.IsEmtpy == false;
            if (canUseMenu)
            {
                dirChoice = pathMenu(userPath, prompt);
            }
            else
            {
                dirChoice = GetManualInput(userPath);
            }
            Sorter userSort = SorterManager.GetData(dirChoice);
            //ValidateSortData(userSort, MainMenu);
            return userSort;
        }
        private static DirectoryInfo pathMenu(UserPathData Info, string Prompt)
        {
            string Selection = PathMenu.Start(Info.FetchBaseNames(), Prompt);
            if (Selection == "Input a Path")
            {
                return GetManualInput(Info);
            }
            return new DirectoryInfo(Info.GetPath(Selection));
        }

        private static DirectoryInfo GetManualInput(UserPathData Info)
        {
            DirectoryInfo dirName = InputCollector.GetDirectoryInput("[?] Enter the name of the directory [?]");
            Console.WriteLine("[i] Saving directory inputted for future use [i]");
            Info.AddEntry(dirName.Name, dirName.FullName);
            return dirName;
        }

        public static void MenuAdjustments(Sorter userSort)
        {
            FileMenu.MenuInfo();
            FileMenu.Start(userSort);
        }

        public static bool ConfirmMove(int fileCount, string path)
        {
            string Prompt = $"[?] Sort {fileCount} in {path} [?]";
            return ConfirmationMenu.Start(Prompt);
        }

        public static void BadDataOccured(UserPathData Info, Action<UserPathData> MainMenu, Action<UserPathData> Exit)
        {
            string Prompt = "[!] There was an error with the data [!]\n[?] Retry sorting process [?]";
            bool Retry = ConfirmationMenu.Start(Prompt);
            if (Retry)
            {
                MainMenu(Info);
            }
            else
            {
                Exit(Info);
            }
        }


    }
}
