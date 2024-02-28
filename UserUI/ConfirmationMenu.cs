using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserUI.ConsoleMenus;

namespace UserUI
{
    public static class ConfirmationMenu
    {
        private static Menu Generate(string prompt)
        {
            return new Menu(new List<string> { "YES", "NO" }, prompt);
        }
        public static bool Start(string prompt)
        {
            Menu confirmationMenu = Generate(prompt);
            string selectedOption = confirmationMenu.Run();
            return selectedOption == "YES";
        }






    }
}
