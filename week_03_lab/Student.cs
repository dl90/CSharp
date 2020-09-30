using System.Collections.Generic;

namespace week_03_lab
{
    class Student
    {
        private readonly List<Assignment> assignments;
        private string name;

        public Student (string arg)
        {
            Name = arg;
            assignments = new List<Assignment>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Trim().Length > 0)
                {
                    name = value;
                }
            }
        }

        public List<Assignment> GetAllAssignments()
        {
            return assignments;
        }

        public static void AddAssignment(Student student, Assignment assignment)
        {
            student.GetAllAssignments().Add(assignment);
        }

        public static Assignment GetOneAssignment(Student student, string name )
        {
            var assignments = student.GetAllAssignments();
            foreach(Assignment assignment in assignments) {
                if (assignment.Name == name)
                {
                    return assignment;
                }
            }
            return null;
        }

        public static float GetStudentAverage(Student student)
        {
            int sum = 0;
            int count = 0;
            List<Assignment> assignments = student.GetAllAssignments();

            foreach (Assignment assignment in assignments)
            {
                sum += assignment.Score;
                count++;
            }
            return sum / (float)count;
        }
    }
}
