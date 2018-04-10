using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorStudent
{
    class Student
    {
        string name;
        string sname;
        double gpa;

        public Student (string name, string sname, double gpa)
        {
            this.name = name;
            this.sname = sname;
            this.gpa = gpa;
        }
        public override string ToString()
        {
            return name + " " + sname + " " + gpa;
        }
    }
}
