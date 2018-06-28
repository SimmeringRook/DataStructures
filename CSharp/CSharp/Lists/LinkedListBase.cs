using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures_CSharp.Nodes;

namespace DataStructures_CSharp.Lists
{
    public class LinkedListBase<T> : ILinkedList<T> where T : IComparable
    {
        public IComparer<T> Comparer;
        
        protected LinkedNode<T> currentEnumeratorNode = null;
        protected bool enumerationStarted = false;

        protected LinkedNode<T> headNodeOfList = null;
        protected LinkedNode<T> tailNodeOfList = null;

        protected bool isCachedCountValid = true;
        protected int cachedCount = 0;

        protected bool isCachedMaximumValid = false;
        protected LinkedNode<T> cachedMaximum = null;

        protected bool isCachedMinimumValid = false;
        protected LinkedNode<T> cachedMinimum = null;

        public LinkedListBase()
        {
            this.Comparer = Comparer<T>.Default;
        }

        public LinkedListBase(IEnumerable<T> collection) : this()
        {
            this.AddRange(collection);
        }

        public LinkedListBase(IComparer<T> comparer)
        {
            this.Comparer = comparer;
        }

        public LinkedListBase(IEnumerable<T> collection, IComparer<T> comparer)
        {
            this.Comparer = comparer;
            this.AddRange(collection);
        }

        /// <summary>
        /// <para>Gets the value at the specified index.</para>
        /// <para>Expected Runtime: O(n), where n is the size of the list.</para>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                LinkedNode<T> currentNode = this.headNodeOfList;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }

                return currentNode.Value;
            }          
        }

        //  TODO::    
        //      Is this existing a bad thing?
        //      Should it be public? protected?
        //      Should it throw an exception instead of returning -1?
        /// <summary>
        /// Gets the index of the specified value.
        /// Returns -1 if the value does not exist in the list.
        /// Expected Runtime: O(n), where n is the index of the item in the list.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected int this[T value]
        {
            get
            {
                LinkedNode<T> currentNode = this.headNodeOfList;

                for (int i = 0; i < this.Count(); i++)
                {
                    if (currentNode.Value.Equals(value))
                        return i;
                    currentNode = currentNode.Next;
                }

                return -1;
            }
        }
        
        public T Current
        {
            get
            {
                if (this.enumerationStarted)
                    return this.currentEnumeratorNode.Value;
                else
                    throw new System.InvalidOperationException("Enumeration must be started. Call MoveNext.");
            }
        }

        object IEnumerator.Current => this.Current;

        /// <summary>
        /// <para>Adds the given value to the end of the list.</para>
        /// <para>Expected Runtime: O(1)</para>
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
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
                this.headNodeOfList = new LinkedNode<T>(value);
                this.tailNodeOfList = this.headNodeOfList;
                return;
            }
            else if (this.headNodeOfList == this.tailNodeOfList)
            {
                this.tailNodeOfList = new LinkedNode<T>(value);
                this.headNodeOfList.Next = this.tailNodeOfList;
            }
            else
            {
                this.tailNodeOfList.Next = new LinkedNode<T>(value);
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
        public void AddRange(IEnumerable<T> collection)
        {
            using(IEnumerator<T> enumerator = collection.GetEnumerator())
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
        public void Clear()
        {
            if (this.Count() == 0)
                return;

            LinkedNode<T> currentNode = this.headNodeOfList;
            LinkedNode<T> nextNode = this.headNodeOfList;

            while(nextNode != null)
            {
                currentNode = nextNode;
                nextNode = currentNode.Next;
                currentNode.Remove();
                currentNode = null;
            }

            this.headNodeOfList = null;
            this.tailNodeOfList = null;
            nextNode = null;

            this.InvalidateAllCaches();
        }

        /// <summary>
        /// <para>Returns whether or not the provided value exists in the list.</para>
        /// <para>Expected Runtime: O(n), where n = the size of the list.</para>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return (this[value] >= 0);
        }

        /// <summary>
        /// <para>Creates a copy of the list.</para>
        /// <para>Expected Runtime: O(n), where n = the size of the list.</para>
        /// </summary>
        /// <returns></returns>
        public LinkedListBase<T> Copy()
        {
            return new LinkedListBase<T>(this as IEnumerable<T>, this.Comparer);
        }

        /// <summary>
        /// <para>Returns the size of the list.</para>
        /// <para>Expected Runtime: O(n), where n = the size of the list.</para>
        /// <para>Best case: O(1) if no changes have been made to the list since the previous call.</para>
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            //If changes have been made, recount
            if (this.isCachedCountValid == false)
            {
                int liveCount = 0;

                //Check to see if there is even a starting point
                if (this.headNodeOfList != null)
                {
                    LinkedNode<T> currentNode = this.headNodeOfList;

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
        public void Dispose()
        {
            this.Clear();
            this.cachedMinimum = null;
            this.cachedMaximum = null;
            this.Comparer = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedNode<T> current = this.headNodeOfList;

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
        protected LinkedNode<T> GetNodeAt(int index)
        {
            if (index < 0 || index > this.Count())
            {
                string exceptionMessage = (index < 0) ? " less than 0." : " greater than the size of the list.";
                throw new IndexOutOfRangeException(
                    "The provided index (" + index.ToString() + ") was invalid. index cannot be" + exceptionMessage
                    );
            }

            LinkedNode<T> node = this.headNodeOfList;
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
        public int IndexOf(T value)
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
        protected void Insert(int index, T value)
        {
            if (index < 0 || index > this.Count())
            {
                string exceptionMessage = (index < 0) ? " less than 0." : " greater than the size of the list.";
                throw new IndexOutOfRangeException(
                    "The provided index (" + index.ToString() + ") was invalid. index cannot be" + exceptionMessage
                    );
            }

            LinkedNode<T> newNode = new LinkedNode<T>(value);

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
                LinkedNode<T> currentNode = this.GetNodeAt(index);
                LinkedNode<T> previousNode = this.GetNodeAt(index - 1);

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
        /// <para>Sets all cached values to null and all booleans related 
        /// to count, min and max to false.</para>
        /// </summary>
        protected void InvalidateAllCaches()
        {
            this.isCachedMinimumValid = false;
            this.cachedMinimum = null;

            this.isCachedMaximumValid = false;
            this.cachedMaximum = null;

            this.isCachedCountValid = false;
        }

        /// <summary>
        /// <para>Gets the Maximum value using the current given <see cref="IComparer{T}"/>.</para>
        /// <para>Expected Runtime: O(n), where n is the number of elements in the list.</para>
        /// <para>Best Runtime: O(1), if no changes have been made to the list.</para>
        /// </summary>
        /// <returns></returns>
        public T GetMaximum()
        {
            if (this.Count() == 0)
                throw new InvalidOperationException("Tried to find a maximum value in an empty list.");

            if (isCachedMaximumValid == false)
            {
                LinkedNode<T> max = this.headNodeOfList;
                LinkedNode<T> possibleMax = this.headNodeOfList.Next;

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
        public T GetMinimum()
        {
            if (this.Count() == 0)
                throw new InvalidOperationException("Tried to find a minimum value in an empty list.");

            if (isCachedMinimumValid == false)
            {
                LinkedNode<T> min = this.headNodeOfList;
                LinkedNode<T> possibleMin = this.headNodeOfList.Next;

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

        public bool MoveNext()
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
        public void Remove(T value)
        {
            LinkedNode<T> currentNode = this.headNodeOfList;
            LinkedNode<T> previousNode = currentNode;
            while (currentNode.Value.Equals(value) == false)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
                
                //Reached the end of the list, value wasn't in the lsit to begin with
                //Exit
                if (currentNode == null)
                    return;
            }

            //Handle cases
            if (currentNode.Equals(this.headNodeOfList))
            {
                this.headNodeOfList = this.headNodeOfList.Next;
            }
            else if (currentNode.Equals(this.tailNodeOfList))
            {
                this.tailNodeOfList = previousNode;
                this.tailNodeOfList.Next = null;
            }
            else
            {
                previousNode.Next = currentNode.Next;
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
        /// <para>Expected runtime: O(n), where n is the index</para>
        /// <para>Best Case: O(1), if removing the first or last value</para>
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            //There is nothing to remove, exit
            if (this.Count() == 0)
            {
                return;
            }
            else if (this.Count() == 1)
            {
                this.Clear();
            }
            else
            {
                int previousNodeIndex = (index > 0) ? index - 1 : 0;
                LinkedNode<T> previousNode = this.GetNodeAt(previousNodeIndex); //this.headNodeOfList;
                LinkedNode<T> currentNode = this.GetNodeAt(index); //this.headNodeOfList;

                //Find the node at the index
                //for (int i = 0; i < index; i++)
                //{
                //    previousNode = currentNode;
                //    currentNode = currentNode.Next;
                //}

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
                    this.headNodeOfList = this.headNodeOfList.Next;
                }
                else if (index == this.Count() - 1)
                {
                    this.tailNodeOfList = previousNode;
                    this.tailNodeOfList.Next = null;
                }
                else
                {
                    previousNode.Next = currentNode.Next;
                }
                currentNode.Remove();
                previousNode = null;
            }

            this.isCachedCountValid = false;
        }

        /// <summary>
        /// <para>Removes the range of elements starting at the startIndex and going until startIndex + length.</para>
        /// <para>Expected Runtime: O(kn), where k = length, n = startIndex</para>
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        public void RemoveRange(int startIndex, int length)
        {
            for(int i = length - 1; i >= 0; i--)
            {
                this.RemoveAt(startIndex + i);
            }
        }

        public void Reset()
        {
            this.currentEnumeratorNode = null;
            this.enumerationStarted = false;
        }

        /// <summary>
        /// <para>Reverses the order of the list.</para>
        /// <para>Expected Runtime: O(n), where n is the number of elements in the list</para>
        /// </summary>
        public void Reverse()
        {
            
            LinkedNode<T> newHeadOfList = new LinkedNode<T>(this.tailNodeOfList.Value);
            LinkedNode<T> newTailOfList = newHeadOfList;
            LinkedNode<T> newNode = null;

            //Walk over the list backwards
            //this.Count() - 1 - 1; is because -1 to account for:
            //being off by one (zero index)
            //and -1 because we already have the tail
            for (int i = this.Count() - 2; i >= 0; i--)
            {
                //Grab the "last" node at i
                newNode = new LinkedNode<T>(this[i]);
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
        public void Sort()
        {
            //Grab the min and max from the current List as new nodes
            LinkedNode<T> min = new LinkedNode<T>(this.GetMinimum());
            LinkedNode<T> max = new LinkedNode<T>(this.GetMaximum());
            //Create the sorted list with the head node being the min
            //and the tail node being the Max 
            min.Next = max;
           
            LinkedNode<T> nodeFromOriginalList = this.headNodeOfList;

            //Iterrate over the current List
            for (int i = 0; i < this.Count(); i++)
            {
                
                LinkedNode<T> currentNodeFromSortedList = min;
                LinkedNode<T> previousNodeFromSortedList = currentNodeFromSortedList;

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
                    new LinkedNode<T>(nodeFromOriginalList.Value).InsertBetween(
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
