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
        private Node<T> current;

        public  MyLinkedListOfT(Node<T> current)
        {
           this .current = current;
        }

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
        public Node<T> Find(T target)
        {
            _tmp = _first;
            while (_tmp != null)
            {
                if (Comparer<T>.Default.Compare(_tmp.Value, target) == 0)
                    return _tmp;

                _tmp = _tmp.Next;
            }
            return null;
        }
        public Node<T> FindLast(T target)
        {
            _tmp = _first;
            while (_tmp != null)
            {
                if (Comparer<T>.Default.Compare(_tmp.Value, target) == 0)
                    return _tmp;

                _tmp = _tmp.prev;
            }
            return null;
        }
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
        // _tmp = _first
        // while ( _tmp != null)
        //{
        // if (match.Invoke(_tmp.Value))
        // retyrn _tmp;
        //
        // _tmp = _tmp.Next;
        //}

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
        //_tmp = _last;
        // while ( _tmp != null)
        //{
        // if (match.Invoke(_tmp.Value))
        // retyrn _tmp;
        //
        // _tmp = _tmp.Prev;
        //}
        public bool Remove(Node<T>node)//노드를 알고 있을때 경우
        {
            if (node == null)
              return false;
            
            else
            {
                if (node.prev != null)
                {
                    node.prev.Next = node.Next;
                }
                // 삭제하려는 노드가 first 일 경우 (이전 노드가 없으니까)
                else
                {
                    _first = node.Next;
                }

                if (node.Next != null)
                {
                    node.Next.prev = node.prev;
                }
                // 삭제하려는 노드가 last 일 경우(다음 노드가 없으니까)
                else
                {
                    _last = node.prev;
                }
                return true;
            }
        }
        public bool Remove(T value)
        {
            return Remove(Find(value));
        }
        public bool  RemoveLast(T value)
        {
            return Remove(FindLast(value));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }
      
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            public T Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            private MyLinkedListOfT<T> _linkedList;
            private Node<T> _currentNode;
            public Enumerator(MyLinkedListOfT<T> linkedList)
            {
                _linkedList = linkedList;
                _currentNode = null;
            }
            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_currentNode == null)
                {
                    _currentNode = _linkedList.First;
                }
                else
                {
                    _currentNode = _currentNode.Next;
                }
                return _currentNode != null;
            }

            public void Reset()
            {
                _currentNode = null;
            }
        }
    }
    
}
