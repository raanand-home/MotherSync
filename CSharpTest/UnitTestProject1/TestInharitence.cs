using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    abstract class Person
    {
        public int Height { get; set; }
        public virtual void HappyBirthDay()
        {
            Height += 1;
        }
        public abstract void IAmHappy();
    }

    class Child
        :Person
    {
        public override void HappyBirthDay()
        {
            base.HappyBirthDay();
            Height += 1;
        }
        

        public override void IAmHappy()
        {
            //Print Happy Happy
        }
    }

    [TestClass]
    public class TestInharitence
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
