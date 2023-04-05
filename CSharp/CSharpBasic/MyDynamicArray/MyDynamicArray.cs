using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class MyDynamicArray
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
        public object this[int index]
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
        private object[] _data = new object[DEFAULT_SIZE];
        private int _count; //실제 데이터 크기
    
        //동적배열의 삽입알고리즘
        //일반적인 경우에 O(1)
        //공간이 모자랄 경우에 기존 데이터를 전부 순회하면서 복제해야하기때문에 O(n) (데이터 n개일 때)
        public void Add(object item)
        {
            //삽입 공간이 모자랄 경우
            if(_count >= _data.Length)
            {
                //1. 더 큰 크기의 새로운 배열을 만든다.
                object[] tmp = new object[_data.Length + (int)Math.Ceiling(Math.Log10(_data.Length)) + DEFAULT_SIZE];
                
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
        public bool Contains(object item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_data[i] == item) 
                    return true;
            }
            return false;
        }

        public int FindIndex(object item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_data[i] == item)
                    return i;
            }
            return -1;
        }

        public object Find(Predicate<object> match) //<>안에 비교하려는 대상의 타입을 받음
        {
            for (int i = 0; i < _count; i++)
            {
                if (match.Invoke(_data[i]))
                    return _data[i];
            }

            return null;
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
            _data[_count] = default(int); //마지막 데이터 지워줌 앞으로 복제해준거니까 원래 있던거 지움
        }

        public bool Remove(object item)
        {
            int index = FindIndex(item);

            if(index < 0)
                return false;

            RemoveAt(index);
            return true;
        }
    }
}
