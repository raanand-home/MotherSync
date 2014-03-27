using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    struct A
    {
        public int fieldA;
        public int fieldB;

    }

    [TestClass]
    public class StructInitTest
    {
        [TestMethod]
        public void TestInitStruct()
        {
            A a = new A { fieldA = 1, fieldB = 2 };
            Assert.AreEqual(a.fieldA, 1);
        }
    }
    
}
