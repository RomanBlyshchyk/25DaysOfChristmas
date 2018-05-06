using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    class Day17
    {
        public static void Main(string[] args)
        {
            var list = new CircularLinkedList<int>(0);

            for (int i = 0; i < 2017; i++)
            {
                for (int j = 0; j < 349; j++)
                {
                    list.Next();
                }

                list.AddAfter(list.currentPosition, i + 1);
                list.Next();
            }

            Console.WriteLine(list.currentPosition.Next.Value);
            Console.ReadKey();
        }
    }

    public class CircularLinkedList<T> : LinkedList<T>
    {
        public LinkedListNode<T> currentPosition;


        public CircularLinkedList(T firstValue)
        {
            AddFirst(new LinkedListNode<T>(firstValue));
            currentPosition = First;
        }


        public void Next()
        {
            currentPosition = currentPosition.Next ?? currentPosition.List.First;
        }
    }
}
