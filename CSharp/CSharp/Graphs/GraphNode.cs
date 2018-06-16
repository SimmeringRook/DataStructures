using DataStructures_CSharp.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_CSharp.Graphs
{
    public class GraphNode<T> : Node<T>, IComparable where T : IComparable
    {
        public Dictionary<GraphNode<T>, float> Neighbors = new Dictionary<GraphNode<T>, float>();

        public GraphNode()
        {

        }

        public GraphNode(T value) : base(value)
        {

        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (obj is GraphNode<T> otherNode)
                return this.Value.CompareTo(otherNode.Value);
            else
                throw new ArgumentException("Object is not a GraphNode");
        }

        public void AddConnection(GraphNode<T> nodeToConnect, float cost)
        {
            if (Neighbors.ContainsKey(nodeToConnect) == false)
                Neighbors.Add(nodeToConnect, cost);
        }
    }
}
