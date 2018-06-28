using System;
using DataStructures_CSharp.Stacks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Stacks
{
    [TestClass]
    public class StackTests : DataStructureTestBase
    {
        protected Stack<string> Stack;
        protected string[] Values;
        protected string ValueA;
        protected string ValueB;
        protected string ValueC;
        protected string ValueD;

        [TestInitialize]
        public void StackTests_Initialize()
        {
            this.TestName = "StackTests_Initialize()";
            this.Log.AppendLine(this.TestName);

            this.Log.AppendLine("Creating 'Stack' with default Constructor");
            Stack = new Stack<string>();

            ValueA = "A";
            ValueB = "B";
            ValueC = "C";
            ValueD = "D";

            Values = new string[] { ValueA, ValueB, ValueC, ValueD };
        }

        [TestCleanup]
        public void StackTests_Cleanup()
        {
            this.TestName = "StackTests_Cleanup()";
            this.Log.AppendLine(this.TestName);

            this.Stack.Dispose();
            this.Stack = null;

            this.ValueA = null;
            this.ValueB = null;
            this.ValueC = null;
            this.ValueD = null;
            this.Values = null;
        }

        [TestMethod]
        public void Stack_Adds_Value_Successfully()
        {
            this.TestName = "Stack_Adds_Value_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange

            //Act
            this.Stack.Push(this.ValueA);

            //Assert
            Assert.AreEqual(this.ValueA, this.Stack.Peak());
            Assert.AreEqual(1, this.Stack.Count);
        }

        [TestMethod]
        public void Stack_Constructs_WithValues_Successfully()
        {
            this.TestName = "Stack_Constructs_WithValues_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange

            //Act
            this.Stack = new Stack<string>(this.Values);

            //Assert
            Assert.AreEqual(this.ValueD, this.Stack.Peak());
            Assert.AreEqual(4, this.Stack.Count);
        }

        [TestMethod]
        public void Stack_Removes_Values_Successfully()
        {
            this.TestName = "Stack_Removes_Values_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            foreach (string value in this.Values)
            {
                this.Stack.Push(value);
            }
            Assert.AreEqual(this.ValueD, this.Stack.Peak());
            Assert.AreEqual(4, this.Stack.Count);

            string[] valuesFromStack = new string[this.Values.Length];

            //Act
            for(int i = this.Stack.Count; i > 0; i--)
            {
                valuesFromStack[i-1] = this.Stack.Pop();
            }

            //Assert
            Assert.AreEqual(0, this.Stack.Count);
            
            for(int i = 0; i < this.Values.Length; i++)
            {
                Assert.AreEqual(this.Values[i], valuesFromStack[i]);
            }
        }

        [TestMethod]
        public void Stack_Adds_Removes_ThenAdds_Successfully()
        {
            this.TestName = "Stack_Adds_Removes_ThenAdds_Successfully()";
            this.Log.AppendLine(this.TestName);

            //Arrange
            foreach (string value in this.Values)
            {
                this.Stack.Push(value);
            }
            Assert.AreEqual(this.ValueD, this.Stack.Peak());
            Assert.AreEqual(4, this.Stack.Count);

            string[] valuesFromStack = new string[6];

            //Act
            for (int i = 0; i < 2; i++)
            {
                valuesFromStack[i] = this.Stack.Pop();
            }

            foreach (string value in this.Values)
            {
                this.Stack.Push(value);
            }

            //Assert
            Assert.AreEqual(6, this.Stack.Count);

            for (int i = 3; i >= 0; i--)
            {
                Assert.AreEqual(this.Values[i], this.Stack.Pop());
            }

            Assert.AreEqual(this.ValueB, this.Stack.Pop());
            Assert.AreEqual(this.ValueA, this.Stack.Pop());
        }
    }
}
