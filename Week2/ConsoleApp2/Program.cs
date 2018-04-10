using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeOrNot
{
    class Program
    {
        static bool IsPrime (int x)
            {
                bool res = true;

                if (x == 1) return false;

                for (int i = 2; i < Math.Sqrt(x); i ++)
                {
                    if (x%i == 0)
                    {
                        res = false;
                        break;
                    }
                }
                return res;
            }

        static void Main(string[] args)
        {
            /*
            for (int i = 0; i < args.Length; i ++)
            {
                if (IsPrime(int.Parse(args[i])))
                {
                    Console.WriteLine(args[i]);
                }
            }*/
            foreach (string s in args)
            {
                if (IsPrime(int.Parse(s)))
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
