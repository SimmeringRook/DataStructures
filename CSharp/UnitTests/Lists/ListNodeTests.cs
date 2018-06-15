using DataStructures_CSharp.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists
{
    [TestClass]
    public class ListNodeTests : DataStructureTestBase
    {
        
        [TestInitialize]
        public void ListNode_Initialize()
        {
            this.TestName = "ListNode_Initialize()";
            this.Log.AppendLine(this.TestName);
        }

        [TestCleanup]
        public void ListNode_CleanUp()
        {
            this.TestName = "ListNode_CleanUp()";
            this.Log.AppendLine(this.TestName);
        }

        [TestMethod]
        public void ListNode_HasDefault_Values()
        {
            this.TestName = "ListNode_HasDefault_Values()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.Log.AppendLine("Creating ListNode<int> 'node' with default Constructor.");
            ListNode<int> node = new ListNode<int>();

            //Act
            string actual = (node.Next == null) ? "null" : node.Next.ToString();

            //Assert
            this.Log.AppendLine("Expected: " + default(int) + " | Actual: " + node.Value.ToString());
            Assert.AreEqual(default(int), node.Value);

            this.Log.AppendLine("Expected: null | Actual: " + actual);
            Assert.IsNull(node.Next);
        }

        [TestMethod]
        public void ListNode_CorrectlyAssigns_Value()
        {
            this.TestName = "ListNode_CorrectlyAssigns_Value()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.Log.AppendLine("Creating ListNode<int> 'node' with default Constructor.");
            ListNode<int> node = new ListNode<int>();
            this.Log.AppendLine("valueToAssign = 1");
            int valueToAssign = 1;

            //Act
            this.Log.AppendLine("Assigning 'valueToAssign' to 'node'");
            node.Value = valueToAssign;

            //Assert
            this.Log.AppendLine("Expected: " + valueToAssign.ToString() + " | Actual: " + node.Value.ToString());
            Assert.AreNotEqual(default(int), node.Value);
            Assert.AreEqual(valueToAssign, node.Value);
        }

        [TestMethod]
        public void ListNode_CorrectlyAssigns_Next()
        {
            this.TestName = "ListNode_CorrectlyAssigns_Next()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.Log.AppendLine("Creating ListNode<string> 'nodeA' with (T value) Constructor.");
            ListNode<string> nodeA = new ListNode<string>("A");
            this.Log.AppendLine("Creating ListNode<string> 'nodeB' with (T value) Constructor.");
            ListNode<string> nodeB = new ListNode<string>("B");

            //Act
            this.Log.AppendLine("Connecting 'nodeA' to 'nodeB'");
            nodeA.Next = nodeB;
            string actual = (nodeA.Next != null) ? nodeA.Next.ToString() : "null";

            //Assert
            this.Log.AppendLine("Expected: " + nodeB.ToString() + " | Actual: " + actual);
            Assert.IsNotNull(nodeA.Next);
            Assert.AreEqual(nodeB, nodeA.Next);
        }
    }
}
