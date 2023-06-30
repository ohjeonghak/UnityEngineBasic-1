﻿using System.Collections;
using System.Collections.Generic; // google 검색해보셈


namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue1 = new Queue<int>();
            queue1.Enqueue(3);
            queue1.Enqueue(2);
            queue1.Enqueue(5);

            while (queue1.Count > 0)
            {
                if (queue1.Peek() > 1)
                Console.WriteLine(queue1.Dequeue());
            }

            Stack<float> stack1 = new Stack<float>();
            stack1.Push(3);
            stack1.Push(2);
            stack1.Push(5);

            while (stack1.Count > 0)
            {
                if (stack1.Peek() > 1)
                    Console.WriteLine(stack1.Pop());
            }

            HashSet<int> visited = new HashSet<int>();
            if (visited.Add(3))
            { 
                Console.WriteLine("Added 3 in hashet");
            }
            if (visited.Remove(2))
            {
                Console.WriteLine("Removed 2 in hashset");
            }

            MyDynamicArray myDynamicArray = new MyDynamicArray();
            IEnumerator e1 = myDynamicArray.GetEnumerator();
            Console.WriteLine(e1.Current);
            e1.MoveNext();
            Console.WriteLine(e1.Current);
            e1.MoveNext();
            Console.WriteLine(e1.Current);
            e1.MoveNext();
            Console.WriteLine(e1.Current);
        }
    }
}