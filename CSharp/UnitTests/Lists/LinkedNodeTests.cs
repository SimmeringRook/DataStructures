using DataStructures_CSharp.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists
{
    [TestClass]
    public class LinkedNodeTests : DataStructureTestBase
    {
        
        [TestInitialize]
        public void LinkedNodeTests_Initialize()
        {
            this.TestName = "LinkedNodeTests_Initialize()";
            this.Log.AppendLine(this.TestName);
        }

        [TestCleanup]
        public void LinkedNodeTests_CleanUp()
        {
            this.TestName = "LinkedNodeTests_CleanUp()";
            this.Log.AppendLine(this.TestName);
        }

        [TestMethod]
        public void LinkedNodeTests_HasDefault_Values()
        {
            this.TestName = "LinkedNodeTests_HasDefault_Values()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.Log.AppendLine("Creating LinkedNode<int> 'node' with default Constructor.");
            LinkedNode<int> node = new LinkedNode<int>();

            //Act
            string actual = (node.Next == null) ? "null" : node.Next.ToString();

            //Assert
            this.Log.AppendLine("Expected: " + default(int) + " | Actual: " + node.Value.ToString());
            Assert.AreEqual(default(int), node.Value);

            this.Log.AppendLine("Expected: null | Actual: " + actual);
            Assert.IsNull(node.Next);
        }

        [TestMethod]
        public void LinkedNodeTests_CorrectlyAssigns_Value()
        {
            this.TestName = "LinkedNodeTests_CorrectlyAssigns_Value()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.Log.AppendLine("Creating LinkedNode<int> 'node' with default Constructor.");
            LinkedNode<int> node = new LinkedNode<int>();
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
        public void LinkedNodeTests_CorrectlyAssigns_Next()
        {
            this.TestName = "LinkedNodeTests_CorrectlyAssigns_Next()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.Log.AppendLine("Creating LinkedNode<string> 'nodeA' with (T value) Constructor.");
            LinkedNode<string> nodeA = new LinkedNode<string>("A");
            this.Log.AppendLine("Creating LinkedNode<string> 'nodeB' with (T value) Constructor.");
            LinkedNode<string> nodeB = new LinkedNode<string>("B");

            //Act
            this.Log.AppendLine("Connecting 'nodeA' to 'nodeB'");
            nodeA.Next = nodeB;
            string actual = (nodeA.Next != null) ? nodeA.Next.ToString() : "null";

            //Assert
            this.Log.AppendLine("Expected: " + nodeB.ToString() + " | Actual: " + actual);
            Assert.IsNotNull(nodeA.Next);
            Assert.AreEqual(nodeB, nodeA.Next);
        }

        [TestMethod]
        public void LinkedNodeTests_Correctly_InsertsBetween()
        {
            this.TestName = "LinkedNodeTests_Correctly_InsertsBetween()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.Log.AppendLine("Creating LinkedNode<int> 'node' with default Constructor.");
            LinkedNode<int> node = new LinkedNode<int>();
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
    }
}
