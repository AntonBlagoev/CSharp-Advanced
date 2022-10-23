using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class CustomDoublyLinkedList<T> : IEnumerable<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; private set; }
        public bool IsReversed { get; set; }
        public void AddFirst(T value)
        {
            this.Count++;

            if (this.Tail == null)
            {
                this.Head = this.Tail = new Node<T>(value);
                return;
            }
            if (IsReversed)
            {
                Node<T> node = new Node<T>(value);
                Head.Next = node;
                node.Previous = Head;
                Head = node;
            }
            else
            {
                Node<T> newNode = new Node<T>(value);
                newNode.Next = this.Head;
                this.Head.Previous = newNode;
                this.Head = newNode;
            }

           
            
        }
        public void AddLast(T value)
        {
            this.Count++;

            if (this.Head == null)
            {
                this.Tail = this.Head = new Node<T>(value);
                return;
            }
            if (IsReversed)
            {
                Node<T> node = new Node<T>(value);
                Tail.Previous = node;
                node.Next = Tail;
                Tail = node;
            }
            else
            {
                Node<T> newNode = new Node<T>(value);
                newNode.Previous = this.Tail;
                this.Tail.Next = newNode;
                this.Tail = newNode;
            }
            
        }
        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            Node<T> oldHead = this.Head;
            this.Head = this.Head.Next;
            if (this.Head != null)
            {
                this.Head.Previous = null;
            }
            else
            {
                this.Tail = null;
            }
            this.Count--;
            return oldHead.Value;
        }
        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            Node<T> oldTail = this.Tail;
            this.Tail = this.Tail.Previous;
            if (this.Tail != null)
            {
                this.Tail.Next = null;
            }
            else
            {
                this.Head = null;
            }
            this.Count--;
            return oldTail.Value;
        }
        public void ForEach(Action<T> callback)
        {
            Node<T> currentNode = this.Head;
            while (currentNode != null)
            {
                callback(currentNode.Value);
                if (IsReversed)
                {
                    currentNode = currentNode.Previous;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
        }
        public T[] ToArray()
        {

            //int[] array = new int[this.Count];
            //int counter = 0;
            //var currentNode = this.Head;
            //while (currentNode != null)
            //{
            //    array[counter] = currentNode.Value;
            //    currentNode = currentNode.Next;
            //    counter++;
            //}

            T[] array = new T[Count];
            int index = 0;
            ForEach(n =>
            {
                array[index++] = n;
            });

            return array;
        }

        public void Reverse()
        {
            IsReversed = !IsReversed;
            Node<T> oldhead = this.Head;
            this.Head = this.Tail;
            this.Tail = oldhead;
        }
        public void ForEachReverse(Action<T> callback)
        {
            Node<T> node = this.Tail;
            while (node != null)
            {
                callback(node.Value);
                node = node.Previous;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = this.Head;
            while (currentNode != null)
            {
                if (IsReversed)
                {
                    yield return currentNode.Value;
                    currentNode = currentNode.Previous;
                }
                else
                {
                    yield return currentNode.Value;
                    currentNode = currentNode.Next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
