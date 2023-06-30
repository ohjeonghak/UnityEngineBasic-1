using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class MyDynamicArray : IEnumerable// 면접이나 실사를 많이 하기 때문에 연습 많이 하시길
    {
        public int Lenght => _lenght;
        public int Capacity => _items.Length;
        private object[] _items;
        private int _lenght;

        /// <summary>
        ///  삽입 알고리즘
        /// </summary>
        /// <param name="item"></param>


        public void Add(object item)
        {
            //공간이 모자란다면 더 큰배열을 만들고 아이템 복제
            if ( _lenght == _items.Length)
            {
                object[] tmpItems = new object[_lenght * 2];
                Array.Copy(_items, 0, tmpItems, 0, _lenght);
                _items = tmpItems;
            }

            _items[_lenght] = item;
        }

        /// <summary>
        /// 탐색 알고리즘
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(object item)
        {
            Comparer comparer = Comparer.Default;
            // Comparer.Default : 해당 타입의 default 비교연산자를 가지고 비교해서 결과를 반환하는 기능을 가진 객체
            for (int i = 0; i < _lenght; i++)
            {
                if (comparer.Compare(_items[i], item) == 0)
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// 삭제 알고리즘
        /// </summary>
        /// <returns>삭제 여부</returns>
        public bool Remove(object item)
        {
            int index = IndexOf(item);

            if (index < 0)
                return false;

            for (int i = index; i < _lenght-1; i++)
            {
                _items[i] = _items[i + i];
            }
            _lenght--;
            return true;
        }

        //IEnumerator 인터페이스 구현 EX
        public IEnumerator GetEnumerator()
        {
            yield return 1;
            yield return 2;
            yield return 3;

            //for (int i = 0; i < _lenght; i++)
            //{
            //    yield return _items[i];  
            //}
        }
    }
    // Enumerating 중요(까먹지마)
    // 핵심요소 :1. 현재 가리키고 있는 아이템, 2. 그다음 아이템으로 넘어가는 기능, 3. 가르키고 있는 위치를 초기화하는 기능
    // interface > 1) IEnumerator
    //           1.   (get)Current : object
    //           2.   MoveNext() : bool
    //           3.   Reset() : void
    //             2) IEnumerable
    //           1.   GetEnumerator() : Ienumerator
}
