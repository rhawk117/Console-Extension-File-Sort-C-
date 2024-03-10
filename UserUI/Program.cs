using System;
using Sort;
using static System.Console;
using System.IO;

namespace UserUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                UserPathData Info = PathManager.Load();
                try
                {
                    App.Run(Info);
                }
                catch (Exception exc)
                {
                    WriteLine("[!] An Exception occured details on the line below...");
                    WriteLine("[i]" + exc.Message + "[i]\n\n");
                    WriteLine("StackTrace: " + exc.StackTrace);

                }
                finally
                {
                    PathManager.SaveChanges(Info);
                }
            }
            catch (Exception error)
            {
                WriteLine($"[!] An Error Occured while loading your previously saved paths [!]");
                WriteLine($"[!] {error.Message} [!]");
                WriteLine(error.StackTrace);
            }

        }
    }
}
