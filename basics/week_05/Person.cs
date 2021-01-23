using System;

namespace week_05
{
    class Person
    {
        private string _name;
        private readonly int SIN;

        public Person()
        {
            Console.WriteLine("default constructor");
        }

        public Person(string name) : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if(value.Length > 0) this._name = value;
            }
        }

        public void Introduce(string to)
        {
            Console.WriteLine("Hi {0} I'm {1}", to, Name);
        }

        // factory method
        public static Person getPerson(string name)
        {
            Person p = new Person();
            p.Name = name;
            return p;
        }
    }
}
