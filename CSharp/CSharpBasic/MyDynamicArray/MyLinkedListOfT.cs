using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Node<T>
    {
        public T Value;  //노드에 있는 값
        public Node<T> Prev;
        public Node<T> Next;

        public Node(T value)
        {
            Value = value;
        }
    }

    internal class MyLinkedList<T> : IEnumerable<T>
    {
        public Node<T> First => _first;
        private Node<T> _first;

        public Node<T> Last => _last;
        private Node<T> _last;

        private Node<T> _tmp;

        //삽입 알고리즘 (가장 앞에 삽입)
        //O(1)
        public void AddFirst(T value)
        {
            _tmp = new Node<T>(value);  //새 노드 만듦

            //노드가 만약 하나 이상 존재한다면
            if(_first != null)
            {
                _tmp.Next = _first;
                _first.Prev = _tmp;
            }
            else
            {
                _last = _tmp;
            }

            _first = _tmp;
        }

        //삽입 알고리즘 (가장 뒤에 삽입)
        //O(1)
        public void AddLast(T value)
        {
            _tmp = new Node<T>(value);  //새 노드 만듦

            //노드가 만약 하나 이상 존재한다면
            if (_last != null)
            {
                _tmp.Prev = _last;
                _last.Next = _tmp;
            }
            else
            {
                _first = _tmp;
            }

            _last = _tmp;
        }

        //삽입 알고리즘 (특정 노드 앞에 삽입)
        //O(1)
        //node는 앞 노드, value는 삽입할 값
        public void AddBefore(Node<T> node, T value)
        {
            _tmp = new Node<T>(value);
            if(node.Prev != null)
            {
                node.Prev.Next = _tmp;
                _tmp.Prev = node.Prev;
            }
            else
            {
                _first = _tmp;
            }

            node.Prev= _tmp;
            _tmp.Next = node;
        }

        //삽입 알고리즘 (특정 노드 앞에 삽입)
        //O(1)
        public void AddAfter(Node<T> node, T value)
        {
            _tmp = new Node<T>(value);

            if (node.Next != null)
            {
                node.Next.Prev = _tmp;
                _tmp.Next = node.Next;
            }
            else
            {
                _last = _tmp;
            }

            _tmp.Prev = node;
            node.Next = _tmp;
        }

        //탐색 알고리즘
        public Node<T> Find(T value)
        {
            _tmp = _first;
            while (_tmp != null)
            {
                if (Comparer<T>.Default.Compare(_tmp.Value, value) == 0)
                    return _tmp;

                _tmp = _tmp.Next;
            }
            return null;
        }

        //뒤에서부터 찾기
        public Node<T> FindLast(T value)
        {
            _tmp = _last;
            while (_tmp != null)
            {
                if (Comparer<T>.Default.Compare(_tmp.Value, value) == 0)
                    return _tmp;

                _tmp = _tmp.Prev;
            }
            return null;
        }

        //삭제 알고리즘
        public bool Remove(Node<T> node)
        {
            if(node == null)
            {
                return false;
            }
            else
            {
                if(node.Prev != null)
                {
                    node.Prev.Next = node.Next;
                }
                else
                {
                    _first = node.Next;
                }

                if(node.Next != null)
                {
                    node.Next.Prev = node.Prev;
                }
                else
                {
                    _last = node.Prev;
                }

                return true;
            }

        }

        //특정 값을 지우고 싶을 때 find로 찾아서 remove함
        public bool Remove(T value)
        {
            return Remove(Find(value));
        }

        public bool RemoveLast(T value)
        {
            return Remove(FindLast(value));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(_first);
        }

        public struct Enumerator : IEnumerator<T>
        {
            public T Current => _currentNode.Value;

            object IEnumerator.Current => _currentNode.Value;

            private Node<T> _currentNode; //현재 가리키고 있는 노드
            private Node<T> _first; //iterator는 무조건 앞에서부터 탐색

            public Enumerator(Node<T> first) //구조체 멤버필드 전부 초기화해줘야함
            {
                _first = first;
                _currentNode = null;
                _firstFlag = false;
            }

            public bool FirstFlag  //플래그 세울 때마다 현재 노드가 first되는거
            {
                get => _firstFlag;
                set
                {
                    if (value)
                        _currentNode = _first;

                    _firstFlag = value;
                }
            }
            private bool _firstFlag;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if(_firstFlag == false)
                    FirstFlag = true;
                else
                    _currentNode = _currentNode.Next;

                return _currentNode != null;
            }

            public void Reset()
            {
                _currentNode = null;
                FirstFlag = false;
            }
        }
    }
}
