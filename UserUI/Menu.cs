using System;
using System.Collections.Generic;
using static System.Console;

namespace UserUI.ConsoleMenus
{
    public class Menu
    {
        public List<string> Options { get; set; }
        private string Prompt { get; set; }

        private int selectedIndex;
        private int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (value < 0)
                    selectedIndex = Options.Count - 1;

                else if (value >= Options.Count)
                    selectedIndex = 0;

                else
                    selectedIndex = value;
            }
        }

        public Menu(List<string> options, string prompt)
        {
            Options = options;
            Prompt = prompt;
            SelectedIndex = 0;
        }

        private void Show()
        {
            Clear();
            WriteLine(Prompt);
            for (int i = 0; i < Options.Count; i++)
            {

                string currentOption = Options[i], prefix = "";
                if (i == SelectedIndex)
                {
                    prefix = ">> ";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                WriteLine($"{prefix} [ " + currentOption + " ]");
            }
            ResetColor();
        }
        public string Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                Show();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        SelectedIndex--;
                        break;

                    case ConsoleKey.DownArrow:
                        SelectedIndex++;
                        break;
                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return Options[selectedIndex];
        }
    }
}
