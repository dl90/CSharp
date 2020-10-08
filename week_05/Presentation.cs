using System;

namespace week_05
{
    class Presentation
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Presentation()
        {
            Console.WriteLine("Presentation constructor");
        }

        public Presentation(string msg)
        {
            Console.WriteLine(msg);
        }

        public virtual void Copy()
        {
            Console.WriteLine("obj copied");
        }

        public void Duplicate()
        {
            Console.WriteLine("obj duplicated");
        }
    }
}
