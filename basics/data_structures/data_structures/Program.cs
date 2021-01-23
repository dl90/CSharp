using System;

namespace data_structures
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestCustomLinkedList();
            // TestStringBuilder();
        }

        static void TestCustomLinkedList()
        {
            CustomLinkedList list = new CustomLinkedList();
            list.InsertFront("test");
            list.InsertBack(1);
            list.InsertBack(2);
            list.InsertBack(3);
            list.InsertFront(0);
            list.Print();
        }

        static void TestStringBuilder()
        {
            var sb = new System.Text.StringBuilder("initial");
            sb.Append(" First");
            sb.Insert(0, " ");
            string built = sb.ToString();
            Console.WriteLine(built);
        }
    }
}
