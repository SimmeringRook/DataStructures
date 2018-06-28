using System;
using System.Collections.Generic;

namespace DataStructures_CSharp.Nodes
{
    public class GraphNode<T> : MultiLinkedNode<T>, IComparable where T : IComparable
    {
        public Dictionary<GraphNode<T>, float> NeighborsWithWeightedConnections = new Dictionary<GraphNode<T>, float>();

        public GraphNode()
        {

        }

        public GraphNode(T value) : base (value)
        {

        }

        public new int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (obj is GraphNode<T> otherNode)
                return this.Value.CompareTo(otherNode.Value);
            else
                throw new ArgumentException("Object is not a GraphNode");
        }

        public void AddNeighbor(GraphNode<T> neighbor, float connectionCost)
        {
            if (this.NeighborsWithWeightedConnections.ContainsKey(neighbor) == false)
                this.NeighborsWithWeightedConnections.Add(neighbor, connectionCost);
            else
                this.NeighborsWithWeightedConnections[neighbor] = connectionCost;
        }
    }
}
