using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    public class Complex
    {
        public double Real { get; set;}
        public double Imaginary { get; set; }
        // binary operator overloading
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex() { Real = c1.Real + c2.Real, Imaginary = c1.Imaginary + c2.Imaginary };
        }

//        public static Complex operator + (Complex c1)
//        {
//              return new Complex() { Real = this.Real + c1.Real, Imaginary = this.Imaginary + c2.Imaginary };
//        }
    
    }
    [TestClass]
    public class UnitOperatorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
