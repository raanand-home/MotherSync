using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ConstructorTest
    {
        class A
        {
            public A(string both)
                :this(both,both)
            {

            }
            public A(string a , string b)
            {
                _a = a;
                _b = b;
            }
            string _a, _b;
        }
        
        class B
            : A
        {
            public B()
                :base("BOverrode","x")
            { 
            }
            
            ~B()
            {
                
            }


        }

        
        [TestMethod]
        public void TestMethod1()
        {
            A a = new A("a", "b");
            B b = new B();
        }
    }
}
