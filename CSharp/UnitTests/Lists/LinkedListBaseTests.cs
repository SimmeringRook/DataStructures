using System;
using DataStructures_CSharp.Lists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Lists
{
    [TestClass]
    public class LinkedListBaseTests_Base : DataStructureTestBase
    {
        protected LinkedListBase<string> LinkedListBase;
        protected string[] Values;
        protected string ValueA;
        protected string ValueB;
        protected string ValueC;
        protected string ValueD;

        [TestInitialize]
        public void LinkedListBaseTests_Initialize()
        {
            this.TestName = "LinkedListBaseTests_Initialize()";
            this.Log.AppendLine(this.TestName);

            this.Log.AppendLine("Creating 'linkedListBase' with default Constructor");
            LinkedListBase = new LinkedListBase<string>();

            ValueA = "A";
            ValueB = "B";
            ValueC = "C";
            ValueD = "D";

            Values = new string[] { ValueA, ValueB, ValueC, ValueD};
        }

        [TestCleanup]
        public void LinkedListBaseTests_CleanUp()
        {
            this.TestName = "LinkedListBaseTests_CleanUp()";
            this.Log.AppendLine(this.TestName);

            this.LinkedListBase.Dispose();
            this.LinkedListBase = null;

            this.ValueA = null;
            this.ValueB = null;
            this.ValueC = null;
            this.ValueD = null;
            this.Values = null;
        }

        public void PrintList(LinkedListBase<string> linkedListBase)
        {
            this.Log.AppendLine("\nList Contents:");
            foreach (string value in linkedListBase)
            {
                this.Log.Append(value + ", ");
            }
            this.Log.AppendLine("\n");
        }


        
    }
}
