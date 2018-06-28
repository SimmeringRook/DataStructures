using DataStructures_CSharp.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists.LinkedList
{
    [TestClass]
    public class LinkedListBase_AddTests : LinkedListBaseTests_Base
    {
        [TestMethod]
        public void LinkedListBase_Adds_TwoValues_Successfully()
        {
            this.TestName = "LinkedListBase_Adds_TwoValues_Successfully()";
            this.Log.AppendLine(this.TestName);
            
            //Arrange
            this.LinkedListBase.Add(this.ValueB);

            //Act
            this.LinkedListBase.Add(this.ValueA);

            //Assert
            Assert.IsNotNull(this.LinkedListBase[1]);
            Assert.AreEqual(2, this.LinkedListBase.Count());
        }

        [TestMethod]
        public void LinkedListBase_Adds_ThreeValues_Successfully()
        {
            this.TestName = "LinkedListBase_Adds_ThreeValues_Successfully()";
            this.Log.AppendLine(this.TestName);
            
            //Arrange
            this.LinkedListBase.Add(this.ValueA);
            this.LinkedListBase.Add(this.ValueB);
            this.PrintList(this.LinkedListBase);

            //Act
            this.LinkedListBase.Add(this.ValueC);
            this.PrintList(this.LinkedListBase);

            //Assert
            Assert.IsNotNull(this.LinkedListBase[2]);
            Assert.AreEqual(3, this.LinkedListBase.Count());
        }

        [TestMethod]
        public void LinkedListBase_Adds_Collection_Successfully()
        {
            this.TestName = "LinkedListBase_Adds_Collection_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.PrintList(this.LinkedListBase);

            //Act
            this.LinkedListBase.AddRange(this.Values);
            this.PrintList(this.LinkedListBase);

            //Assert
            Assert.AreEqual(this.Values.Length, this.LinkedListBase.Count());
            for (int i = 0; i < this.LinkedListBase.Count(); i++)
            {
                Assert.AreEqual(this.Values[i], this.LinkedListBase[i]);
            }
        }

        [TestMethod]
        public void LinkedListBase_Copies_Successfully()
        {
            this.TestName = "LinkedListBase_Copies_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.LinkedListBase.AddRange(this.Values);
            this.PrintList(this.LinkedListBase);

            //Act
            LinkedListBase<string> copyOfList = this.LinkedListBase.Copy();
            this.PrintList(copyOfList);

            //Assert
            Assert.AreEqual(this.Values.Length, copyOfList.Count());
            for (int i = 0; i < this.LinkedListBase.Count(); i++)
            {
                Assert.AreEqual(this.LinkedListBase[i], copyOfList[i]);
            }
        }
    }
}
