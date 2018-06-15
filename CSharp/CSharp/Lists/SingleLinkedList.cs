using System.Collections;
using System.Collections.Generic;

namespace DataStructures_CSharp.Lists
{
    public abstract class SingleLinkedList<T> : IEnumerable<T>, IEnumerator<T>, System.IDisposable where T : System.IComparable
    {
        protected ListNode<T> headNode = null;
        protected ListNode<T> tailNode = null;
        public int Count = 0;

        #region IEnumerator<T>
        private ListNode<T> currentNode;
        private bool enumerationStarted = false;
        public T Current
        {
            get
            {
                if (this.enumerationStarted)
                    return this.currentNode.Value;
                else
                    throw new System.InvalidOperationException("Enumeration must be started. Call MoveNext.");
            }
        }

        object IEnumerator.Current => this.Current;

        public bool MoveNext()
        {
            if (this.enumerationStarted == false && this.currentNode == null)
            {
                this.currentNode = this.headNode;
                this.enumerationStarted = true;
                return true;
            }

            if (this.currentNode.Next == null)
                return false;

            this.currentNode = this.currentNode.Next;
            return true;
        }

        public void Reset()
        {
            this.currentNode = null;
            this.enumerationStarted = false;
        }
        #endregion

        #region IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> current = this.headNode;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        #region Operators
        public T this[int key]
        {
            get
            {
                return this.GetAt(key);
            }
        }
        #endregion

        public SingleLinkedList()
        {

        }

        public SingleLinkedList(IEnumerable<T> collection)
        {

        }

        public abstract void Add(T valueToAdd);

        public abstract void Add(IEnumerable<T> collection);

        protected abstract T GetAt(int index);

        public abstract void Remove(T valueToRemove);

        public abstract void RemoveAt(int index);

        public abstract void Dispose();


    }
}
