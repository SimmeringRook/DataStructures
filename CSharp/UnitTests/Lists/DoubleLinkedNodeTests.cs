using System;
using DataStructures_CSharp.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists
{
    [TestClass]
    public class DoubleLinkedNodeTests : DataStructureTestBase
    {
        protected DoubleLinkedNode<string> NodeA;
        protected DoubleLinkedNode<string> NodeB;
        protected DoubleLinkedNode<string> NodeC;

        protected string ValueA;
        protected string ValueB;
        protected string ValueC;

        [TestInitialize]
        public void DoubleLinkedNodeTests_Initialize()
        {
            this.TestName = "DoubleLinkedNodeTests_Initialize()";
            this.Log.AppendLine(this.TestName);

            this.ValueA = "A";
            this.ValueB = "B";
            this.ValueC = "C";

            this.NodeA = new DoubleLinkedNode<string>(this.ValueA);
            this.NodeB = new DoubleLinkedNode<string>(this.ValueB);
            this.NodeC = new DoubleLinkedNode<string>(this.ValueC);
            this.Log.AppendLine("");
        }

        [TestCleanup]
        public void DoubleLinkedNodeTests_CleanUp()
        {
            this.TestName = "\nDoubleLinkedNodeTests_CleanUp()";
            this.Log.AppendLine(this.TestName);

            this.ValueA = null;
            this.ValueB = null;
            this.ValueC = null;

            this.NodeA.Remove();
            this.NodeB.Remove();
            this.NodeC.Remove();
        }

        [TestMethod]
        public void DoubleLinkedNode_InsertsBetween_Successfully()
        {
            this.TestName = "DoubleLinkedNode_InsertsBetween_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.NodeA.ConnectTo(this.NodeC);

            //Act
            this.Log.AppendLine("Assigning 'valueToAssign' to 'node'");
            this.NodeB.InsertBetween(this.NodeA, this.NodeC);

            //Assert
            this.Log.Append("Previous: ");
            this.Log.AppendLine("Expected: " + NodeA.Value + " | Actual: " + NodeB.Previous.Value);
            this.Log.Append("Next: ");
            this.Log.AppendLine("Expected: " + NodeC.Value + " | Actual: " + NodeB.Next.Value);

            Assert.AreEqual(NodeA, NodeB.Previous);
            Assert.AreEqual(NodeA.Next, NodeB);

            Assert.AreEqual(NodeC, NodeB.Next);
            Assert.AreEqual(NodeC.Previous, NodeB);
        }

        [TestMethod]
        public void DoubleLinkedNode_Connects_Successfully()
        {
            this.TestName = "DoubleLinkedNode_Connects_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            

            //Act
            this.Log.AppendLine("Connecting 'NodeA' to 'NodeB'");
            this.NodeA.ConnectTo(this.NodeB);

            //Assert
            this.Log.Append("Previous: ");
            this.Log.AppendLine("Expected: " + NodeA.Value + " | Actual: " + NodeB.Previous.Value);
            this.Log.Append("Next: ");
            this.Log.AppendLine("Expected: " + NodeB.Value + " | Actual: " + NodeA.Next.Value);

            Assert.AreEqual(NodeA, NodeB.Previous);
            Assert.AreEqual(NodeA.Next, NodeB);
        }
    }
}
