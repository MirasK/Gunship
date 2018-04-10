using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example4
{
    class Student
    {
        private double gpa;

        public void SetGPA(double gpa)
        {
            if (gpa <= 4)
            {
                this.gpa = gpa;
            }
        }

        public string GetGPA(string user)
        {
            if (user == "admin")
            {
                return this.gpa.ToString();
            }
            else
            {
                return "permission denied!";
            }
        }
    }

    class Student2
    {
        private double gpa;
        public double GPA
        {
            get
            {
                return this.gpa;
            }
            set
            {
                if (value <= 4)
                {
                    this.gpa = value;
                }
            }
        }
    }

    class Student3
    {
        public double GPA { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.SetGPA(2.4);
            Console.WriteLine(s.GetGPA("admin"));
            s.SetGPA(5);
            Console.WriteLine(s.GetGPA("student"));

            Student2 s2 = new Student2();
            s2.GPA = 4;
            Console.WriteLine(s2.GPA);

            Student3 s3 = new Student3();
            s3.GPA = 3;
            Console.WriteLine(s3.GPA);
        }
    }
}
