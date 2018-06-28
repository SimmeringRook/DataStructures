namespace DataStructures_CSharp.Nodes
{
    public class DoubleLinkedNode<T> : LinkedNode<T> where T : System.IComparable
    {
        public new DoubleLinkedNode<T> Next = null;
        public DoubleLinkedNode<T> Previous = null;

        public DoubleLinkedNode()
        {

        }

        public DoubleLinkedNode(T value) : base (value)
        {
        }

        public void ConnectTo(DoubleLinkedNode<T> nextNode)
        {
            this.Next = nextNode;
            nextNode.Previous = this;
        }

        public void InsertBetween(DoubleLinkedNode<T> previous, DoubleLinkedNode<T> next)
        {
            this.Previous = previous;
            if (previous != null)
                previous.Next = this;

            this.Next = next;
            if (next != null)
                next.Previous = this;
        }

        public new void Remove()
        {
            if (this.Previous != null)
            {
                this.Previous.Next = this.Next;
                this.Previous = null;
            }
            if (this.Next != null)
            {
                this.Next.Previous = this.Previous;
                this.Next = null;
            }

            this.Dispose();
        }
    }
}
