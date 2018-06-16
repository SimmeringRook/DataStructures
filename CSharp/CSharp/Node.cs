using System;

namespace DataStructures_CSharp
{
    public class Node<T> : IDisposable where T : System.IComparable
    {
        public T Value = default(T);

        public Node()
        {

        }

        public Node(T value)
        {
            this.Value = value;
        }

        public void Dispose()
        {
            this.Value = default(T);
        }

        public void Remove()
        {
            this.Dispose();
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
