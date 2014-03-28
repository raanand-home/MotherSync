using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    delegate void EmptyFunc();
    [TestClass]
    public class TestDelegates
    {
        int Num = 0;
        void IncressNumber()
        {
            Num++;
        }

        [TestMethod]
        public void TestDelegate()
        {
            EmptyFunc functionPointer = null;

            if (functionPointer != null)
            {
                Assert.Fail("this shouldn't happend");
            }

            //Assiment
            functionPointer = IncressNumber;
            
            //Invoke
            functionPointer();

            Assert.AreEqual(Num, 1);

        }
    }
}
