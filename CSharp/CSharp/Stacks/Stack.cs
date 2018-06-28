using DataStructures_CSharp.Nodes;
using System;
using System.Collections.Generic;

namespace DataStructures_CSharp.Stacks
{
    public class Stack<T> : IDisposable where T : IComparable
    {
        protected LinkedNode<T> headNodeOfStack = null;

        public Stack()
        {

        }

        public Stack(T value)
        {
            this.Push(value);
        }

        public Stack(IEnumerable<T> values)
        {
            using (IEnumerator<T> collection = values.GetEnumerator())
            {
                while (collection.MoveNext())
                {
                    this.Push(collection.Current);
                }
            }
        }

        /// <summary>
        /// <para>The current size of the stack.</para>
        /// <para>Expected Runtime: O(1)</para>
        /// </summary>
        public int Count { get; protected set; } = 0;

        /// <summary>
        /// <para>'Gets' the value thats ontop of the stack.</para>
        /// <para>Expected Runtime: O(1)</para>
        /// </summary>
        /// <returns></returns>
        public T Peak()
        {
            return this.headNodeOfStack.Value;
        }

        /// <summary>
        /// <para>Pop the top value off of the stack.</para>
        /// <para>Expected Runtime: O(1)</para>
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            this.Count--;

            using (LinkedNode<T> node = this.headNodeOfStack)
            {
                this.headNodeOfStack = this.headNodeOfStack.Next;

                return node.Value;
            }
        }

        /// <summary>
        /// <para>Push <param name="value">value</param> onto the stack.</para>
        /// <para>Expected Runtime: O(1)</para>
        /// </summary>
        public void Push(T value)
        {
            LinkedNode<T> newNode = new LinkedNode<T>(value);

            newNode.Next = this.headNodeOfStack;
            this.headNodeOfStack = newNode;

            this.Count++;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    for (int i = this.Count; i > 0; i--)
                    {
                        this.Pop();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Stack() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
