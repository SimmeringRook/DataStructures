using DataStructures_CSharp.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists
{
    [TestClass]
    public class UnorderedSingleLinkedListTests : DataStructureTestBase
    {
        private UnorderedSingleLinkedList<string> unorderedSingleLinkedList;
        private string valueA;
        private string valueB;
        private string valueC;
        private string valueD;

        [TestInitialize]
        public void UnorderedSingleLinkedListTests_Initialize()
        {
            this.TestName = "UnorderedSingleLinkedListTests_Initialize()";
            this.Log.AppendLine(this.TestName);

            this.Log.AppendLine("Creating 'unorderedSingleLinkedList' with default Constructor");
            unorderedSingleLinkedList = new UnorderedSingleLinkedList<string>();

            valueA = "A";
            valueB = "B";
            valueC = "C";
            valueD = "D";
        }

        [TestCleanup]
        public void UnorderedSingleLinkedListTests_CleanUp()
        {
            this.TestName = "UnorderedSingleLinkedListTests_CleanUp()";
            this.Log.AppendLine(this.TestName);

            unorderedSingleLinkedList = null;

            valueA = null;
            valueB = null;
            valueC = null;
            valueD = null;
        }

        [TestMethod]
        public void UnorderedSingleLinkedList_CorrectlyAdds_OneValue()
        {
            this.TestName = "UnorderedSingleLinkedList_CorrectlyAdds_OneValue()";
            this.Log.AppendLine(this.TestName);
            
            //Arrange

            //Act
            this.Log.AppendLine("Adding " + valueA + " to the list.");
            unorderedSingleLinkedList.Add(valueA);

            //Assert
            Assert.AreEqual(valueA, unorderedSingleLinkedList[0]);
            Assert.AreEqual(1, unorderedSingleLinkedList.Count);
        }

        [TestMethod]
        public void UnorderedSingleLinkedList_CorrectlyAdds_TwoValues()
        {
            this.TestName = "UnorderedSingleLinkedList_CorrectlyAdds_TwoValues()";
            this.Log.AppendLine(this.TestName);

            //Arrange

            //Act
            this.Log.AppendLine("Adding " + valueA + " to the list.");
            unorderedSingleLinkedList.Add(valueA);
            this.Log.AppendLine("Adding " + valueB + " to the list.");
            unorderedSingleLinkedList.Add(valueB);

            //Assert
            Assert.AreEqual(valueA, unorderedSingleLinkedList[0]);
            Assert.AreEqual(valueB, unorderedSingleLinkedList[1]);
            Assert.AreEqual(2, unorderedSingleLinkedList.Count);
        }

        [TestMethod]
        public void UnorderedSingleLinkedList_CorrectlyAdds_Collection()
        {
            this.TestName = "UnorderedSingleLinkedList_CorrectlyAdds_Collection()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            string[] values = { valueA, valueB, valueC, valueD };

            //Act
            this.Log.AppendLine("Adding " + values.ToString() + " to the list.");
            unorderedSingleLinkedList.Add(values);

            //Assert
            Assert.AreEqual(4, unorderedSingleLinkedList.Count);
            Assert.AreEqual(valueA, unorderedSingleLinkedList[0]);
            Assert.AreEqual(valueB, unorderedSingleLinkedList[1]);
            Assert.AreEqual(valueC, unorderedSingleLinkedList[2]);
            Assert.AreEqual(valueD, unorderedSingleLinkedList[3]);
        }

        [TestMethod]
        public void UnorderedSingleLinkedList_CorrectlyRemoves_Head()
        {
            this.TestName = "UnorderedSingleLinkedList_CorrectlyRemoves_Head()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.Log.AppendLine("Adding " + valueA + " to the list.");
            unorderedSingleLinkedList.Add(valueA);
            this.Log.AppendLine("Adding " + valueB + " to the list.");
            unorderedSingleLinkedList.Add(valueB);

            //Act
            unorderedSingleLinkedList.Remove(valueA);

            //Assert
            Assert.AreEqual(valueB, unorderedSingleLinkedList[0]);
            Assert.AreEqual(1, unorderedSingleLinkedList.Count);
        }

        [TestMethod]
        public void UnorderedSingleLinkedList_CorrectlyRemoves_AtIndex()
        {
            this.TestName = "UnorderedSingleLinkedList_CorrectlyRemoves_AtIndex()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.Log.AppendLine("Adding " + valueA + " to the list.");
            unorderedSingleLinkedList.Add(valueA);
            this.Log.AppendLine("Adding " + valueB + " to the list.");
            unorderedSingleLinkedList.Add(valueB);
            this.Log.AppendLine("Adding " + valueC + " to the list.");
            unorderedSingleLinkedList.Add(valueC);

            //Act
            Assert.AreEqual(3, unorderedSingleLinkedList.Count);
            unorderedSingleLinkedList.RemoveAt(1);

            //Assert
            Assert.AreEqual(valueA, unorderedSingleLinkedList[0]);
            Assert.AreEqual(valueC, unorderedSingleLinkedList[1]);
            Assert.AreEqual(2, unorderedSingleLinkedList.Count);
        }

        [TestMethod]
        public void UnorderedSingleLinkedList_CorrectlyRemovesAt_All()
        {
            this.TestName = "UnorderedSingleLinkedList_CorrectlyRemovesAt_All()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            string[] values = { valueA, valueB, valueC, valueD };
            this.Log.AppendLine("Adding " + values.ToString() + " to the list.");
            unorderedSingleLinkedList.Add(values);

            //Act
            for (int i = unorderedSingleLinkedList.Count - 1; i >= 0; i--)
            {
                unorderedSingleLinkedList.RemoveAt(i);
            }

            //Assert
            Assert.AreEqual(0, unorderedSingleLinkedList.Count);
        }

        [TestMethod]
        public void UnorderedSingleLinkedList_CorrectlyRemoves_All()
        {
            this.TestName = "UnorderedSingleLinkedList_CorrectlyRemoves_All()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            string[] values = { valueA, valueB, valueC, valueD };
            this.Log.AppendLine("Adding " + values.ToString() + " to the list.");
            unorderedSingleLinkedList.Add(values);

            //Act
            foreach (string value in unorderedSingleLinkedList)
            {
                unorderedSingleLinkedList.Remove(value);
            }

            //Assert
            Assert.AreEqual(0, unorderedSingleLinkedList.Count);
        }

        [TestMethod]
        public void UnorderedSingleLinkedList_CorrectlyInserts()
        {
            this.TestName = "UnorderedSingleLinkedList_CorrectlyInserts()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            string[] values = { valueA, valueB, valueD };
            this.Log.AppendLine("Adding " + values.ToString() + " to the list.");
            unorderedSingleLinkedList.Add(values);

            //Act
            unorderedSingleLinkedList.Insert(2, valueC);
            
            //Assert
            foreach (string value in unorderedSingleLinkedList)
            {
                this.Log.Append(value + ", ");
            }
            this.Log.AppendLine();
            Assert.AreEqual(4, unorderedSingleLinkedList.Count);
            Assert.AreEqual(valueC, unorderedSingleLinkedList[2]);
        }
    }
}
