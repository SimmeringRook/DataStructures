using System;
using System.Collections.Generic;

namespace DataStructures_CSharp.Lists
{
    public class OrderedSingleLinkedList<T> : SingleLinkedList<T> where T : IComparable
    {
        private bool isAscendingOrder = true;

        public override void Add(T valueToAdd)
        {
            this.Count++;
            if (this.headNode == null)
            {
                this.headNode = new ListNode<T>(valueToAdd);
                this.tailNode = this.headNode;
            }
            else if (this.headNode == this.tailNode)
            {
                if (valueToAdd.CompareTo(this.headNode.Value) < 0)
                {
                    if (isAscendingOrder)
                    {
                        this.headNode = new ListNode<T>(valueToAdd)
                        {
                            Next = this.tailNode
                        };
                    }
                    else
                    {
                        this.tailNode = new ListNode<T>(valueToAdd);
                        this.headNode.Next = this.tailNode;
                    }
                    
                }
                else
                {
                    if (isAscendingOrder)
                    {
                        this.tailNode = new ListNode<T>(valueToAdd);
                        this.headNode.Next = this.tailNode;
                    }
                    else
                    {
                        this.headNode = new ListNode<T>(valueToAdd)
                        {
                            Next = this.tailNode
                        };
                    }
                }
            }
            else
            {
                ListNode<T> currentNode = this.headNode;
                ListNode<T> previousNode = currentNode;

                if (isAscendingOrder)
                {
                   
                    for (int i = 0; i < this.Count -1; i++)
                    {
                        if (valueToAdd.CompareTo(currentNode.Value) < 0)
                        {
                            this.Count--;
                            this.Insert(i, valueToAdd);

                            return;
                        }
                        previousNode = currentNode;
                        currentNode = currentNode.Next;
                    }
                }
                else
                {
                    for (int i = 0; i < this.Count -1; i++)
                    {
                        if (valueToAdd.CompareTo(currentNode.Value) > 0)
                        {
                            this.Count--;
                            this.Insert(i, valueToAdd);

                            return;
                        }
                        previousNode = currentNode;
                        currentNode = currentNode.Next;
                    }
                }

                this.tailNode.Next = new ListNode<T>(valueToAdd);
                this.tailNode = this.tailNode.Next;
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

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Remove(T valueToRemove)
        {
            this.Count--;
            ListNode<T> nodeToDispose;
            ListNode<T> previousNode = null;


            if (valueToRemove.Equals(this.headNode.Value))
            {
                if (this.headNode == this.tailNode)
                {
                    this.headNode = null;
                    this.tailNode = null;
                }
                else
                {
                    nodeToDispose = this.headNode;
                    this.headNode = nodeToDispose.Next;
                }
            }
            else
            {
                nodeToDispose = this.headNode;
                for (int i = 0; i <= this.Count; i++)
                {
                    if (nodeToDispose.Value.Equals(valueToRemove))
                    {
                        if (nodeToDispose == this.tailNode)
                        {
                            this.tailNode = previousNode;
                            this.tailNode.Next = null;
                        }

                        previousNode.Next = nodeToDispose.Next;
                        return;
                    }
                    previousNode = nodeToDispose;
                    nodeToDispose = nodeToDispose.Next;
                }
            }
        }

        public override void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                string exceptionMessage = (index < 0) ? " < 0" : " >= Count";
                throw new IndexOutOfRangeException(
                    "The provided index (" + index.ToString() + ") was invalid. index cannot be" + exceptionMessage
                    );
            }

            this.Count--;
            ListNode<T> nodeToDispose;
            ListNode<T> previousNode = null;

            if (index == 0)
            {
                if (this.headNode == this.tailNode)
                {
                    this.headNode = null;
                    this.tailNode = null;
                }
                else
                {
                    nodeToDispose = this.headNode;
                    this.headNode = this.headNode.Next;
                }
            }
            else
            {
                nodeToDispose = this.headNode;
                for (int i = 0; i <= this.Count; i++)
                {
                    if (i == index)
                    {
                        if (nodeToDispose == this.tailNode)
                        {
                            this.tailNode = previousNode;
                            this.tailNode.Next = null;
                        }

                        //Dispose
                        previousNode.Next = nodeToDispose.Next;
                        return;
                    }
                    previousNode = nodeToDispose;
                    nodeToDispose = nodeToDispose.Next;
                }
            }
        }

        public void Reverse()
        {
            this.isAscendingOrder = !this.isAscendingOrder;

            UnorderedSingleLinkedList<T> temp = new UnorderedSingleLinkedList<T>();
            foreach(T value in this)
            {
                temp.Add(value);
            }

            this.Count = 0;
            this.headNode = null;
            this.tailNode = null;

            for (int i = 0; i < temp.Count; i++)
            {
                this.Insert(0, temp[i]);
            }
        }

        private void Insert(int index, T valueToInsert)
        {
            if (index < 0 || index > this.Count)
            {
                string exceptionMessage = (index < 0) ? " < 0" : " >= Count";
                throw new IndexOutOfRangeException(
                    "The provided index (" + index.ToString() + ") was invalid. index cannot be" + exceptionMessage
                    );
            }
            this.Count++;
            ListNode<T> newNode = new ListNode<T>(valueToInsert);

            if (index == 0)
            {
                newNode.Next = this.headNode;
                this.headNode = newNode;
                if (this.tailNode == null)
                    this.tailNode = this.headNode;
                
            }
            else if (index == this.Count - 1)
            {
                this.tailNode.Next = newNode;
                this.tailNode = newNode;
            }
            else
            {
                ListNode<T> currentNode = this.headNode;
                ListNode<T> previousNode = this.headNode;
                for (int i = 0; i <= this.Count; i++)
                {
                    if (i == index)
                    {
                        //Dispose
                        previousNode.Next = newNode;
                        newNode.Next = currentNode;
                        return;
                    }
                    previousNode = currentNode;
                    currentNode = currentNode.Next;
                }
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

            ListNode<T> currentNode = this.headNode;
            for (int i = 0; i < this.Count; i++)
            {
                if (i == index)
                {
                    return currentNode.Value;
                }
                currentNode = currentNode.Next;
            }

            //Classic "this should never happen"
            throw new Exception("The provided index was valid, but the UnorderedSingleLinkedList was unable to retrieve the element.");
        }
    }
}
