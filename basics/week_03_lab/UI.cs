using System;

namespace week_03_lab
{
    class UI
    {
        public void run(Classlist classlist)
        {
            int options = 0;
            while (options != -1)
            {
                Console.WriteLine("\n1: Print all assignment averages");
                Console.WriteLine("2: Print all student averages");
                Console.WriteLine("3: Print all student averages descending");
                Console.WriteLine("4: Print class average");
                Console.WriteLine("5: Print specific assignment average");
                Console.WriteLine("6: Print specific student average");
                Console.WriteLine("7: Create new class list");
                Console.WriteLine("8: Add assignment");
                Console.WriteLine("-1: Exit\n");

                try
                {
                    options = Int32.Parse(Console.ReadLine().Trim());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                switch(options)
                {
                    case 1:
                        AllAssignmentAverage(classlist);
                        break;

                    case 2:
                        AllStudentAverage(classlist);
                        break;

                    case 3:
                        AllStudentAverageDesc(classlist);
                        break;

                    case 4:
                        ClassAverage(classlist);
                        break;

                    case 5:
                        SpecificAssignmentAverage(classlist);
                        break;

                    case 6:
                        SpecificStudentAverage(classlist);
                        break;

                    case 7:
                        classlist = NewClasslist();
                        break;

                    case 8:
                        AddAssignmment(classlist);
                        break;
                }
            }
        }

        private void SpecificStudentAverage(Classlist classlist)
        {
            Console.Write("\nEnter student name: ");
            string name = Console.ReadLine().Trim();

            Student student = Classlist.GetStudentByName(classlist.students, name);
            if (student != null)
            {
                Console.WriteLine($"\n{name} average is: {Student.GetStudentAverage(student):F}");
            }
            else
            {
                Console.WriteLine($"{name} does not exist\n");
            }
        }

        private void SpecificAssignmentAverage(Classlist classlist)
        {
            Console.Write("\nEnter assignment name: ");
            string assignment = Console.ReadLine().Trim();

            float average = Classlist.GetClassAverageByAssignmentName(classlist.students, assignment);
            if(average >= 0)
            {
                Console.WriteLine($"\nClass average for assignment {assignment} is {average:F}");
            }
            else
            {
                Console.WriteLine($"{assignment} does not exist\n");
            }
        }

        private Classlist NewClasslist()
        {
            var classlist = Classlist.CreateNewClassList();
            return new Classlist(classlist);
        }

        private void AddAssignmment(Classlist classlist)
        {
            Console.WriteLine("Enter assignment name: ");
            var assignmentName = Console.ReadLine().Trim();
            while(assignmentName.Length == 0)
            {
                Console.WriteLine("\nAssignment name can not be empty, try again: ");
                assignmentName = Console.ReadLine().Trim();
            }
            Classlist.AddNewAssignment(classlist.students, assignmentName);
        }

        private void AllAssignmentAverage(Classlist classlist)
        {
            var assignments = classlist.students[0].GetAllAssignments().ToArray();
            Console.WriteLine();
            foreach (Assignment assignment in assignments)
            {
                float average = Classlist.GetClassAverageByAssignmentName(classlist.students, assignment.Name);
                Console.WriteLine($"{assignment.Name} {average:F}");
            }
        }

        private void AllStudentAverage(Classlist classlist)
        {
            PrintStudents(classlist.students);
        }

        private void AllStudentAverageDesc(Classlist classlist)
        {
            int len = classlist.students.Length;
            Student[] students = new Student[len];
            classlist.students.CopyTo(students, 0);
            Array.Sort(students, delegate (Student a, Student b)
            {
                return (int)(Student.GetStudentAverage(b) - Student.GetStudentAverage(a));
            });
            PrintStudents(students);
        }

        private void PrintStudents(Student[] students)
        {
            Console.WriteLine();
            foreach (Student student in students)
            {
                float average = Student.GetStudentAverage(student);
                Console.WriteLine($"{student.Name} {average:F}");
            }
        }

        private void ClassAverage(Classlist classlist)
        {
            var average = Classlist.GetClassAverage(classlist.students);
            Console.WriteLine($"\nClass average is {average:F}");
        }
    }
}
