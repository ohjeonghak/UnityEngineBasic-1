using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Node<T>
    {
        public T Value;
        public Node<T> prev;
        public Node<T> Next;

        public Node(T value) => Value = value;
    }


    internal class MyLinkedListOfT<T> : IEnumerable<T>// 전부 get 접근자
    {
        public Node<T> First => _first;
        public Node<T> Last => _last;
        private Node<T> _first, _last, _tmp;


        public void AddFirst(T value)
        {
            _tmp = new Node<T>(value);

            if (_first != null)
            {
                _tmp.Next = _first;
                _first.prev= _tmp;
            }
            else
            {
                _last= _tmp;
            }
       
            _first = _tmp;
        }

        public void AddLast(T value)  //라스트 뒤
        {
            _tmp = new Node<T>(value);

            if (_last != null)
            {
                _last.Next = _tmp;
                _tmp.prev = _last;
            }
            else
            {
                _first = _tmp;
            }
            
            _last = _tmp;
        }

        public void AddBefore(Node<T> node, T value) // 어떤부분 전
        {
            _tmp = new Node<T>(value);

            if (node.prev != null)
            {
                node.prev.Next= _tmp;
                _tmp.prev = node.prev;
            }
            else
            {
                _first= _tmp;
            }
             
            node.prev = _tmp;
            _tmp.Next = node;
        }

        public void AddAfter(Node<T> node, T value) // 어떤부분 앞
        {
            _tmp = new Node<T>(value);

            if (node.Next != null)
            {
                node.Next.prev= _tmp;
                _tmp.Next = node.Next;
            }
            else
            {
                _last= _tmp;
            }

            node.Next = _tmp;
            _tmp.prev = node;
        } //↓숙제... IEnumerable 구현까지.

        public Node<T> Find(Predicate<T> match)
        {
            Node<T> current = _first;

            while (current != null)
            {
                if (match (current.Value))
                { 
                    return current; 
                }

                current = _first.Next;
            }

            return null;
        }

        public Node<T> FindLast(Predicate<T> match)
        {
            Node<T> current = _last;

            while (current != null)
            {
                if (match(current.Value))
                {
                    return current;
                }

                current = _last.prev;
            }

            return null;
        }

        public bool Remove(T value)
        {
            Node<T> current = _first;

            while (current != null)
            {
                if (Remove(current.Value))
                {
                    return true;
                }

                current = _first.Next;
                
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <  current; i++)
            {
                yield return 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public struct Enumerator : IEnumerator<T>
        {
            public T Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
    
}
