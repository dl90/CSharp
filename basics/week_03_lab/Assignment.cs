namespace week_03_lab
{
    class Assignment
    {
        private int score;
        private string name;

        public Assignment(string name, int score = 0)
        {
            Score = score;
            Name = name;
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                if (value >= 0)
                {
                    score = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Trim().Length >= 0)
                {
                    name = value;
                }
            }
        }
    }
}
