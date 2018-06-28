using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists.DoubleLinkedList
{
    [TestClass]
    public class DoubleLinkedList_OrderingTests : DoubleLinkedListTests
    {
        [TestInitialize]
        public void DoubleLinkedList_OrderingTests_Initialize()
        {
            this.TestName = "DoubleLinkedList_OrderingTests_Initialize()";
            this.Log.AppendLine(this.TestName);
            this.DoubleLinkedList.AddRange(this.Values);
            this.PrintList(this.DoubleLinkedList);
        }

        [TestMethod]
        public void DoubleLinkedList_Updates_MinAndMax_Successfully()
        {
            this.TestName = "DoubleLinkedList_Updates_MinAndMax_Successfully";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.DoubleLinkedList.Clear();
            Assert.AreEqual(0, this.DoubleLinkedList.Count());

            this.DoubleLinkedList.Add(this.ValueB);
            string oldMin = this.DoubleLinkedList.GetMinimum();
            string oldMax = this.DoubleLinkedList.GetMaximum();

            //Act
            this.DoubleLinkedList.Add(this.ValueA);
            this.DoubleLinkedList.Add(this.ValueC);

            this.Log.AppendLine("Minimum: " + oldMin + " | " + this.DoubleLinkedList.GetMinimum());
            this.Log.AppendLine("Maximum: " + oldMax + " | " + this.DoubleLinkedList.GetMaximum());

            //Assert
            Assert.AreEqual(3, this.DoubleLinkedList.Count());
            Assert.AreNotEqual(oldMin, this.DoubleLinkedList.GetMinimum());
            Assert.AreNotEqual(oldMax, this.DoubleLinkedList.GetMaximum());
        }

        [TestMethod]
        public void DoubleLinkedList_Reverses_Successfully()
        {
            this.TestName = "DoubleLinkedList_Reverses_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.PrintList(this.DoubleLinkedList);

            //Act
            this.Log.Append("DoubleLinkedList.Reverse()");
            DoubleLinkedList.Reverse();

            this.PrintList(this.DoubleLinkedList);

            //Assert
            Assert.AreEqual(4, this.DoubleLinkedList.Count());
            Assert.AreEqual(this.ValueD, this.DoubleLinkedList[0]);
        }

        [TestMethod]
        public void DoubleLinkedList_Sorts_Successfully()
        {
            this.TestName = "DoubleLinkedList_Sorts_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange

            //Act
            this.Log.Append("DoubleLinkedList.Sort()");
            DoubleLinkedList.Sort();

            this.PrintList(this.DoubleLinkedList);

            //Assert
            Assert.AreEqual(4, this.DoubleLinkedList.Count());
            for (int i = 0; i < this.Values.Length; i++)
            {
                Assert.AreEqual(this.Values[i], this.DoubleLinkedList[i]);
            }
        }
    }
}
