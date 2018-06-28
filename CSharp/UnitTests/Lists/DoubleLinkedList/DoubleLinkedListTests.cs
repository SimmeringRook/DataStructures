using System;
using DataStructures_CSharp.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists.DoubleLinkedList
{
    [TestClass]
    public class DoubleLinkedListTests : DataStructureTestBase
    {
        protected DoubleLinkedList<string> DoubleLinkedList;
        protected string[] Values;
        protected string ValueA;
        protected string ValueB;
        protected string ValueC;
        protected string ValueD;

        [TestInitialize]
        public void DoubleLinkedListTests_Initialize()
        {
            this.TestName = "DoubleLinkedListTests_Initialize()";
            this.Log.AppendLine(this.TestName);

            this.Log.AppendLine("Creating 'DoubleLinkedList' with default Constructor");
            DoubleLinkedList = new DoubleLinkedList<string>();

            ValueA = "A";
            ValueB = "B";
            ValueC = "C";
            ValueD = "D";

            Values = new string[] { ValueA, ValueB, ValueC, ValueD };
        }

        [TestCleanup]
        public void DoubleLinkedListTests_CleanUp()
        {
            this.TestName = "DoubleLinkedListTests_CleanUp()";
            this.Log.AppendLine(this.TestName);

            this.DoubleLinkedList.Dispose();
            this.DoubleLinkedList = null;

            this.ValueA = null;
            this.ValueB = null;
            this.ValueC = null;
            this.ValueD = null;
            this.Values = null;
        }

        public void PrintList(DoubleLinkedList<string> doubleLinkedList)
        {
            this.Log.AppendLine("\nList Contents:");
            foreach (string value in doubleLinkedList)
            {
                this.Log.Append(value + ", ");
            }
            this.Log.AppendLine("\n");
        }

    }
}
