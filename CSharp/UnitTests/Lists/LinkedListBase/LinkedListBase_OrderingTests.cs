using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists.LinkedList
{
    [TestClass]
    public class LinkedListBase_OrderingTests : LinkedListBaseTests_Base
    {
        [TestInitialize]
        public void LinkedListBase_OrderingTests_Initialize()
        {
            this.TestName = "LinkedListBase_OrderingTests_Initialize()";
            this.Log.AppendLine(this.TestName);
            this.LinkedListBase.AddRange(this.Values);
            this.PrintList(this.LinkedListBase);
        }

        [TestMethod]
        public void LinkedListBase_Updates_MinAndMax_Successfully()
        {
            this.TestName = "LinkedListBase_Updates_MinAndMax_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.LinkedListBase.Clear();
            Assert.AreEqual(0, this.LinkedListBase.Count());

            this.LinkedListBase.Add(this.ValueB);
            string oldMin = this.LinkedListBase.GetMinimum();
            string oldMax = this.LinkedListBase.GetMaximum();

            //Act
            this.LinkedListBase.Add(this.ValueA);
            this.LinkedListBase.Add(this.ValueC);

            this.Log.AppendLine("Minimum: " + oldMin + " | " + this.LinkedListBase.GetMinimum());
            this.Log.AppendLine("Maximum: " + oldMax + " | " + this.LinkedListBase.GetMaximum());

            //Assert
            Assert.AreEqual(3, this.LinkedListBase.Count());
            Assert.AreNotEqual(oldMin, this.LinkedListBase.GetMinimum());
            Assert.AreNotEqual(oldMax, this.LinkedListBase.GetMaximum());
        }

        [TestMethod]
        public void LinkedListBase_Reverses_Successfully()
        {
            this.TestName = "LinkedListBase_Reverses_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.PrintList(this.LinkedListBase);

            //Act
            this.Log.Append("linkedListBase.Reverse()");
            LinkedListBase.Reverse();

            this.PrintList(this.LinkedListBase);

            //Assert
            Assert.AreEqual(4, this.LinkedListBase.Count());
            Assert.AreEqual(this.ValueD, this.LinkedListBase[0]);
        }

        [TestMethod]
        public void LinkedListBase_Sorts_ByDefaultComparer_Successfully()
        {
            this.TestName = "LinkedListBase_Sorts_ByDefaultComparer_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.PrintList(this.LinkedListBase);

            //Act
            this.Log.Append("linkedListBase.Sort()");
            LinkedListBase.Sort();

            this.PrintList(this.LinkedListBase);

            //Assert
            Assert.AreEqual(4, this.LinkedListBase.Count());
            for (int i = 0; i < this.Values.Length; i++)
            {
                Assert.AreEqual(this.Values[i], this.LinkedListBase[i]);
            }
        }
    }
}
