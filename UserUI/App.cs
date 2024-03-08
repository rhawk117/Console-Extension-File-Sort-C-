using Sort;
using System;

namespace UserUI
{
    public class App
    {
        public static void Run(UserPathData Info)
        {
            string userSelect = MainMenu.Start();
            appHandler(userSelect, Info);
        }

        private static void appHandler(string UserSelect, UserPathData Info)
        {
            if (UserSelect == "Start")
                EventHandler.SortUI(Run, Info);

            else if (UserSelect == "Help")
                EventHandler.StartHelpUI();

            else
                EventHandler.AppExit(Info);
        }

        public static UserPathData LoadPaths()
        {
            UserPathData Info = PathManager.Load();
            PathManager.DeleteInvalidItems(Info);
            return Info;
        }

    }
}
