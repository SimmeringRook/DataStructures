using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures_CSharp.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists.SortedLinkedList
{
    [TestClass]
    public class SortedLinkedListTests : LinkedListBaseTests_Base
    {
        protected SortedLinkedList<string> SortedLinkedList;

        [TestInitialize]
        public void init()
        {
            this.SortedLinkedList = new SortedLinkedList<string>();

        }
        [TestMethod]
        public void SortedLinkedList_Adds_TwoValues_Successfully()
        {
            this.TestName = "SortedLinkedList_Adds_TwoValues_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.SortedLinkedList.Add(this.ValueB);
            this.PrintList(this.SortedLinkedList);

            //Act
            this.SortedLinkedList.Add(this.ValueA);
            this.PrintList(this.SortedLinkedList);
            
            //Assert
            Assert.IsNotNull(this.SortedLinkedList[1]);
            Assert.AreEqual(2, this.SortedLinkedList.Count());
        }

        [TestMethod]
        public void SortedLinkedList_Adds_ThreeValues_Successfully()
        {
            this.TestName = "SortedLinkedList_Adds_ThreeValues_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.SortedLinkedList.Add(this.ValueA);
            this.SortedLinkedList.Add(this.ValueB);
            this.PrintList(this.SortedLinkedList);

            //Act
            this.SortedLinkedList.Add(this.ValueC);
            this.PrintList(this.SortedLinkedList);

            //Assert
            Assert.IsNotNull(this.SortedLinkedList[2]);
            Assert.AreEqual(this.ValueC, this.SortedLinkedList.GetMaximum());
            Assert.AreEqual(this.ValueA, this.SortedLinkedList.GetMinimum());
            Assert.AreEqual(3, this.SortedLinkedList.Count());
        }

        [TestMethod]
        public void SortedLinkedList_Adds_Collection_Successfully()
        {
            this.TestName = "SortedLinkedList_Adds_Collection_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.PrintList(this.SortedLinkedList);

            //Act
            this.SortedLinkedList.AddRange(this.Values);
            this.PrintList(this.SortedLinkedList);

            //Assert
            Assert.AreEqual(this.Values.Length, this.SortedLinkedList.Count());
            for (int i = this.SortedLinkedList.Count() - 1; i >= 0; i--)
            {
                Assert.AreEqual(this.Values[i], this.SortedLinkedList[i]);
            }
        }

        [TestMethod]
        public void SortedLinkedList_Removes_Value_Successfully()
        {
            this.TestName = "SortedLinkedList_Removes_Value_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.SortedLinkedList.AddRange(this.Values);
            this.PrintList(this.SortedLinkedList);

            //Act
            this.SortedLinkedList.Remove(this.ValueB);
            this.PrintList(this.SortedLinkedList);

            //Assert
            Assert.AreEqual(3, this.SortedLinkedList.Count());
            Assert.AreEqual(this.ValueD, this.SortedLinkedList.GetMaximum());
            Assert.AreEqual(this.ValueA, this.SortedLinkedList.GetMinimum());
        }

        [TestMethod]
        public void SortedLinkedList_Removes_Minimum_Successfully()
        {
            this.TestName = "SortedLinkedList_Removes_Minimum_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.SortedLinkedList.AddRange(this.Values);
            this.PrintList(this.SortedLinkedList);

            //Act
            this.SortedLinkedList.Remove(this.ValueA);
            this.PrintList(this.SortedLinkedList);

            //Assert
            Assert.AreEqual(3, this.SortedLinkedList.Count());
            Assert.AreEqual(this.ValueD, this.SortedLinkedList.GetMaximum());
            Assert.AreEqual(this.ValueB, this.SortedLinkedList.GetMinimum());
        }

        [TestMethod]
        public void SortedLinkedList_Removes_Maximum_Successfully()
        {
            this.TestName = "SortedLinkedList_Removes_Maximum_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.SortedLinkedList.AddRange(this.Values);
            this.PrintList(this.SortedLinkedList);

            //Act
            this.SortedLinkedList.Remove(this.ValueD);
            this.PrintList(this.SortedLinkedList);

            //Assert
            Assert.AreEqual(3, this.SortedLinkedList.Count());
            Assert.AreEqual(this.ValueC, this.SortedLinkedList.GetMaximum());
            Assert.AreEqual(this.ValueA, this.SortedLinkedList.GetMinimum());
        }

        class ComparerCreator<R> 
        {
            public static IComparer<R> GetAscendingComparer()
            {
                return (IComparer<R>)new AscendingHelper<R>();
            }

            public static IComparer<R> GetDescendingComparer()
            {
                return (IComparer<R>)new DescendingHelper<R>();
            }

            private class AscendingHelper<T> : IComparer<T>
            {
                int IComparer<T>.Compare(T x, T y)
                {
                    return string.Compare(x.ToString(), y.ToString());
                }
            }

            private class DescendingHelper<T> : IComparer<T>
            {
                int IComparer<T>.Compare(T x, T y)
                {
                    return string.Compare(x.ToString(), y.ToString()) * -1;
                }
            }
        }

        [TestMethod]
        public void SortedLinkedList_Sorts_Descending_Successfully()
        {
            this.TestName = "SortedLinkedList_Sorts_Descending_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.SortedLinkedList.AddRange(this.Values);
            this.PrintList(this.SortedLinkedList);
            IComparer<string> descending = ComparerCreator<string>.GetDescendingComparer();

            //Act
            this.SortedLinkedList.Sort(descending);
            this.PrintList(this.SortedLinkedList);

            //Assert
            Assert.AreEqual(4, this.SortedLinkedList.Count());
            Assert.AreEqual(this.ValueA, this.SortedLinkedList.GetMaximum());
            Assert.AreEqual(this.ValueD, this.SortedLinkedList.GetMinimum());
        }

        [TestMethod]
        public void SortedLinkedList_Reverses_Successfully()
        {
            this.TestName = "SortedLinkedList_Reverses_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            this.SortedLinkedList.AddRange(this.Values);
            this.PrintList(this.SortedLinkedList);
            

            //Act
            this.SortedLinkedList.Reverse();
            this.PrintList(this.SortedLinkedList);

            //Assert
            Assert.AreEqual(4, this.SortedLinkedList.Count());
            Assert.AreEqual(this.ValueA, this.SortedLinkedList.GetMaximum());
            Assert.AreEqual(this.ValueD, this.SortedLinkedList.GetMinimum());
        }
    }
}
