using System;
using System.Collections.Generic;

namespace DataStructures_CSharp.Lists
{
    public class SortedLinkedList<T> : LinkedListBase<T> where T : IComparable
    {
        /// <summary>
        /// if Reverse() has been called, is -1
        /// otherwise, is 1
        /// </summary>
        protected int reversalFactor = 1;

        public SortedLinkedList()
        {
            this.Comparer = Comparer<T>.Default;
            this.isCachedMaximumValid = false;
        }

        public SortedLinkedList(IEnumerable<T> collection) : base(collection)
        {
        }

        public SortedLinkedList(IComparer<T> comparer) : base(comparer)
        {
        }

        public SortedLinkedList(IEnumerable<T> collection, IComparer<T> comparer) : base(collection, comparer)
        {
        }

        /// <summary>
        /// <para>Adds the provided value to the correct sorted position in the list using
        /// the provided <see cref="IComparer{T}"/>.</para>
        /// <para>Best case: O(1) for value being the new minimum/maximum value of the list.</para>
        /// <para>Expected Runtime: O(n), where n is the size of the list.</para>
        /// </summary>
        /// <param name="value"></param>
        public new void Add(T value)
        {
            
            if (this.Count() < 1)
            {
                //Otherwise, this is the first node, assign to head and tail
                this.AddFirstNode(value);
            }
            else
            {
                bool isLessThanCurrentMinimum = (this.Comparer.Compare(value, this.GetMinimum()) * this.reversalFactor) == -1;
                bool isGreaterThanCurrentMaximum = (this.Comparer.Compare(value, this.GetMaximum()) * this.reversalFactor) == 1;

                if (isLessThanCurrentMinimum)
                {
                    //Invalidate the minimum cache because we now
                    //have a value that preceeds the previous minimum
                    this.ReplaceMinimumNode(value);
                }
                
                if(isGreaterThanCurrentMaximum)
                {
                    //Invalidate the minimum cache because we now
                    //have a value that preceeds the previous minimum
                    this.ReplaceMaximumNode(value);
                }

                this.isCachedCountValid = false;
                if (this.Contains(value) == false)
                {
                    //We haven't added the node, find its position
                    this.Insert(value);
                }
            }
            
        }

        /// <summary>
        /// <para>Expected Runtime: 0(1)</para>
        /// </summary>
        /// <param name="value"></param>
        private void AddFirstNode(T value)
        {
            this.headNodeOfList = new LinkedNode<T>(value);
            this.tailNodeOfList = new LinkedNode<T>(value);
            this.isCachedMinimumValid = false;
            this.isCachedMaximumValid = false;
            this.isCachedCountValid = false;
        }

        /// <summary>
        /// <para>Expected Runtime: 0(1)</para>
        /// </summary>
        /// <param name="value"></param>
        private void ReplaceMinimumNode(T value)
        {
            LinkedNode<T> newMinimumNode = new LinkedNode<T>(value);
            this.isCachedMinimumValid = false;

            newMinimumNode.InsertBetween(null, this.headNodeOfList);
            this.headNodeOfList = newMinimumNode;
        }

        /// <summary>
        /// <para>Expected Runtime: 0(1)</para>
        /// </summary>
        /// <param name="value"></param>
        private void ReplaceMaximumNode(T value)
        {
            LinkedNode<T> newMaximumNode = new LinkedNode<T>(value);
            this.isCachedMaximumValid = false;

            if (this.Count() > 1)
            {
                this.tailNodeOfList.Next = newMaximumNode;
                this.tailNodeOfList = newMaximumNode;
            }
            else
            {
                this.tailNodeOfList = new LinkedNode<T>(value);
                this.headNodeOfList.Next = this.tailNodeOfList;
            }
        }

        /// <summary>
        /// <para>Gets the Maximum value using the current given <see cref="IComparer{T}"/>.</para>
        /// <para>Expected Runtime: O(1)</para>
        /// </summary>
        /// <returns></returns>
        public new T GetMaximum()
        {
            if (this.Count() == 0)
                throw new InvalidOperationException("Tried to find a maximum value in an empty list.");

            if (isCachedMaximumValid == false)
            {
                this.cachedMaximum = this.tailNodeOfList;
                this.isCachedMaximumValid = true;
            }

            return cachedMaximum.Value;
        }

        /// <summary>
        /// <para>Gets the Minimum value using the current given <see cref="IComparer{T}"/>.</para>
        /// <para>Expected Runtime: O(1)</para>
        /// </summary>
        /// <returns></returns>
        public new T GetMinimum()
        {
            if (this.Count() == 0)
                throw new InvalidOperationException("Tried to find a minimum value in an empty list.");

            if (isCachedMinimumValid == false)
            {
                this.cachedMinimum = this.headNodeOfList;
                this.isCachedMinimumValid = true;
            }

            return cachedMinimum.Value;
        }

        /// <summary>
        /// <para>Expected Runtime: 0(n), where n = this.Count()</para>
        /// </summary>
        /// <param name="value"></param>
        private void Insert(T value, int index = -1)
        {
            
            if (index == -1)
                index = this.Count();

            this.Insert(index, value);

        }

        /// <summary>
        /// <para>Gets the value at the specified index.</para>
        /// <para>Expected Runtime: O(n), where n is the size of the list.</para>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public new T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count())
                    throw new IndexOutOfRangeException("Element index cannot be less than 0 or greater than the size of the list.");

                LinkedNode<T> currentNode = this.headNodeOfList;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                return currentNode.Value;
            }
        }

        /// <summary>
        /// <para> Reverses the SortedLinkedList with its current <see cref="IComparer{T}"/></para>
        /// <para> Expected Runtime: O(n), where n is the size of the list.</para>
        /// </summary>
        public new void Reverse()
        {
            this.reversalFactor *= -1;
            SortedLinkedList<T> newSortedMethod = new SortedLinkedList<T>();

            foreach (T value in this)
            {
                newSortedMethod.Add(value);
            }

            this.Clear();

            foreach (T value in newSortedMethod)
            {
                this.Add(value);
            }
            newSortedMethod.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        public new void Sort()
        {
            //Does this even need to do anything?
        }

        /// <summary>
        /// <para>Sorts the list with the new <see cref="IComparer{T}"/></para>
        /// <para>Expected Runtime: O(n), where n is the size of the list.</para>
        /// </summary>
        /// <param name="newComparer"></param>
        public void Sort(IComparer<T> newComparer)
        {
            
            SortedLinkedList<T> newSortedMethod = new SortedLinkedList<T>(newComparer);

            foreach(T value in this)
            {
                newSortedMethod.Add(value);
            }

            //TODO: Should this just return this new copy?

            this.Clear();
            this.Comparer = newComparer;

            foreach(T value in newSortedMethod)
            {
                this.Add(value);
            }
            newSortedMethod.Dispose();
        }
    }
}
