using System;
using System.Collections.Generic;

namespace week_03_lab
{
    class Classlist
    {
        public Student[] students;

        public Classlist()
        {
            students = new Student[3];
            var student = new Student("student1");
            var lab1 = new Assignment("lab1", 11);
            var lab2 = new Assignment("lab2", 80);
            Student.AddAssignment(student, lab1);
            Student.AddAssignment(student, lab2);
            students[0] = student;

            student = new Student("student2");
            lab1 = new Assignment("lab1", 22);
            lab2 = new Assignment("lab2", 90);
            Student.AddAssignment(student, lab1);
            Student.AddAssignment(student, lab2);
            students[1] = student;

            student = new Student("student3");
            lab1 = new Assignment("lab1", 32);
            lab2 = new Assignment("lab2", 100);
            Student.AddAssignment(student, lab1);
            Student.AddAssignment(student, lab2);
            students[2] = student;
        }
        public Classlist(Student[] students)
        {
            this.students = students;
        }

        public static Student GetStudentByName(Student[] students, string name)
        {
            foreach (Student student in students)
            {
                if (student.Name == name)
                {
                    return student;
                }
            }
            return null;
        }

        public static float GetClassAverageByAssignmentName(Student[] students, string name)
        {
            int sum = 0;
            int count = 0;
            foreach (Student student in students)
            {
                if(Student.GetOneAssignment(student, name) == null)
                {
                    return -1;
                }
                sum += (Student.GetOneAssignment(student, name).Score);
                count++;
            }
            return sum / (float)count;
        }

        public static float GetClassAverage(Student[] students)
        {
            float sum = 0;
            int count = 0;
            foreach (Student student in students)
            {
                sum += Student.GetStudentAverage(student);
                count++;
            }
            return sum / count;
        }

        public static Student[] CreateNewClassList()
        {
            var list = new List<Student>();
            Console.WriteLine("Enter student name, \"\" to complete");

            while (true)
            {
                var name = Console.ReadLine().Trim();
                if (name.Length == 0)
                {
                    break;
                }
                Student student = new Student(name);
                list.Add(student);
            }

            var classlist = list.ToArray();
            Console.Write("New class includes: ");
            foreach(Student student in classlist)
            {
                Console.Write($"{student.Name}, ");
            }
            Console.WriteLine();
            return classlist;
        }

        public static void AddNewAssignment(Student[] students, string assignmentName)
        {
            foreach(Student student in students)
            {
                Console.Write($"{student.Name} grade: ");
                int grade = Int32.Parse(Console.ReadLine().Trim());
                Student.AddAssignment(student, new Assignment(assignmentName, grade));
                Console.WriteLine($"{student.Name} {assignmentName} : {grade} added\n");
            }
            Console.WriteLine();
        }
    }
}
