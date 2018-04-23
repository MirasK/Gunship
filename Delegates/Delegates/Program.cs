using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
    public class Summa
    {
        int x, y;

        public Summa(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int Sum()
        {
            return x + y;
        }
    }

    class Program
    {
        delegate int MyDelegete();

        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] n = s.Split(' ');

            int a = int.Parse(n[0]);
            int b = int.Parse(n[1]);

            Summa summa = new Summa(a, b);

            MyDelegete D = summa.Sum;

            Thread.Sleep(3000);

            //for (int i = 0; i < 9; ++i)
            //{
            //    Console.SetCursorPosition(0, 1);
            //    Console.Write(i + 1);
            //    Thread.Sleep(1000);
            //}

            //Console.SetCursorPosition(0, 1);
            Console.WriteLine(D.Invoke());
        }
    }
}
