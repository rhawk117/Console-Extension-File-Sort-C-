using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sort;
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
                finally
                {
                    PathManager.SaveChanges(Info);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] An Error Occured while loading your previously saved paths [!]");
                Console.WriteLine($"[!] {e.Message} [!]");
                Console.WriteLine(e.StackTrace);
            }

        }
    }
}
