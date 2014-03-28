using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    partial class PartialExmpale
    {
        public int A;
    }

    partial class PartialExmpale
    {
        public int B;
    }

    [TestClass]
    public class PartialClass
    {
        [TestMethod]
        public void TestMethod1()
        {
            PartialExmpale a = new PartialExmpale() { A = 1, B = 3 };
        }
    }
}
