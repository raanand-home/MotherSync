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

        double AddAllParameters(string a,int b,int c)
        {
            return int.Parse(a) + b + c;
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

        [TestMethod]
        public void TestActionWithoutPatameters()
        {
            Action functionPointer = null;

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

        [TestMethod]
        public void TestFuncPatameters()
        {
            Func<string,int,int,double> functionPointer = null;
            functionPointer = AddAllParameters;
            var Nume = functionPointer("1", 2, 3);

            Assert.AreEqual(Nume, 6);
        }
    }
}
