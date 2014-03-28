using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    public class NormalINT
    {
        public int Value { get; set; }
        public static implicit operator Complex(NormalINT fahr)
        {
            return new Complex() { Real = fahr.Value };
        }

    }
    public class Complex
    {
        public double Real { get; set;}
        
        // binary operator overloading
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex() { Real = c1.Real + c2.Real };
        }
        
        public static explicit operator NormalINT(Complex fahr)
        {
            return new NormalINT() { Value = (int)fahr.Real };
        }
    }
  
    [TestClass]
    public class UnitOperatorTest
    {
        [TestMethod]
        public void UnitOperatorTestTestMethod()
        {
            Complex a = new Complex() { Real = 2.5 };
            Complex b = new Complex() { Real = 3 };
            Complex c = a + b;
            Assert.AreEqual(c.Real, 5.5);
            c += c +a ;
            Assert.AreEqual(c.Real, 13.5);
            
            
        }
        [TestMethod]
        public void ExplictCastOperatorTest()
        {
            Complex c = new Complex() { Real = 13.6 };
            //exp
            NormalINT SV = (NormalINT)c;
            Assert.AreEqual(SV.Value, 13);
        }

        [TestMethod]
        public void ImplicitCastOperatorTest()
        {
            NormalINT c = new NormalINT() { Value = 13 };
            //See no casting
            Complex SV = c;
            Assert.AreEqual(SV.Real, 13);
        }
    }
}
