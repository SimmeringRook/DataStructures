namespace DataStructures_CSharp.Lists
{
    public class ListNode<T> where T : System.IComparable
    {
        public T Value = default(T);
        public ListNode<T> Next = null;

        public ListNode()
        {

        }

        public ListNode(T value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
