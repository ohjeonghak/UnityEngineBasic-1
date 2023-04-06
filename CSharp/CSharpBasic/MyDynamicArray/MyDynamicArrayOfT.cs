using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    //Generic : 클래스 또는 함수의 틀을 만드는 디자인, 특정 타입에 대해 클래스 혹은 함수가 사용될 경우,
    //          '컴파일 타임'에 해당 타입에 대한 클래스 혹은 함수가 정의됨
    //generic class의 where 제한자 : generic의 타입에 제한을 걸 때 사용
    //ex. T 타입은 반드시 IComparable<T> 또는 IComparable<T>를 상속받은 타입이어야함
    internal class MyDynamicArray<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public int Capacity //배열 크기
        {
            get
            {
                return _data.Length;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        //인덱서 정의
        public T this[int index]
        {
            get
            {
                return _data[index];
            }
            set
            {
                _data[index] = value;
            }
        }
        private const int DEFAULT_SIZE = 1;
        private T[] _data = new T[DEFAULT_SIZE];
        private int _count; //실제 데이터 크기
    
        //동적배열의 삽입알고리즘
        //일반적인 경우에 O(1)
        //공간이 모자랄 경우에 기존 데이터를 전부 순회하면서 복제해야하기때문에 O(n) (데이터 n개일 때)
        public void Add(T item)
        {
            //삽입 공간이 모자랄 경우
            if(_count >= _data.Length)
            {
                //1. 더 큰 크기의 새로운 배열을 만든다.
                T[] tmp = new T[_data.Length + (int)Math.Ceiling(Math.Log10(_data.Length)) + DEFAULT_SIZE];
                
                //2. 기존 데이터를 복제한다.
                for (int i = 0; i < _count; i++)
                {
                    tmp[i] = _data[i];
                }

                //3. 데이터배열 참조를 새로운 배열로 바꿔준다.
                _data = tmp;
            }
            _data[_count] = item;
            _count++;
        }

        //탐색 알고리즘
        //O(n) 빅오 - 최악의 경우만 따짐, 데이터가 맨끝에 있거나 없는 경우가 최악, 맨 앞에 있다면 최선.O(1)
        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                //if (Comparer<T>.Default.Compare(_data[i], item) == 0) 
                //    return true;

                if (item.CompareTo(_data[i]) == 0)
                    return true;
            }
            return false;
        }

        public int FindIndex(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                //if (Comparer<T>.Default.Compare(_data[i], item) == 0)
                //    return i;

                if (item.CompareTo(_data[i]) == 0)
                    return i;
            }
            return -1;
        }

        public object Find(Predicate<T> match) //<>안에 비교하려는 대상의 타입을 받음
        {
            for (int i = 0; i < _count; i++)
            {
                if (match.Invoke(_data[i]))
                    return _data[i];
            }

            return default(T);
        }

        //삭제 알고리즘
        //맨 앞을 지울 때가 최악, O(n)
        public void RemoveAt(int index)
        {
            //지우고자하는 인덱스 뒤부터 끝까지를 한칸씩 앞으로 당김
            for (int i = index; i < _count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _count--;
            _data[_count] = default(T); //마지막 데이터 지워줌 앞으로 복제해준거니까 원래 있던거 지움
        }

        public bool Remove(T item)
        {
            int index = FindIndex(item);

            if(index < 0)
                return false;

            RemoveAt(index);
            return true;
        }

        // 처음부터 끝까지 순회할 때 씀 자료구조마다 각각 안만들고 추상화해서 하려고(int 배열 char 배열 등 순회하는거 각각 따로 만들지x)
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
