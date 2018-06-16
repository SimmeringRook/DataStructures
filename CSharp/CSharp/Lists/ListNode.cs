namespace DataStructures_CSharp.Lists
{
    public class ListNode<T> : Node<T> where T : System.IComparable
    {
        public ListNode<T> Next = null;
        public ListNode<T> Previous = null;

        public ListNode()
        {

        }

        public ListNode(T value) : base (value)
        {
        }

        public void InsertBetween(ListNode<T> previous, ListNode<T> next)
        {
            this.Previous = previous;
            previous.Next = this;

            this.Next = next;
            next.Previous = this;
        }

        public new void Remove()
        {
            this.Previous.Next = this.Next;
            this.Next.Previous = this.Previous;

            base.Remove();
        }
    }
}
