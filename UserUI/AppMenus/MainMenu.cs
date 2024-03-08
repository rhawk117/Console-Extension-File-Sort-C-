using System;
using System.Collections.Generic;


namespace UserUI
{
    public static class MainMenu
    {
        private const string _titleText = @"
        *=====================================================================*
        |  _____      _                 _               ____             _    |
        | | ____|_  _| |_ ___ _ __  ___(_) ___  _ __   / ___|  ___  _ __| |_  |
        | |  _| \ \/ / __/ _ \ '_ \/ __| |/ _ \| '_ \  \___ \ / _ \| '__| __| |
        | | |___ >  <| ||  __/ | | \__ \ | (_) | | | |  ___) | (_) | |  | |_  |
        | |_____/_/\_\\__\___|_| |_|___/_|\___/|_| |_| |____/ \___/|_|   \__| |
        |                                                                     |
        |                       created by: rhawk117                          |
        |                                                                     |
        *=====================================================================*
        ";
        private static Menu Generate()
        {
            List<string> Options = new List<string> { "Start", "Help", "Exit" };
            string Prompt = $"{_titleText}\n[ Select one of the following to continue ]";
            return new Menu(Options, Prompt);
        }
        public static string Start()
        {
            Menu menu = Generate();
            string Selection = menu.Run();
            return Selection;
        }

    }
}
