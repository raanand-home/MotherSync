using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    class RunMe :Attribute
    {
        public RunMe(int times)
        {
            Times = times;
        }
        public int Times
        {
            get;
            set;
        }

    }

    class ReflectMe
    {
        [RunMe(4)]
        public void Do()
        {

        }

        public void DontDoMe()
        {

        }
    }

    [TestClass]
    public class ReflectionTest
    {
        [TestMethod]
        public void CountTheNumberOfFunction()
        {
            ReflectMe instance = new ReflectMe();
            Type instanceType = instance.GetType();
            var methods = instanceType.GetMethods();
            Assert.AreEqual(instanceType.GetMethods().Length, 6);
        }

        [TestMethod]
        public void FindDO()
        {
            ReflectMe instance = new ReflectMe();
            Type instanceType = instance.GetType();
            var methods = instanceType.GetMethods();
            foreach(var method in methods)
            {
                if(method.Name == "Do")
                {
                    method.GetCustomAttributes(true);
                }
            }
            Assert.Fail("Method Do Wasnet found");
            
        }
    }

}
