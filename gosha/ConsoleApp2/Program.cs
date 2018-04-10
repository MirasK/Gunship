using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class Animal
    {
        public static int count = 0;

        public string name;
        public int age;
        protected float hapiness;

        public Animal() { 
            name = "Spotty";
            age = 7;
            hapiness = 0.6f;

            count++;

            Print();
        }

        public Animal(string _name, int _age, float _hapiness)
        {
            name = _name;
            age = _age;
            hapiness = _hapiness;

            count++;

            Print();
        }

        /*public Animal(string name, int age, float hapiness)
        {
            this.name = name;
            this.age = age;
            this.hapiness = hapiness;

            count++;

            Print();
        }*/


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
            
            Animal dog = new Animal("Tom", 2, 0.99f);

            Console.WriteLine("Count: " + Animal.count);
            
        }
    }
}
