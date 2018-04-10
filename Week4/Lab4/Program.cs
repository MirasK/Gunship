using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab4
{
    [Serializable]
    class Complex
    {
        public int x, y;

        public Complex() { }

        public Complex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex n = new Complex();
            n.x = c1.x + c2.x;
            n.y = c1.y + c2.y;
            return n;
        }

        public override string ToString()
        {
            return x + " " + y;
        }
    }
    class Program
    {
        static void S1()
        {
            FileStream fs = new FileStream("complex.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Complex cn = new Complex(1, 2);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, cn);

            fs.Close();
        }

        static void D1()
        {
            FileStream fs = new FileStream("complex.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Complex cn = bf.Deserialize(fs) as Complex;
            
            fs.Close();
        }

        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            Complex c1 = new Complex(a, b);
            Complex c2 = new Complex(c, d);

            Complex result = c1 + c2;

            Console.WriteLine(result);
        }
    }
}
