using System;
using System.Collections.Generic;

namespace DataStructures_CSharp.Lists
{
    public interface ILinkedList<T> : IEnumerable<T>, IEnumerator<T>, IDisposable where T : IComparable
    {
        T this[int key] { get; }

        void Add(T value);

        void AddRange(int startIndex, IEnumerable<T> collection);

        void Clear();

        bool Contains(T value);

        int Count();

        int IndexOf(T value);

        T GetMaximum();

        T GetMinimum();

        void Remove(T value);

        void RemoveAt(int index);

        void RemoveRange(int startIndex, int length);

        void Reverse();

        void Sort();
    }
}
