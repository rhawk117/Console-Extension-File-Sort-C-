using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace Sort
{
    public static class InputCollector
    {
        public static DirectoryInfo GetDirectoryInput(string prompt)
        {
            string path = "";
            while (!ValidateDirInput(path))
            {
                WriteLine(prompt);
                path = ReadLine();
            }
            return new DirectoryInfo(path);
        }
        private static bool ValidateDirInput(string dir)
        {
            if (string.IsNullOrEmpty(dir))
            {
                return false;
            }
            if (!Directory.Exists(dir))
            {
                WriteLine("[!] Directory path provided does not exist [!]");
                return false;
            }
            if (!Directory.EnumerateFiles(dir).Any())
            {
                WriteLine("[!] Directory provided does not contain any files [!]");
                return false;
            }
            WriteLine("[i] Directory input is valid [i]");
            return true;
        }




    }
}
