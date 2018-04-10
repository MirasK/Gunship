using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCM
{
    class Animal
    {
        public static int count = 0;

        public string name;
        public int age;
        protected float hapiness;

        public Animal(string _name, int _age, float _hapiness)
        {
            name = _name;
            age = _age;
            hapiness = _hapiness;

            count++;

            Print();
        }

        public void Print()
        {
            Console.WriteLine("Name - " + name);
            Console.WriteLine("Age - " + age);
            Console.WriteLine("Happy - " + hapiness);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal cat = new Animal();

            Animal dog = new Animal();

        }
    }
}
