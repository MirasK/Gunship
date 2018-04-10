using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\MinGW\include");

            DirectoryInfo[] dirs = di.GetDirectories();

            foreach (DirectoryInfo d in dirs)
            {
                Console.WriteLine(d.Name);
            }
        }
    }
}
