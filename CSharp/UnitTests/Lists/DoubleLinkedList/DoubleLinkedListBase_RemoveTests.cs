using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists.DoubleLinkedList
{
    [TestClass]
    public class DoubleLinkedList_RemoveTests : DoubleLinkedListTests
    {
        [TestInitialize]
        public void DoubleLinkedList_RemoveTests_Initialize()
        {
            this.TestName = "DoubleLinkedList_RemoveTests_Initialize()";
            this.Log.AppendLine(this.TestName);
            this.DoubleLinkedList.AddRange(this.Values);
            this.PrintList(this.DoubleLinkedList);
        }

        [TestMethod]
        public void DoubleLinkedList_Removes_Value_Successfully()
        {
            this.TestName = "DoubleLinkedList_Removes_Value_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange

            //Act
            this.DoubleLinkedList.Remove(this.ValueA);
            this.PrintList(this.DoubleLinkedList);

            //Assert
            Assert.AreEqual(this.Values.Length - 1, this.DoubleLinkedList.Count());

            for (int i = 0; i < this.Values.Length; i++)
            {
                if (i > 0)
                    Assert.AreEqual(this.Values[i], this.DoubleLinkedList[i - 1]);
            }
        }

        [TestMethod]
        public void DoubleLinkedList_Removes_AtIndex_Successfully()
        {
            this.TestName = "DoubleLinkedList_Removes_AtIndex_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            int index = 1;

            //Act
            this.DoubleLinkedList.RemoveAt(index);
            this.PrintList(this.DoubleLinkedList);

            //Assert
            Assert.AreEqual(3, this.DoubleLinkedList.Count());
            Assert.AreEqual(this.ValueA, this.DoubleLinkedList[0]);
            Assert.AreEqual(this.ValueC, this.DoubleLinkedList[1]);
            Assert.AreEqual(this.ValueD, this.DoubleLinkedList[2]);
        }

        [TestMethod]
        public void DoubleLinkedList_Removes_Range_Successfully()
        {
            this.TestName = "DoubleLinkedList_Removes_Range_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            int startIndex = 1;
            int length = 2;

            //Act
            this.DoubleLinkedList.RemoveRange(startIndex, length);
            this.PrintList(this.DoubleLinkedList);

            //Assert
            Assert.AreEqual(2, this.DoubleLinkedList.Count());
            Assert.AreEqual(this.ValueA, this.DoubleLinkedList[0]);
            Assert.AreEqual(this.ValueD, this.DoubleLinkedList[1]);
        }

        [TestMethod]
        public void DoubleLinkedList_Clears_Successfully()
        {
            this.TestName = "DoubleLinkedList_Clears_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange

            //Act
            this.DoubleLinkedList.Clear();
            this.PrintList(this.DoubleLinkedList);

            //Assert
            Assert.AreEqual(0, this.DoubleLinkedList.Count());
        }
    }
}
