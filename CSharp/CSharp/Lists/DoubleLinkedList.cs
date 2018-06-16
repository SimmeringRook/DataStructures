using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures_CSharp.Lists
{
    public class DoubleLinkedList<T> : SingleLinkedList<T> where T : IComparable
    {
        public override void Add(T valueToAdd)
        {
            this.Count++;
            if (this.Count < 2)
            {
                if (this.headNode == null && this.tailNode == null)
                {
                    this.headNode = new ListNode<T>(valueToAdd);
                    this.tailNode = this.headNode;
                }
                else
                {
                    this.tailNode = new ListNode<T>(valueToAdd);
                }

                this.headNode.Next = this.tailNode;
                this.headNode.Previous = this.tailNode;

                this.tailNode.Next = this.headNode;
                this.tailNode.Previous = this.headNode;
            }
            else
            {
                ListNode<T> newNode = new ListNode<T>(valueToAdd);
                newNode.InsertBetween(this.tailNode.Previous, this.headNode);
            }
        }

        public override void Add(IEnumerable<T> collection)
        {
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    this.Add(enumerator.Current);
                }
            }
        }

        public DoubleLinkedList<T> Copy()
        {
            return this.CopyRange(0, this.Count);
        }

        public DoubleLinkedList<T> CopyRange(int startIndex, int length)
        {
            DoubleLinkedList<T> copyOfThis = new DoubleLinkedList<T>();

            for (int i = startIndex; i < (startIndex + length); i++)
            {
                copyOfThis.Add(this[i]);
            }

            return copyOfThis;
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T value)
        {
            ListNode<T> currentNode = this.headNode;
            for (int i = 0; i < index; i++)
            {
                if (i == index)
                {
                    ListNode<T> newNode = new ListNode<T>(value);
                    newNode.InsertBetween(currentNode.Previous, currentNode);
                }
            }
            this.Count++;
        }

        public void InsertRange(int startIndex, IEnumerable<T> values)
        {
            ListNode<T> currentNode = this.headNode;

            for (int i = 0; i < this.Count; i++)
            {
                if (i >= startIndex && i <= startIndex + values.Count())
                {
                    this.Insert(i, values.ElementAt(i - startIndex));
                }
            }
        }

        public void Sort(bool ascending = true)
        {
            if (ascending)
            {

            }
            else
            {

            }
        }

        public override void Remove(T valueToRemove)
        {
            this.Count--;

            ListNode<T> currentNode = this.headNode;

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Equals(valueToRemove))
                    currentNode.Remove();
                currentNode = currentNode.Next;
            }

            if (this.Count == 0)
            {
                this.headNode = null;
                this.tailNode = null;
            }
        }

        public override void RemoveAt(int index)
        {
            this.Remove(this[index]);
        }

        public void RemoveRange(int startIndex, int length)
        {
            ListNode<T> currentNode = this.tailNode;

            for (int i = this.Count; i >= 0; i--)
            {
                if (i >= startIndex && i <= startIndex + length)
                {
                    this.Remove(this[i]);
                }
                currentNode = currentNode.Previous;
            }

            if (this.Count == 0)
            {
                this.headNode = null;
                this.tailNode = null;
            }
        }

        public void Reverse()
        {
            DoubleLinkedList<T> copy = this.Copy();

            this.headNode = null;
            this.tailNode = null;

            ListNode<T> currentNode = copy.tailNode;
            for (int i = 0; i < copy.Count; i++)
            {
                this.Add(currentNode.Value);

                currentNode = currentNode.Previous;
            }
        }

        protected override T GetAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                string exceptionMessage = (index < 0) ? " < 0" : " >= Count";
                throw new IndexOutOfRangeException(
                    "The provided index (" + index.ToString() + ") was invalid. index cannot be" + exceptionMessage
                    );
            }

            if (index == 0)
            {
                return this.headNode.Value;
            }

            if (index == this.Count - 1)
            {
                return this.tailNode.Value;
            }

            ListNode<T> currentNode = null;

            if (index >= this.Count / 2)
            {
                currentNode = this.tailNode;
                for (int i = this.Count; i >= index; i--)
                {
                    if (i == index)
                    {
                        return currentNode.Value;
                    }
                    currentNode = currentNode.Previous;
                }
            }
            else
            {
                currentNode = this.headNode;
                for (int i = 0; i <= index; i++)
                {
                    if (i == index)
                    {
                        return currentNode.Value;
                    }
                    currentNode = currentNode.Next;
                }
            }

            //Classic "this should never happen"
            throw new Exception("The provided index was valid, but the UnorderedSingleLinkedList was unable to retrieve the element.");
        }
    }
}
