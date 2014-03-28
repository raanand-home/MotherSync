using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class GarbageC
    {
        [TestMethod]
        public void TestGC()
        {
            var a = new GarbageC();
            a = null;

            System.GC.Collect();
            

        }
    }
}
