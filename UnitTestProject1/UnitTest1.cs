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
        public string this[string key]
        {
            get
            {
                if(key == "hello")
                {
                    return "World";
                }
                throw new NotImplementedException();
            }
            set
            {
                Name = value + key;
            }
        }
    }
    [TestClass]
    public class UnitTest1
    {
        PropertiesClass a = new PropertiesClass();
        [TestMethod]
        public void TestMethod1()
        {
            string val = a["hello"];

            string value = a.Name = "aaaa";

        }
    }
}
