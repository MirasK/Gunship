using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string maxmin = File.ReadAllText(@"C:\Users\user\source\repos\Lab2\DirFile\bin\Debug\maxmin.txt");

            args = maxmin.Split(' ');

            int[] n = new int[args.Count()];

            for (int i = 0; i < args.Length; i++)
            {
                n[i] = int.Parse(args[i]);
            }

            Console.Write(n.Min() + " ");
            Console.Write(n.Max() );
            Console.WriteLine();
        }
    }
}
