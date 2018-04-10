using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Far
{
    class Program
    {
        private static void GetAllFiles(string sDir)
        {
            foreach (string dir in Directory.GetDirectories(sDir))
            {
                try
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        string obj = Path.GetFileName(file);
                        Console.WriteLine(obj);
                    }
                    GetAllFiles(dir);
                }
                catch (Exception error)
                {
                    Console.WriteLine("error");
                }
            }
        }
        static void Main(string[] args)
        {
            GetAllFiles(@"C:\GitHub");
        }
    }
}
