using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
