namespace DataStructures_CSharp.Lists
{
    public class LinkedNode<T> : Node<T> where T : System.IComparable
    {
        public LinkedNode<T> Next = null;

        public LinkedNode()
        {
        }

        public LinkedNode(T value) : base(value)
        {
        }

        public void InsertBetween(LinkedNode<T> previous, LinkedNode<T> next)
        {
            if (previous != null)
                previous.Next = this;

            this.Next = next;
        }

        public new void Remove()
        {
            this.Next = null;
            base.Remove();
        }
    }
}
