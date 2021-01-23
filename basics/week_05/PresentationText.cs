using System;

namespace week_05
{
    class PresentationText: Presentation
    {
        public int FontSize { get; set; }
        public string FontName { get; set; }

        public PresentationText()
        {
            Console.WriteLine("text constructor");
        }

        public PresentationText(string x): base(x)
        {
            Console.WriteLine($"text constructor {x}");
        }

        public void AddHyperlink(string link)
        {
            Console.WriteLine("added hyperlink");
        }

        public override void Copy()
        {
            base.Copy();
            Console.WriteLine("method overridden");
        }
    }
}
