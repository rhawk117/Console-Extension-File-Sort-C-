using System;
using System.Collections.Generic;

namespace UserUI
{
    public static class PathMenu
    {
        private static Menu _Generate(List<string> paths, string Prompt)
        {
            paths.Add("Input a Path");
            Prompt = "[i] Previously inputted Paths were Found [i]\n" + Prompt;
            return new Menu(paths, Prompt);
        }
        public static string Start(List<string> paths, string Prompt)
        {
            Menu pathMenu = _Generate(paths, Prompt);
            string Selection = pathMenu.Run();
            return Selection;
        }

    }
}
