using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists.LinkedListBase
{
    [TestClass]
    public class LinkedListBase_RemoveTests : LinkedListBaseTests_Base
    {
        [TestInitialize]
        public void LinkedListBase_RemoveTests_Initialize()
        {
            this.TestName = "LinkedListBase_RemoveTests_Initialize()";
            this.Log.AppendLine(this.TestName);
            this.LinkedListBase.AddRange(0, this.Values);
            this.PrintList(this.LinkedListBase);
        }

        [TestMethod]
        public void LinkedListBase_RemoveTests_CorrectlyRemoves_Value()
        {
            this.TestName = "LinkedListBase_RemoveTests_CorrectlyRemoves_Value()";
            this.Log.AppendLine(this.TestName);

            //Arrange

            //Act
            this.LinkedListBase.Remove(this.ValueA);
            this.PrintList(this.LinkedListBase);

            //Assert
            Assert.AreEqual(this.Values.Length - 1, this.LinkedListBase.Count());

            for (int i = 0; i < this.Values.Length; i++)
            {
                if (i > 0)
                    Assert.AreEqual(this.Values[i], this.LinkedListBase[i - 1]);
            }
        }

        [TestMethod]
        public void LinkedListBase_RemoveTests_CorrectlyRemovesAt_Index()
        {
            this.TestName = "LinkedListBase_RemoveTests_CorrectlyRemovesAt_Index()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            int index = 1;

            //Act
            this.LinkedListBase.RemoveAt(index);
            this.PrintList(this.LinkedListBase);

            //Assert
            Assert.AreEqual(3, this.LinkedListBase.Count());
            Assert.AreEqual(this.ValueA, this.LinkedListBase[0]);
            Assert.AreEqual(this.ValueC, this.LinkedListBase[1]);
            Assert.AreEqual(this.ValueD, this.LinkedListBase[2]);
        }

        [TestMethod]
        public void LinkedListBase_RemoveTests_CorrectlyRemoves_Collection()
        {
            this.TestName = "LinkedListBase_RemoveTests_CorrectlyRemoves_Collection()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            int startIndex = 1;
            int length = 2;

            //Act
            this.LinkedListBase.RemoveRange(startIndex, length);
            this.PrintList(this.LinkedListBase);

            //Assert
            Assert.AreEqual(2, this.LinkedListBase.Count());
            Assert.AreEqual(this.ValueA, this.LinkedListBase[0]);
            Assert.AreEqual(this.ValueD, this.LinkedListBase[1]);
        }

        [TestMethod]
        public void LinkedListBase_RemoveTests_Correctly_Clear()
        {
            this.TestName = "LinkedListBase_RemoveTests_Correctly_Clear()";
            this.Log.AppendLine(this.TestName);

            //Arrange

            //Act
            this.LinkedListBase.Clear();
            this.PrintList(this.LinkedListBase);

            //Assert
            Assert.AreEqual(0, this.LinkedListBase.Count());
        }
    }
}
