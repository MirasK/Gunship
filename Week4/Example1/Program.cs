using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Example1
{
    public class Student
    {
        public Student()
        {
        }

        public Student(string name, double gpa)
        {
            this.name = name;
            this.gpa = gpa;
        }

        public string name;
        public double gpa;

        public string GetInfo()
        {
            return name + " " + gpa;
        }
    }
    class Program
    {
        private static void F2()
        {
            FileStream fs = new FileStream("student.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Student));
            Student s = xs.Deserialize(fs) as Student;

            Console.WriteLine(s.GetInfo());

            fs.Close();
        }

        private static void F1()
        {
            Student s = new Student("ABC", 1);

            FileStream fs = new FileStream("student.xml", FileMode.Truncate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Student));

            xs.Serialize(fs, s);
            fs.Close();
        }
        static void Main(string[] args)
        {
            F1();
            F2();
        }

    }
}
