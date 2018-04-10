using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Serialization
{
    public class Complex
    {
        public int x;
        public int y;
        public Complex()
        {

        }
        public Complex(int a, int b)
        {
            x = a;
            y = b;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex c = new Complex();
            c.x = c1.x + c2.x;
            c.y = c1.y + c2.y;
            return c;
        }
        public override string ToString()
        {
            return x + " " + y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(2, 3);
            Complex c2 = new Complex(5, 7);
            Complex c = c1 + c2;
            F1(c);
            F2();
        }

        static public void F1(Complex c)
        {
            FileStream fs = new FileStream("Complex.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            xs.Serialize(fs, c);
            fs.Close();
        }

        static public void F2()
        {
            FileStream fs = new FileStream("Complex.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex c = xs.Deserialize(fs) as Complex;
            Console.WriteLine(c);
        }
    }
}