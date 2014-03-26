using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    class ACompare : IComparable<ACompare>
    {
        public int a;
        public int CompareTo(ACompare other)
        {
            return a - other.a;
        }
    }
    [TestClass]
    public class UnitTest2
    {
        List<ACompare> l = new List<ACompare>();
        [TestMethod]
        public void TestCompare()
        {
           for (int i = 10 ; i>0 ;i--)
           {
               l.Add(new ACompare { a = i });
           }
           l.Sort();
           Assert.AreEqual(l.ToArray()[0].a, 1);
        }
    }
}
