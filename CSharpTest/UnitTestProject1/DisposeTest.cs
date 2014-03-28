using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class DisposeTest
    {
        class SomeBigAssResource :IDisposable
        {
            public List<int> VeryUageList = new List<int>(); // Mega or Giga;


            public void Dispose()
            {
                VeryUageList.Clear();
            }
        }

        [TestMethod]
        public void UsingTest()
        {
            IDisposable a = null;
            try
            {
                var file = Path.GetTempFileName();
                a = File.Open(file, FileMode.Create);
            }
            finally
            {
                a.Dispose();
            }
        }

        [TestMethod]
        public void UsingMyBigResourceUsingTest()
        {
            SomeBigAssResource a = new SomeBigAssResource();
            a.Dispose();
            using (SomeBigAssResource b = new SomeBigAssResource())
            {
                for (int i = 0 ; i< 100; i++)
                {
                    b.VeryUageList.Add(i);
                }
            }
        }
    }
}
