using System.Collections;
using System.Collections.Generic; // google 검색해보셈
using System.Xml.Schema;

// using 의 사용처
// 1. namespace 를 가져다쓸때
// 2. namespace 간 멤버 호출의 모호할떄 (다른 namespace에 동일한 이름의 타입이 정의되어있을 떄)
// 3. IDisposable 객체의 dispose 함수 호출을 보장할 때

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            #region Queue 
            Queue<int> queue1 = new Queue<int>();
            queue1.Enqueue(3);
            queue1.Enqueue(2);
            queue1.Enqueue(5);
            


            while (queue1.Count > 0)
            {
                if (queue1.Peek() > 1)
                    Console.WriteLine(queue1.Dequeue());
            }
            #endregion

            #region Stack
            Stack<float> stack1 = new Stack<float>();
            stack1.Push(3);
            stack1.Push(2);
            stack1.Push(5);

            while (stack1.Count > 0)
            {
                if (stack1.Peek() > 1)
                    Console.WriteLine(stack1.Pop());
            }
            #endregion

            #region HashSet
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
            myDynamicArray.Add(2);
            myDynamicArray.Add(5);
            myDynamicArray.Add(3);
            myDynamicArray.Add(6);

            IEnumerator e1 = myDynamicArray.GetEnumerator(); //non genelic -> 특별하지 않으면 사용하지 않음
            while (e1.MoveNext())                            // genelic 과 non genelic 차이는 object 차이
            {
                Console.WriteLine(e1.Current);
            }

            MyDynamicArray<int> intDA = new MyDynamicArray<int>();
            intDA.Add(3);
            intDA.Add(2);
            intDA.Add(5);
            intDA.Add(4);

            IEnumerator<int> intDAEnum = intDA.GetEnumerator(); // genelic 형태
            while (intDAEnum.MoveNext())
            {
                Console.WriteLine(intDAEnum.Current);
            }
            intDAEnum.Reset();
            intDAEnum.Dispose();


            // IDisposable 객체의 Dispose() 함수의 호출을 보장하는 문구.
            using (IEnumerator<int> intDAEnum2 = intDA.GetEnumerator())
            {
                while (intDAEnum.MoveNext())
                {
                    Console.WriteLine(intDAEnum.Current);
                }
                intDAEnum.Reset();
            }


            // foreach 문
            // IEnumerable 을 순회하는 구문.
            //↑ While 문을 편리하게 줄여줌
            foreach (int item in intDA) 
            {
                Console.WriteLine(item);
            }
            ArrayList arrList = new ArrayList();
            arrList.Add(3);
            arrList.Add("carl");
            arrList.Contains(3); // 결과는 false.
                                 // 왜? Add(3) 호출시 Boxing 으로 인해 만들어진 객체와
                                 // Contains(3) 호출시 Boxing으로 인 해 만들어진 객체는 다르기떄문.


            List<int> list = new List<int>();
            list.Add(3);
            list.Remove(3);
            list.IndexOf(3);
            list.Contains(3);
            list.Find(x => x > 1);
            list.Insert(0, 2);

            #endregion
        }
    }
}
    