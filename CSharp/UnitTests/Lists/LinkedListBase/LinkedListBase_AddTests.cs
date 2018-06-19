using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists.LinkedListBase
{
    [TestClass]
    public class LinkedListBase_AddTests : LinkedListBaseTests_Base
    {

        [TestMethod]
        public void LinkedListBase_AddTests_CorrectlyAdds_TwoValues()
        {
            this.TestName = "LinkedListBase_AddTests_CorrectlyAdds_TwoValues()";
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
        public void LinkedListBase_AddTests_CorrectlyAdds_ThreeValues()
        {
            this.TestName = "LinkedListBase_AddTests_CorrectlyAdds_ThreeValues()";
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
        public void LinkedListBase_AddTests_CorrectlyAdds_Collection()
        {
            this.TestName = "LinkedListBase_AddTests_CorrectlyAdds_Collection()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.PrintList(this.LinkedListBase);

            //Act
            this.LinkedListBase.AddRange(0, this.Values);
            this.PrintList(this.LinkedListBase);

            //Assert
            Assert.AreEqual(this.Values.Length, this.LinkedListBase.Count());
            for (int i = 0; i < this.LinkedListBase.Count(); i++)
            {
                Assert.AreEqual(this.Values[i], this.LinkedListBase[i]);
            }
        }
    }
}
