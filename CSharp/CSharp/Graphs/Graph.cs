using DataStructures_CSharp.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_CSharp.Graphs
{
    public class Graph<T> where T : IComparable
    {
        public LinkedListBase<GraphNode<T>> Nodes = new LinkedListBase<GraphNode<T>>();

        public Graph()
        {

        }

        public Graph(IEnumerable<T> collection)
        {
            using (IEnumerator<T> values = collection.GetEnumerator())
            {
                while (values.MoveNext())
                {
                    GraphNode<T> node = new GraphNode<T>(values.Current);
                    this.Nodes.Add(node);
                }
            }
        }

        public Path<T> GetPath(GraphNode<T> source, GraphNode<T> destination)
        {
            foreach (GraphNode<T> neighbor in source.Neighbors.Keys)
            {

            }
            return null;
        }
    }

    public class Path<T> where T : IComparable
    {
        public LinkedListBase<GraphNode<T>> Nodes = new LinkedListBase<GraphNode<T>>();
    }
}
