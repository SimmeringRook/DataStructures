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

        //TODO:: Override most functionality to use DoubleLinkedNode<T>;
        //mainly the .Previous property

        //TODO:: Change methods to better utilize the functionality provided 
        //by DoubleLinkedNode.Previous
    }
}
