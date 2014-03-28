using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    class PropertiesClass
    {
        
        public string Name
        {
            get;

            set;
        }
    }
    [TestClass]
    public class UnitTest1
    {
        PropertiesClass a = new PropertiesClass();
        [TestMethod]
        public void TestMethod1()
        {
            a.Name = "sdf";
        }  
    }
}
