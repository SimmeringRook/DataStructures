using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists.DoubleLinkedList
{
    [TestClass]
    public class DoubleLinkedListTests_AddTests : DoubleLinkedListTests
    {
        
        [TestMethod]
        public void DoubleLinkedList_Adds_TwoValues_Successfully()
        {
            this.TestName = "DoubleLinkedList_Adds_TwoValues_Successfully()";
            this.Log.AppendLine(this.TestName);
            
            //Arrange
            this.DoubleLinkedList.Add(this.ValueB);

            //Act
            this.DoubleLinkedList.Add(this.ValueA);

            //Assert
            Assert.IsNotNull(this.DoubleLinkedList[1]);
            Assert.AreEqual(2, this.DoubleLinkedList.Count());
        }

        [TestMethod]
        public void DoubleLinkedList_Adds_ThreeValues_Successfully()
        {
            this.TestName = "DoubleLinkedList_Adds_ThreeValues_Successfully()";
            this.Log.AppendLine(this.TestName);
            
            //Arrange
            this.DoubleLinkedList.Add(this.ValueA);
            this.DoubleLinkedList.Add(this.ValueB);
            this.PrintList(this.DoubleLinkedList);

            //Act
            this.DoubleLinkedList.Add(this.ValueC);
            this.PrintList(this.DoubleLinkedList);

            //Assert
            Assert.IsNotNull(this.DoubleLinkedList[2]);
            Assert.AreEqual(3, this.DoubleLinkedList.Count());
        }

        [TestMethod]
        public void DoubleLinkedList_Adds_Collection_Successfully()
        {
            this.TestName = "DoubleLinkedList_Adds_Collection_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.PrintList(this.DoubleLinkedList);

            //Act
            this.DoubleLinkedList.AddRange(this.Values);
            this.PrintList(this.DoubleLinkedList);

            //Assert
            Assert.AreEqual(this.Values.Length, this.DoubleLinkedList.Count());
            for (int i = 0; i < this.DoubleLinkedList.Count(); i++)
            {
                Assert.AreEqual(this.Values[i], this.DoubleLinkedList[i]);
            }
        }
    }
}
