using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ArrayTest
    {
        int[] intParam;
        [TestMethod]
        public void TestMethodArray()
        {
            intParam = new int[20];
            if (!(intParam is int[]))
                Assert.Fail("intPrame is not array int");

            if (intParam.GetType() != typeof(int[]))
                Assert.Fail("intPrame is not typeof  array int");
        }
    }
}
