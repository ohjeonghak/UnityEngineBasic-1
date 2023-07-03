using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class A
{
    public int name;

    public void SayHi()
    {
        Console.WriteLine("A");
    }
}

public class B : A
{
    new public int name;

    new public void SayHi()
    {
        Console.WriteLine("B");
    }
}

public class Tester
{
    public void Test()
    {
        A a = new A();
        B b = new B();
        a.SayHi(); // -> A
        b.SayHi(); // -> B

        a = b;
        a.SayHi(); // -> A
        ((B)a).SayHi(); // -> B
    }
}


namespace Collections
{
    internal class MyDynamicArray<T> : IEnumerable<T>
        where T : IComparable<T> // 인스턴스를 정렬하는 형식 고유의 비교 메서드를 만들기 위해 값 형식 또는 클래스에서 구현하는 일반화된 비교 메서드를 정의합니다.
    {
        private static int DEFAULT_SIZE = 1;
        public int Count => _count;
        public int Capacity => _items.Length;
        private T[] _items = new T[DEFAULT_SIZE];
        private int _count;

        /// <summary>
        /// 삽입 알고리즘
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            // 공간이 모자라다면 더 큰배열을 만들고 아이템 복제
            if (_count == _items.Length)
            {
                T[] tmpItems = new T[_count * 2];
                Array.Copy(_items, 0, tmpItems, 0, _count);
                _items = tmpItems;
            }

            _items[_count++] = item;
        }

        /// <summary>
        /// 탐색 알고리즘
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            // Comparer comparer = Comparer.Default;
            // Comparer.Default : 해당 타입의 default 비교연산자를 가지고 비교해서 결과를 반환하는 기능을 가진 객체
            for (int i = 0; i < _count; i++)
            {
                if (Comparer<T>.Default.CompareTo(_items[i],item) == 0)
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// 삭제 알고리즘
        /// </summary>
        /// <returns> 삭제 여부 </returns>
        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index < 0)
                return false;

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count--;
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator();
        }

        public struct Enumerator : IEnumerator<T>
        {
            public T Current => _data._items[_index];

            object IEnumerator.Current => _data._items[_index];

            private MyDynamicArray<T> _data;
            private int _index;
            public Enumerator(MyDynamicArray<T> data)
            {
                _data = data;
                _index = -1;
            }
            public void Dispose() //가비지 컬렉터(GC)가 메모리를 자동으로 관리한다.
                                  //필요 없는 클래스의 인스턴스를 메모리에서 바로 지우는 게 아니라,
                                  //조건이 될 때까지 기다렸다가 지우기 때문에 클래스를 지웠다고 해도 그게 실제로 바로 삭제되는 것은 아니다.
                                  //일반적인 메모리라면 GC에 맡겨도 상관이 없지만,
                                  //관리되지 않는(Unmanaged, Native) 리소스는 즉각 해제해야 하는 경우가 생기는데,
                                  //그럴 때 필요한 것이 Dispose이다.
            {
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _data._count;
            }

            public void Reset()
            {
                _index = -1;
            }
        }
    }
}