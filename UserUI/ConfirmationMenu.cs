using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserUI.ConsoleMenus;

namespace UserUI
{
    public static class ConfirmationMenu
    {
        /// <summary>
        /// whenever a user needs to confirm an action we
        /// will use this class to have a fancy menu to do so
        /// </summary>

        private static Menu Generate(string prompt) => new Menu(new List<string> { "YES", "NO" }, prompt);
        public static bool Start(string prompt)
        {
            Menu confirmationMenu = Generate(prompt);
            string selectedOption = confirmationMenu.Run();
            return selectedOption == "YES";
        }



    }
}
