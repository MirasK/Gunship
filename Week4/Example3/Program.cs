using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Example3
{
    [Serializable]
    public class Student
    {
        public Student(string name, double gpa)
        {
            this.name = name;
            this.gpa = gpa;
        }
        private string name;
        public double gpa;
        public string GetInfo()
        {
            return gpa + " " + name;
        }
    }

    [Serializable]
    public class University
    {
        Student s;
        string name;
        public University(string name, Student s)
        {
            this.name = name;
            this.s = s;
        }

        public override string ToString()
        {
            return s.GetInfo() + " " + name;
        }

        public void Save()
        {
            using (FileStream fs = new FileStream("student.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, this);
            }
        }

        public static University Load()
        {
            University res;
            using (FileStream fs = new FileStream("student.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                BinaryFormatter bf = new BinaryFormatter();
                res = bf.Deserialize(fs) as University;
            }
            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("ABC", 2);
            University u = new University("KBTU", s);
            Console.WriteLine(u);
            u.Save();

            University u2 = University.Load();
            Console.WriteLine(u2);
        }
    }
}
