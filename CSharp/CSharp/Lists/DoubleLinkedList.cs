using DataStructures_CSharp.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures_CSharp.Lists
{
    public class DoubleLinkedList<T> : LinkedListBase<T> where T : IComparable
    {
        protected new DoubleLinkedNode<T> currentEnumeratorNode = null;

        protected new DoubleLinkedNode<T> headNodeOfList = null;
        protected new DoubleLinkedNode<T> tailNodeOfList = null;

        protected new DoubleLinkedNode<T> cachedMaximum = null;
        protected new DoubleLinkedNode<T> cachedMinimum = null;

        //TODO:: Override most functionality to use DoubleDoubleLinkedNode<T>;
        //mainly the .Previous property

        //TODO:: Change methods to better utilize the functionality provided 
        //by DoubleDoubleLinkedNode.Previous

        public DoubleLinkedList() : base()
        {
        }

        public DoubleLinkedList(IEnumerable<T> collection) : base(collection)
        {
        }

        public DoubleLinkedList(IComparer<T> comparer) : base(comparer)
        {
        }

        public DoubleLinkedList(IEnumerable<T> collection, IComparer<T> comparer) : base(collection, comparer)
        {
        }

        /// <summary>
        /// <para>Gets the value at the specified index.</para>
        /// <para>Expected Runtime: O(n/2), where n is the size of the list.</para>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public new T this[int index]
        {
            get
            {
                //If the value is closer to the tail, search backwards
                if (index > (int) Math.Floor(this.Count() / 2.0))
                {
                    DoubleLinkedNode<T> currentNode = this.tailNodeOfList;

                    for (int i = this.Count()-1; i > index; i--)
                    {
                        currentNode = currentNode.Previous;
                    }

                    return currentNode.Value;
                }
                //If the value is closer to the head, search normally
                else
                {
                    DoubleLinkedNode<T> currentNode = this.headNodeOfList;

                    for (int i = 0; i < index; i++)
                    {
                        currentNode = currentNode.Next;
                    }

                    return currentNode.Value;
                }
            }
        }

        /// <summary>
        /// <para>Adds the given value to the end of the list.</para>
        /// <para>Expected Runtime: O(1)</para>
        /// </summary>
        /// <param name="value"></param>
        public new void Add(T value)
        {
            //if (this.Comparer == null)
            //    this.Comparer = Comparer<T>.Default;

            if (this.Count() > 0)
            {
                if (this.cachedMinimum != null && this.Comparer.Compare(value, this.cachedMinimum.Value) == -1)
                {
                    this.isCachedMinimumValid = false;
                }
                if (this.cachedMaximum != null && this.Comparer.Compare(value, this.cachedMaximum.Value) == 1)
                {
                    this.isCachedMaximumValid = false;
                }
            }
            this.isCachedCountValid = false;

            if (this.headNodeOfList == null)
            {
                this.headNodeOfList = new DoubleLinkedNode<T>(value);
                this.tailNodeOfList = this.headNodeOfList;

                //WARNING!
                //Do not comment this out. This creates a circular loop that will
                //lead to a stack overflow.
                //this.headNodeOfList.ConnectTo(this.tailNodeOfList);
            }
            else if (this.headNodeOfList == this.tailNodeOfList)
            {
                this.tailNodeOfList = new DoubleLinkedNode<T>(value);
                this.headNodeOfList.ConnectTo(this.tailNodeOfList);
            }
            else
            {
                this.tailNodeOfList.ConnectTo(new DoubleLinkedNode<T>(value));
                this.tailNodeOfList = this.tailNodeOfList.Next;
            }

            //WARNING!
            //Do not comment this out. This list is built with the assumption
            //that you cannot wrap around to the beginning.
            //this.tailNodeOfList.Next = this.headNodeOfList;
        }

        /// <summary>
        /// <para>Adds the collection to the list.</para>
        /// <para>Expected Runtime: O(n) where n = length of the collection</para>
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="collection"></param>
        public new void AddRange(IEnumerable<T> collection)
        {
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    this.Add(enumerator.Current);
                }
            }
        }

        /// <summary>
        /// <para>Removes all elements from the list.</para>
        /// <para>Expected Runtime: O(n), where n = the size of the list.</para>
        /// </summary>
        public new void Clear()
        {
            if (this.isCachedCountValid == true && this.cachedCount == 0)
                return;

            DoubleLinkedNode<T> currentNode = this.headNodeOfList;
            DoubleLinkedNode<T> nextNode = this.headNodeOfList;

            while (nextNode != null)
            {
                currentNode = nextNode;
                nextNode = currentNode.Next;
                currentNode.Remove();
                currentNode = null;
            }

            this.headNodeOfList = null;
            this.tailNodeOfList = null;
            nextNode = null;

            this.isCachedCountValid = false;
            this.isCachedMinimumValid = false;
            this.cachedMinimum = null;
            this.isCachedMaximumValid = false;
            this.cachedMaximum = null;
        }

        /// <summary>
        /// <para>Returns whether or not the provided value exists in the list.</para>
        /// <para>Expected Runtime: O(n), where n = the size of the list.</para>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public new bool Contains(T value)
        {
            return (this[value] >= 0);
        }

        /// <summary>
        /// <para>Returns the size of the list.</para>
        /// <para>Expected Runtime: O(n), where n = the size of the list.</para>
        /// <para>Best case: O(1) if no changes have been made to the list since the previous call.</para>
        /// </summary>
        /// <returns></returns>
        public new int Count()
        {
            //If changes have been made, recount
            if (this.isCachedCountValid == false)
            {
                int liveCount = 0;

                //Check to see if there is even a starting point
                if (this.headNodeOfList != null)
                {
                    DoubleLinkedNode<T> currentNode = this.headNodeOfList;

                    while (currentNode != null)
                    {
                        liveCount++;
                        currentNode = currentNode.Next;
                    }
                }

                //Update the cache
                this.cachedCount = liveCount;
                this.isCachedCountValid = true;
            }

            return this.cachedCount;
        }

        /// <summary>
        /// <para>Disposes of all elements in the list and itself.</para>
        /// <para>Use of the object after calling Dispose will lead to incorrect and unstable behaviour.</para>
        /// </summary>
        public new void Dispose()
        {
            this.Clear();
            this.cachedMinimum = null;
            this.cachedMaximum = null;
            this.Comparer = null;
        }

        public new IEnumerator<T> GetEnumerator()
        {
            DoubleLinkedNode<T> current = this.headNodeOfList;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// <para>Gets the node for the given index.</para>
        /// <para>Expected runtime: O(n), where n = index</para>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected new DoubleLinkedNode<T> GetNodeAt(int index)
        {
            if (index < 0 || index > this.Count())
            {
                string exceptionMessage = (index < 0) ? " less than 0." : " greater than the size of the list.";
                throw new IndexOutOfRangeException(
                    "The provided index (" + index.ToString() + ") was invalid. index cannot be" + exceptionMessage
                    );
            }

            DoubleLinkedNode<T> node = this.headNodeOfList;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node;
        }

        /// <summary>
        /// <para>Returns the index of the given value, if it exists in the list. (-1 if it does not).</para>
        /// <para>Expected Runtime: O(n), where n is the position of the value in the list.</para>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public new int IndexOf(T value)
        {
            return this[value];
        }

        /// <summary>
        /// <para>Inserts the given value at the given index.</para>
        /// <para>Expected Runtime: O(n), where n is the index.</para>
        /// <para>Best case: 0(1) for inserting at the head or tail.</para>
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected new void Insert(int index, T value)
        {
            if (index < 0 || index > this.Count())
            {
                string exceptionMessage = (index < 0) ? " less than 0." : " greater than the size of the list.";
                throw new IndexOutOfRangeException(
                    "The provided index (" + index.ToString() + ") was invalid. index cannot be" + exceptionMessage
                    );
            }

            DoubleLinkedNode<T> newNode = new DoubleLinkedNode<T>(value);

            if (index == 0)
            {
                newNode.Next = this.headNodeOfList;
                this.headNodeOfList = newNode;
            }
            else if (index == this.Count() - 1)
            {
                this.tailNodeOfList.Next = newNode;
                this.tailNodeOfList = newNode;
            }
            else
            {
                DoubleLinkedNode<T> currentNode = this.GetNodeAt(index);
                DoubleLinkedNode<T> previousNode = this.GetNodeAt(index - 1);

                newNode.InsertBetween(previousNode, currentNode);
            }

            if (value.CompareTo(this.GetMinimum()) == -1)
            {
                this.isCachedMinimumValid = false;
            }
            if (value.CompareTo(this.GetMaximum()) == 1)
            {
                this.isCachedMaximumValid = false;
            }
            this.isCachedCountValid = false;
        }

        /// <summary>
        /// <para>Gets the Maximum value using the current given <see cref="IComparer{T}"/>.</para>
        /// <para>Expected Runtime: O(n), where n is the number of elements in the list.</para>
        /// <para>Best Runtime: O(1), if no changes have been made to the list.</para>
        /// </summary>
        /// <returns></returns>
        public new T GetMaximum()
        {
            if (this.Count() == 0)
                throw new InvalidOperationException("Tried to find a maximum value in an empty list.");

            if (isCachedMaximumValid == false)
            {
                DoubleLinkedNode<T> max = this.headNodeOfList;
                DoubleLinkedNode<T> possibleMax = this.headNodeOfList.Next;

                for (int i = 1; i < this.Count(); i++)
                {
                    if (this.Comparer.Compare(possibleMax.Value, max.Value) == 1)
                    {
                        max = possibleMax;
                    }
                    possibleMax = possibleMax.Next;
                }

                this.cachedMaximum = max;
                this.isCachedMaximumValid = true;

                possibleMax = null;
                max = null;
            }

            return cachedMaximum.Value;
        }

        /// <summary>
        /// <para>Gets the Minimum value using the current given <see cref="IComparer{T}"/>.</para>
        /// <para>Expected Runtime: O(n), where n is the number of elements in the list.</para>
        /// <para>Best Runtime: O(1), if no changes have been made to the list.</para>
        /// </summary>
        /// <returns></returns>
        public new T GetMinimum()
        {
            if (this.Count() == 0)
                throw new InvalidOperationException("Tried to find a minimum value in an empty list.");

            if (isCachedMinimumValid == false)
            {
                DoubleLinkedNode<T> min = this.headNodeOfList;
                DoubleLinkedNode<T> possibleMin = this.headNodeOfList.Next;

                for (int i = 0; i < this.Count(); i++)
                {
                    if (possibleMin == null)
                        break;

                    if (this.Comparer.Compare(possibleMin.Value, min.Value) == -1)
                    {
                        min = possibleMin;
                    }
                    possibleMin = possibleMin.Next;
                }

                this.cachedMinimum = min;
                this.isCachedMinimumValid = true;

                possibleMin = null;
                min = null;
            }

            return cachedMinimum.Value;
        }

        public new bool MoveNext()
        {
            if (this.enumerationStarted == false && this.currentEnumeratorNode == null)
            {
                this.currentEnumeratorNode = this.headNodeOfList;
                this.enumerationStarted = true;
                return true;
            }

            if (this.currentEnumeratorNode.Next == null)
                return false;

            this.currentEnumeratorNode = this.currentEnumeratorNode.Next;
            return true;
        }

        /// <summary>
        /// <para>Removes the given value from the list.</para>
        /// <para>Expected Runtime: O(n), where n is the number of elements in the list.</para>
        /// </summary>
        /// <param name="value"></param>
        public new void Remove(T value)
        {
            DoubleLinkedNode<T> currentNode = this.headNodeOfList;
            DoubleLinkedNode<T> previousNode = currentNode;

            while (currentNode.Value.Equals(value) == false)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;

                //Reached the end of the list, value wasn't in the lsit to begin with
                //Exit
                if (currentNode == null)
                    return;
            }

            //Handle special cases
            if (currentNode.Equals(this.headNodeOfList))
            {
                this.headNodeOfList = this.headNodeOfList.Next;
            }
            else if (currentNode.Equals(this.tailNodeOfList))
            {
                this.tailNodeOfList = previousNode;
                this.tailNodeOfList.Next = null;
            }

            //Invalidate all of the caches
            this.isCachedCountValid = false;
            if (currentNode.Value.Equals(this.GetMinimum()))
            {
                this.isCachedMinimumValid = false;
            }
            if (currentNode.Value.Equals(this.GetMaximum()))
            {
                this.isCachedMaximumValid = false;
            }

            //Remove the node and its value
            currentNode.Remove();
        }

        /// <summary>
        /// <para>Removes the element at the given index.</para>
        /// <para>Expected runtime: O(n/2), where n is the index</para>
        /// <para>Best Case: O(1), if removing the first or last value</para>
        /// </summary>
        /// <param name="index"></param>
        public new void RemoveAt(int index)
        {
            //There is nothing to remove, exit
            if (this.isCachedCountValid == true && this.cachedCount == 0)
                return;

            //Worst: O(n/2)
            //Best: O(1)
            DoubleLinkedNode<T> currentNode = this.GetNodeAt(index);

            //If we're removing the min or max of the list, invalidate the cache
            if (currentNode.Value.Equals(this.GetMinimum()))
            {
                this.isCachedMinimumValid = false;
            }
            if (currentNode.Value.Equals(this.GetMaximum()))
            {
                this.isCachedMaximumValid = false;
            }

            if (index == 0)
            {
                //Removing the last node, set head and tail to null
                if (this.Count() == 1)
                {
                    this.headNodeOfList = null;
                    this.tailNodeOfList = null;
                }
                else
                {
                    //Replace the head node

                    //If RemoveAt(0) leads to weird behaviour in the future
                    //revisit commented out code below: (shouldn't be necessary)
                    //DoubleLinkedNode<T> temp = this.headNodeOfList;
                    this.headNodeOfList = this.headNodeOfList.Next;
                    //temp.Remove();
                }
            }
            else
            {
                if (currentNode == this.tailNodeOfList)
                {
                    this.tailNodeOfList = this.tailNodeOfList.Previous;
                }
            }

            //Ensure Node is disposed of
            currentNode.Remove();
            currentNode = null;
            this.isCachedCountValid = false;
        }

        /// <summary>
        /// <para>Removes the range of elements starting at the startIndex and going until startIndex + length.</para>
        /// <para>Expected Runtime: O(kn), where k = length, n = startIndex</para>
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        public new void RemoveRange(int startIndex, int length)
        {
            for (int i = length - 1; i >= 0; i--)
            {
                this.RemoveAt(startIndex + i);
            }
        }

        public new void Reset()
        {
            this.currentEnumeratorNode = null;
            this.enumerationStarted = false;
        }

        /// <summary>
        /// <para>Reverses the order of the list.</para>
        /// <para>Expected Runtime: O(n), where n is the number of elements in the list</para>
        /// </summary>
        /// TODO: Revisit later to see if a simpler/better approach is possible that
        /// utilizes DoubleLinkedNode functionality
        public new void Reverse()
        {
            DoubleLinkedNode<T> newHeadOfList = new DoubleLinkedNode<T>(this.tailNodeOfList.Value);
            DoubleLinkedNode<T> newTailOfList = newHeadOfList;
            DoubleLinkedNode<T> newNode = null;

            //Walk over the list backwards
            //this.Count() - 1 - 1; is because -1 to account for:
            //being off by one (zero indexed vs 1 indexed)
            //and -1 because we already have the tail
            for (int i = this.Count() - 2; i >= 0; i--)
            {
                //Grab the "last" node at i
                newNode = new DoubleLinkedNode<T>(this[i]);
                //Add it to the new tail
                newTailOfList.Next = newNode;
                newTailOfList = newTailOfList.Next;
            }

            //Finish Overwritting of the old list
            //Remove the old list and clear the caches
            this.Clear();

            this.headNodeOfList = newHeadOfList;
            this.tailNodeOfList = newTailOfList;
        }

        /// <summary>
        /// <para>Sorts the list based on <see cref="Comparer"/>. </para>
        /// <para>Expected runtime: O(n^2), where n is the number of elements in the list.</para>
        /// </summary>
        /// TODO: Allow for different sorting methods that use this.Comparer
        public new void Sort()
        {
            //Grab the min and max from the current List as new nodes
            DoubleLinkedNode<T> min = new DoubleLinkedNode<T>(this.GetMinimum());
            DoubleLinkedNode<T> max = new DoubleLinkedNode<T>(this.GetMaximum());
            //Create the sorted list with the head node being the min
            //and the tail node being the Max 
            min.Next = max;

            DoubleLinkedNode<T> nodeFromOriginalList = this.headNodeOfList;

            //Iterrate over the current List
            for (int i = 0; i < this.Count(); i++)
            {

                DoubleLinkedNode<T> currentNodeFromSortedList = min;
                DoubleLinkedNode<T> previousNodeFromSortedList = currentNodeFromSortedList;

                //While the currentNodeFromSortedList is less than nodeFromOriginalList,
                //Keep traversing down the sorted list
                while (this.Comparer.Compare(currentNodeFromSortedList.Value, nodeFromOriginalList.Value) == -1)
                {
                    previousNodeFromSortedList = currentNodeFromSortedList;
                    currentNodeFromSortedList = currentNodeFromSortedList.Next;
                }

                //Ensure we don't duplicate adding min and max to the sorted list
                if (nodeFromOriginalList.Value.Equals(min.Value) == false
                    && nodeFromOriginalList.Value.Equals(max.Value) == false)
                {
                    //Add this new node between previous and current
                    //Example: on the first iterration, this should add a value between min and max
                    //such that the sorted list looks like: A -> B -> C
                    new DoubleLinkedNode<T>(nodeFromOriginalList.Value).InsertBetween(
                        previousNodeFromSortedList,
                        currentNodeFromSortedList
                        );
                }

                //Grab the next node from the unsortedList
                nodeFromOriginalList = nodeFromOriginalList.Next;
            }

            //Remove and overwrite the unsorted list
            this.Clear();
            this.headNodeOfList = min;
            this.tailNodeOfList = max;
        }

    }
}
