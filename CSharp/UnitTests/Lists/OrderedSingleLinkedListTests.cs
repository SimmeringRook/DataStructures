using System;
using DataStructures_CSharp.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists
{
    [TestClass]
    public class OrderedSingleLinkedListTests : DataStructureTestBase
    {
        private OrderedSingleLinkedList<int> orderedLinkedList;
        private int valueA;
        private int valueB;
        private int valueC;
        private int valueD;

        [TestInitialize]
        public void OrderedSingleLinkedListTests_Initialize()
        {
            this.TestName = "OrderedSingleLinkedListTests_Initialize()";
            this.Log.AppendLine(this.TestName);

            this.Log.AppendLine("Creating 'unorderedSingleLinkedList' with default Constructor");
            orderedLinkedList = new OrderedSingleLinkedList<int>();

            valueA = 1;
            valueB = 2;
            valueC = 3;
            valueD = 4;
            this.Log.AppendLine();
        }

        [TestCleanup]
        public void OrderedSingleLinkedListTests_CleanUp()
        {
            this.Log.AppendLine();
            this.TestName = "OrderedSingleLinkedListTests_CleanUp()";
            this.Log.AppendLine(this.TestName);

            orderedLinkedList = null;

            valueA = default(int);
            valueB = default(int);
            valueC = default(int);
            valueD = default(int);
        }

        [TestMethod]
        public void OrderedSingleLinkedList_CorrectlyAdds_OneValue()
        {
            this.TestName = "OrderedSingleLinkedList_CorrectlyAdds_OneValue()";
            this.Log.AppendLine(this.TestName);

            //Arrange

            //Act
            this.Log.AppendLine("Adding " + valueA.ToString() + " to the list.");
            orderedLinkedList.Add(valueA);

            //Assert
            Assert.AreEqual(valueA, orderedLinkedList[0]);
            Assert.AreEqual(1, orderedLinkedList.Count);
        }

        [TestMethod]
        public void OrderedSingleLinkedList_CorrectlyAdds_TwoValues()
        {
            this.TestName = "OrderedSingleLinkedList_CorrectlyAdds_TwoValues()";
            this.Log.AppendLine(this.TestName);

            //Arrange

            //Act
            this.Log.AppendLine("Adding " + valueB + " to the list.");
            orderedLinkedList.Add(valueB);
            this.Log.AppendLine("Adding " + valueA + " to the list.");
            orderedLinkedList.Add(valueA);

            foreach (int value in orderedLinkedList)
            {
                this.Log.Append(value + ", ");
            }
            this.Log.AppendLine();

            //Assert
            Assert.AreEqual(valueA, orderedLinkedList[0]);
            Assert.AreEqual(valueB, orderedLinkedList[1]);
            Assert.AreEqual(2, orderedLinkedList.Count);
        }

        [TestMethod]
        public void OrderedSingleLinkedList_CorrectlyAdds_Collection()
        {
            this.TestName = "OrderedSingleLinkedList_CorrectlyAdds_Collection()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            int[] values = { valueD, valueC, valueB, valueA };

            //Act
            this.Log.AppendLine("Adding " + values.ToString() + " to the list.");
            orderedLinkedList.Add(values);

            foreach (int value in orderedLinkedList)
            {
                this.Log.Append(value + ", ");
            }
            this.Log.AppendLine();

            //Assert
            Assert.AreEqual(4, orderedLinkedList.Count);
            Assert.AreEqual(valueA, orderedLinkedList[0]);
            Assert.AreEqual(valueB, orderedLinkedList[1]);
            Assert.AreEqual(valueC, orderedLinkedList[2]);
            Assert.AreEqual(valueD, orderedLinkedList[3]);
        }

        [TestMethod]
        public void OrderedSingleLinkedList_CorrectlyRemoves_AtIndex()
        {
            this.TestName = "OrderedSingleLinkedList_CorrectlyRemoves_AtIndex()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.Log.AppendLine("Adding " + valueA + " to the list.");
            orderedLinkedList.Add(valueA);
            this.Log.AppendLine("Adding " + valueB + " to the list.");
            orderedLinkedList.Add(valueB);
            this.Log.AppendLine("Adding " + valueC + " to the list.");
            orderedLinkedList.Add(valueC);

            //Act
            Assert.AreEqual(3, orderedLinkedList.Count);
            orderedLinkedList.RemoveAt(1);

            //Assert
            Assert.AreEqual(valueA, orderedLinkedList[0]);
            Assert.AreEqual(valueC, orderedLinkedList[1]);
            Assert.AreEqual(2, orderedLinkedList.Count);
        }

        [TestMethod]
        public void OrderedSingleLinkedList_CorrectlyRemovesAt_All()
        {
            this.TestName = "OrderedSingleLinkedList_CorrectlyRemovesAt_All()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            int[] values = { valueA, valueB, valueC, valueD };
            this.Log.AppendLine("Adding " + values.ToString() + " to the list.");
            orderedLinkedList.Add(values);

            //Act
            for (int i = orderedLinkedList.Count - 1; i >= 0; i--)
            {
                orderedLinkedList.RemoveAt(i);
            }

            //Assert
            Assert.AreEqual(0, orderedLinkedList.Count);
        }

        [TestMethod]
        public void OrderedSingleLinkedList_CorrectlyRemoves_All()
        {
            this.TestName = "OrderedSingleLinkedList_CorrectlyRemoves_All()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            int[] values = { valueA, valueB, valueC, valueD };
            this.Log.AppendLine("Adding " + values.ToString() + " to the list.");
            orderedLinkedList.Add(values);

            //Act
            foreach (int value in orderedLinkedList)
            {
                orderedLinkedList.Remove(value);
            }

            //Assert
            Assert.AreEqual(0, orderedLinkedList.Count);
        }

        [TestMethod]
        public void OrderedSingleLinkedList_CorrectlyReverses()
        {
            this.TestName = "OrderedSingleLinkedList_CorrectlyReverses()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            int[] values = { valueA, valueB, valueC, valueD };
            this.Log.AppendLine("Adding " + values.ToString() + " to the list.");
            orderedLinkedList.Add(values);

            //Act
            orderedLinkedList.Reverse();

            //Assert
            foreach (int value in orderedLinkedList)
            {
                this.Log.Append(value + ", ");
            }
            this.Log.AppendLine();
            Assert.AreEqual(4, orderedLinkedList.Count);
            Assert.AreEqual(valueD, orderedLinkedList[0]);
            Assert.AreEqual(valueC, orderedLinkedList[1]);
            Assert.AreEqual(valueB, orderedLinkedList[2]);
            Assert.AreEqual(valueA, orderedLinkedList[3]);
        }
    }
}
