using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\MinGW\include");

            FileSystemInfo[] arr = di.GetFileSystemInfos();

            foreach (FileSystemInfo x in arr)
            {
                Console.WriteLine(x.Name);
            }

        }
    }
}
