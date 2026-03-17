using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Student 
    {
        public int StudentId;
        public string Name;
        public int Marks;
        public Student(int id, string name, int marks)
        {
            StudentId = id;
            Name = name;
            Marks = marks;
        }

        public virtual void  CalculateGrade()
        {
            if(Marks > 50)
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }

    }

    class SchoolStudent : Student
    {
        public SchoolStudent(int id , string name, int marks):base(id, name, marks) { }
        public override void CalculateGrade()
        {
            if(Marks > 40)
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }
    }
    class CollegeStudent : SchoolStudent
    {
        public CollegeStudent(int id, string name, int marks) : base(id, name, marks)
        {
        }

        public override void CalculateGrade()
        {
            if (Marks > 50)
            {
                Console.WriteLine("Pass");
            }else
            {
                Console.WriteLine("Fail");
            }
        }
    }
    class OnlineStudent : CollegeStudent
    {
        public OnlineStudent(int id, string name, int marks) : base(id, name, marks) { }
        public override void CalculateGrade()
        {
            if(Marks > 60)
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }
    }
}
