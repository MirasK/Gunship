using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    
    class Student
    {

        private string name;
        private int course;
        private bool stip;

        public Student ()
        {
            name = "Alex";
            course = 1;
            stip = true;

            PrintAll();
        }

        public Student(string name, int course, bool stip)
        {
            this.name = name;
            this.course = course;
            this.stip = stip;

            PrintAll();
        }

        public void PrintAll()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Course: " + course);
            Console.WriteLine("Stip: " + stip);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student Alex = new Student();
            Console.WriteLine();
            Student Rex = new Student("Rex", 3, false);
        }
    }
}
