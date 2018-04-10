using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir
{
    class Circle
    {
        public int r;

        public double findArea(int r)
        {
            return Math.PI * r * r;
        }

        public int findDiametre(int r)
        {
            return 2 * r;
        }

        public double findCircumference(int r)
        {
            return Math.PI * 2 * r;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());

            Circle c = new Circle();

            Console.WriteLine(c.findArea(r));
            Console.WriteLine();
            Console.WriteLine(c.findDiametre(r));
            Console.WriteLine();
            Console.WriteLine(c.findCircumference(r));
        }
    }
}
