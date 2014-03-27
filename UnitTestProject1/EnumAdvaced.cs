using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [Flags]
    enum EAdvance: byte
    {
        A =1 ,
        B = 2,
     //   C = 3,
    }

    [TestClass]
    public class EnumAdvaced
    {
        [TestMethod]
        public void TestSizeOf()
        {
            EAdvance a = EAdvance.A | EAdvance.B;

            Assert.AreEqual(sizeof(EAdvance), sizeof(byte));
        }
        [TestMethod]
        public void TestFlags()
        {
            EAdvance a = EAdvance.A | EAdvance.B;
            Assert.AreEqual((byte)a, 3);
        }
    }
}
