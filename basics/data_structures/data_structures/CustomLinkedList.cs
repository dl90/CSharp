using System;

namespace data_structures
{
    class CustomLinkedList
    {
        private CustomNode FirstNode;
        private CustomNode LastNode;
        private int Length;

        public CustomLinkedList()
        {
            FirstNode = LastNode = null;
            Length = 0;
        }

        public void InsertFront(object node)
        {
            if (Length == 0)
            {
                FirstNode = LastNode = new CustomNode(node);
                Length++;
            }
            else
            {
                CustomNode prevFirstNode = FirstNode;
                FirstNode = new CustomNode(node);
                FirstNode.Next = prevFirstNode;
                Length++;
            }
        }

        public void InsertBack(object node)
        {
            if (Length == 0)
            {
                FirstNode = LastNode = new CustomNode(node);
                Length++;
            }
            else
            {
                LastNode = LastNode.Next = new CustomNode(node);
                Length++;
            }
        }

        public object RemoveFront()
        {
            if (Length == 0)
            {
                throw new Exception("List is empty");
            }

            object data = FirstNode.Data;
            if (FirstNode == LastNode)
            {
                FirstNode = LastNode = null;
                Length--;
            }
            else
            {
                FirstNode = FirstNode.Next;
                Length--;
            }
            return data;
        }

        public object RemoveBack()
        {
            if (Length == 0)
            {
                throw new Exception("List is empty");
            }

            object data = LastNode.Data;
            if (FirstNode == LastNode)
            {
                FirstNode = LastNode = null;
                Length--;
            }
            else
            {
                CustomNode curr = FirstNode;
                while (curr.Next != LastNode)
                {
                    curr = curr.Next;
                }

                LastNode = curr;
                LastNode.Next = null;
                Length--;
            }
            return data;
        }

        public void Print()
        {
            if (Length == 0)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                CustomNode curr = FirstNode;
                while (curr != null)
                {
                    Console.Write($" {curr.Data} |");
                    curr = curr.Next;
                }
                Console.Write("\n");
            }
        }
    }
}
