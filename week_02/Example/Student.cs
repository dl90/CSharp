namespace Examples
{
    class Student
    {
        public string Name { get; set; } // property
        private int average;

        public Student(string name, int average)
        {
            Name = name;
            Average = average;
        }

        public int Average
        {
            get
            {
                return average;
            }
            set
            {
                if(value > 0 && value <= 100)
                {
                    average = value;
                }
            }
        }

        public string Grade()
        {
            if (average >= 90)
            {
                return "A";
            }

            else if (average >= 80)
            {
                return "B";
            }

            else if (average >= 70)
            {
                return "C";
            }

            else
            {
                return "F";
            }
        }
    }
}
