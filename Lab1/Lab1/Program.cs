using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rec
{
    class Rectangle
    {
        public int w;
        public int h;

        public int findPerimetre(int w, int h)
        {
            int P = (w + h) * 2;
            Console.Write("P = ");
            return P;

        }

        public int findArea(int w, int h)
        {
            int S = w * h;
            Console.Write("S = ");
            return S;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Rectangle r = new Rectangle();
            Console.WriteLine(r.findPerimetre(a, b));
            Console.WriteLine();
            Console.WriteLine(r.findArea(a, b));
        }
    }
}
