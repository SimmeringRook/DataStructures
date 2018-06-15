using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DataStructureTestBase
    {
        private string testClassName;
        protected string TestName;
        public StringBuilder Log;

        [TestInitialize]
        public void Initialize()
        {
            testClassName = "DataStructureTestBase";
            TestName = "Initialize()";
            Log = new StringBuilder();

            Log.AppendLine(testClassName + "." + TestName);
            this.Log.AppendLine();
        }

        [TestCleanup]
        public void CleanUp()
        {
            testClassName = "DataStructureTestBase";
            TestName = "CleanUp()";
            Log.AppendLine(testClassName + "." + TestName);

            Console.WriteLine(Log.ToString());
            Log = null;
        }
    }
}
