using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_CSharp.Lists
{
    public class SortedLinkedList<T> : LinkedListBase<T> where T : IComparable
    {
        //TODO :: override Add and AddRange to use this.Comparer by default for finding
        //the index to add at
    }
}
