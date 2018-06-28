using DataStructures_CSharp.Lists;
using System;

namespace DataStructures_CSharp.Nodes
{
    public class MultiLinkedNode<T> : Node<T>, IComparable where T : IComparable
    {
        public LinkedListBase<MultiLinkedNode<T>> Neighbors = new LinkedListBase<MultiLinkedNode<T>>();

        public MultiLinkedNode()
        {

        }

        public MultiLinkedNode(T value) : base(value)
        {

        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (obj is MultiLinkedNode<T> otherNode)
                return this.Value.CompareTo(otherNode.Value);
            else
                throw new ArgumentException("Object is not a MultiLinkedNode");
        }

        public void AddNeighbor(MultiLinkedNode<T> nodeToConnect)
        {
            if (Neighbors.Contains(nodeToConnect) == false)
                Neighbors.Add(nodeToConnect);
        }
    }
}
